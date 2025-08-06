using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Infobip.Api.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using MessageBox = System.Windows.Forms.MessageBox;
using OtpNet;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using SistemaInmobiliaria.Controllers;
using System.Reflection;

namespace SistemaInmobiliaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            CargarPagos(dataGridView1, "2025-06-01", "2025-06-30");
            Thread listenerThread = new Thread(IniciarServidorHttp);
            listenerThread.IsBackground = true;
            listenerThread.Start();
            //GenerarClaveSecreta();
        }
        private void IniciarServidorHttp()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/reporte/");
            listener.Start();
            MessageBox.Show("Servidor HTTP iniciado en http://localhost:5000/reporte/");

            while (true)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    // Añadir encabezado CORS
                    response.AddHeader("Access-Control-Allow-Origin", "*");

                    // Leer parámetros de query string
                    var query = request.Url.Query; // "?fecha1=2025-06-01&fecha2=2025-06-30"
                    var queryParams = System.Web.HttpUtility.ParseQueryString(query);

                    string fecha1 = queryParams["fecha1"];
                    string fecha2 = queryParams["fecha2"];

                    // Validar que los parámetros existan
                    if (string.IsNullOrEmpty(fecha1) || string.IsNullOrEmpty(fecha2))
                    {
                        response.StatusCode = 400; // Bad Request
                        byte[] errorBuffer = Encoding.UTF8.GetBytes("{\"error\":\"Faltan parámetros fecha1 o fecha2\"}");
                        response.ContentType = "application/json";
                        response.ContentLength64 = errorBuffer.Length;
                        response.OutputStream.Write(errorBuffer, 0, errorBuffer.Length);
                        response.OutputStream.Close();
                        continue;
                    }

                    // Obtener datos con las fechas recibidas
                    DataTable datos = new ReporteGeneralController().FechasPagadas(fecha1, fecha2);

                    // Serializar a JSON
                    string json = JsonConvert.SerializeObject(datos, Formatting.Indented);

                    byte[] buffer = Encoding.UTF8.GetBytes(json);
                    response.ContentType = "application/json";
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.OutputStream.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en servidor HTTP: " + ex.Message);
                }
            }
        }

        private string claveSecreta;

        private void iconButton1_Click(object sender, EventArgs e)
        {



        }
        private void GenerarClaveSecreta()
        {
            claveSecreta = "QCBBTQTAXAL4ELVH72ECMLAGTGV5C3VA";

            // Generar y mostrar el QR (una sola vez es suficiente)
            string nombre = "App:Lottin";
            string issuer = "App";
            string otpauth = $"otpauth://totp/{nombre}?secret={claveSecreta}&issuer={issuer}";
            string urlQR = $"https://api.qrserver.com/v1/create-qr-code/?data={Uri.EscapeDataString(otpauth)}";

            linkqr.Text = "Haz clic aquí para abrir el QR";
            linkqr.Tag = urlQR;
            label1.Text = "Clave Secreta: " + claveSecreta;
        }


        private void linkqr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkqr_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = linkqr.Tag.ToString();
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            var bytes = Base32Encoding.ToBytes(claveSecreta);
            var totp = new Totp(bytes);
            string pin = textBox1.Text.Trim();

            if (totp.VerifyTotp(pin, out _, new VerificationWindow(1, 1)))
            {
                MessageBox.Show("✅ PIN correcto. Acceso autorizado.");
            }
            else
            {
                MessageBox.Show("❌ PIN incorrecto. Intenta de nuevo.");
            }
        }

        async public void CargarPagos(DataGridView dgvDatos, string fecha1, string fecha2)
        {
            try
            {


                //// 2. Habilitar DoubleBuffered mediante reflexión para evitar parpadeos
                //typeof(DataGridView).InvokeMember("DoubleBuffered",
                //    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                //    null, this.dgvDatos, new object[] { true });

                dgvDatos.SuspendLayout();
                dgvDatos.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => new ReporteGeneralController().FechasPagadas(fecha1, fecha2));
                // Asignar DataSource (el DataGridView manejará los datos automáticamente)
                dgvDatos.DataSource = datos;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 10. Reanudar el layout una vez terminada la carga

                dgvDatos.ResumeLayout();
                new SettingController().AjustarColumnas(dgvDatos);

            }
        }
    }

}
