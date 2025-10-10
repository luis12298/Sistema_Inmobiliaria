using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaInmobiliaria
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            int altura = txtMensajeW.Height;
            int altura2 = txtMensaje.Height;
            BootstrapStyler.ApplyBootstrapStyle(txtMensajeW);
            BootstrapStyler.ApplyBootstrapStyle(txtMensaje);
            BootstrapStyler.ApplyBootstrapStyle(txtNombre);
            PlaceholderController.SetPlaceholder(txtNombre, "Ingrese nombre", 5);
            BootstrapStyler.ApplyBootstrapStyle(txtDireccion);
            PlaceholderController.SetPlaceholder(txtDireccion, "Ingrese direccion factura", 5);
            BootstrapStyler.ApplyBootstrapStyle(txtTelefono);
            PlaceholderController.SetPlaceholder(txtTelefono, "Ingrese telefono factura", 5);
            BootstrapStyler.ApplyBootstrapStyle(txtCorreo);
            PlaceholderController.SetPlaceholder(txtCorreo, "Ingrese correo factura", 5);
            BootstrapStyler.ApplyBootstrapStyle(txtFirma);
            PlaceholderController.SetPlaceholder(txtFirma, "Ingrese firma (opcional)", 5);
            txtMensajeW.Height = altura;
            txtMensaje.Height = altura2;
            BootstrapStyler.ApplyBootstrapStyle(txtRutaLogo);
            BootstrapStyler.ApplyBootstrapStyle(txtLicenciaFirebase);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Secondary, btnCargar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Secondary, btnCargar2);

            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnGuardar);
            CargarDatosSinClase(@"C:\Data\settings.json");
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaLogo.Text = openFileDialog.FileName;
            }
        }
        private void CargarDatosSinClase(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                //MessageBox.Show("El archivo no existe", "Error",
                //                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //create the file
                var jsonObj = new JObject
                {

                    ["rutaLogo"] = "",
                    ["rutaFirma"] = "",
                    ["MensajeW"] = "",
                    ["Mensaje"] = "",
                    ["Licencia"] = "",
                    ["Nombre"] = "",
                    ["Direccion"] = "",
                    ["Telefono"] = "",
                    ["Correo"] = "",


                };

                var json = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(rutaArchivo, json);
                return;
            }

            try
            {
                // Aquí lees el archivo en lugar del string quemado
                string jsonString = File.ReadAllText(rutaArchivo);

                var jsonObj = JObject.Parse(jsonString);

                txtRutaLogo.Text = jsonObj["rutaLogo"]?.ToString() ?? "";
                txtFirma.Text = jsonObj["rutaFirma"]?.ToString() ?? "";
                txtMensajeW.Text = jsonObj["MensajeW"]?.ToString() ?? "";
                txtMensaje.Text = jsonObj["Mensaje"]?.ToString() ?? "";
                txtLicenciaFirebase.Text = jsonObj["Licencia"]?.ToString() ?? "";
                txtNombre.Text = jsonObj["Nombre"]?.ToString() ?? "";
                txtDireccion.Text = jsonObj["Direccion"]?.ToString() ?? "";
                txtTelefono.Text = jsonObj["Telefono"]?.ToString() ?? "";
                txtCorreo.Text = jsonObj["Correo"]?.ToString() ?? "";

            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"Error al leer JSON: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarCambiosAArchivo(string rutaArchivo)
        {
            try
            {
                var jsonObj = JObject.Parse(File.ReadAllText(rutaArchivo));
                jsonObj["rutaLogo"] = txtRutaLogo.Text;
                jsonObj["rutaFirma"] = txtFirma.Text;
                jsonObj["MensajeW"] = txtMensajeW.Text;
                jsonObj["Mensaje"] = txtMensaje.Text;
                jsonObj["Licencia"] = txtLicenciaFirebase.Text;
                jsonObj["Nombre"] = txtNombre.Text;
                jsonObj["Direccion"] = txtDireccion.Text;
                jsonObj["Telefono"] = txtTelefono.Text;
                jsonObj["Correo"] = txtCorreo.Text;
                var jsonActualizado = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                File.WriteAllText(rutaArchivo, jsonActualizado);
                MessageBox.Show("Datos guardados correctamente", "Éxito",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambiosAArchivo(@"C:\Data\settings.json");
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCargar2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos PNG|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFirma.Text = openFileDialog.FileName;
            }
        }
    }
}
