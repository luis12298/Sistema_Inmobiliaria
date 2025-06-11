using Humanizer;
using Microsoft.Reporting.WinForms;
using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmContrato : Form
    {
        FloatingController floatingC = new FloatingController();
        ContratoController contratoC = new ContratoController();
        ClienteController clienteC = new ClienteController();
        ToolTip toolTip = new ToolTip();
        Toast toast = new Toast();
        frmListaContrato _frmListaContrato;
        public int IdContratoG;

        public int IdCliente;
        public int IdLoteG;


        public frmContrato(frmListaContrato frmListaContrato)
        {
            InitializeComponent();
            configuraciones();

            _frmListaContrato = frmListaContrato;
        }
        void configuraciones()
        {
            toolTip.SetToolTip(btnCargar, "Cargar Lote");
            floatingC.FloatingLabelInput(txtAnios, "Años");
            floatingC.FloatingLabelInput(txtInteres, "Interes");
            floatingC.FloatingLabelInput(txtPrima, "Prima");
            floatingC.FloatingLabelInput(txtInteresAtraso, "Int Atraso");
            floatingC.FloatingLabelInput(txtIdentidad, "Identidad");
            floatingC.FloatingLabelInput(txtCliente, "Cliente");
            floatingC.FloatingLabelInput(txtTelefono, "Telefono");
            floatingC.FloatingLabelInput(txtDireccion, "Direccion");
            Formatear(txtMonto);
            Formatear(txtPrima);
            Formatear(txtPrecioLote);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Primary, btnGuardar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Secondary, btnCancelarTodo);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Info, btnEjecutar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Secondary, btnCancelar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Info, btnCargar);
            ApplyBootstrapToAllTextBoxes(this);
            txtDia.Font = new Font("Segoe UI", 10.75F, FontStyle.Regular, GraphicsUnit.Point);
        }

        private void ApplyBootstrapToAllTextBoxes(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    BootstrapStyler.ApplyBootstrapStyle(textBox);
                }
                else if (control.HasChildren)
                {
                    ApplyBootstrapToAllTextBoxes(control);
                }
            }
        }

        public frmContrato(frmListaContrato frmListaContrato, int Id)
        {
            InitializeComponent();
            configuraciones();
            CargarContrato(Id);
            txtDescripcion.Text = "Contrato actualizado";
            btnGuardar.Text = "Actualizar";
            _frmListaContrato = frmListaContrato;
            ckPrima.Enabled = true;
        }
        public void Calcularmeses()
        {
            decimal cantidad;
            if (decimal.TryParse(txtAnios.Text, out cantidad))
            {
                txtMeses.Text = (cantidad * 12).ToString("0.##"); // Muestra sin decimales si es exacto, o con hasta 2 si es decimal
            }
            else
            {
                txtMeses.Text = "0";
            }

        }
        private void CalcularFechas(DateTime fechaInicio, int diaAsignado)
        {
            try
            {
                // Validar campos
                if (!int.TryParse(txtAnios.Text, out int años) || años <= 0)
                {
                    MessageBox.Show("Ingrese un número de años válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Calcular FECHA INICIAL (primer día del mes siguiente al inicio)
                DateTime fechaInicial = new DateTime(fechaInicio.Year, fechaInicio.Month, 1).AddMonths(1);
                int ultimoDiaMesInicio = DateTime.DaysInMonth(fechaInicial.Year, fechaInicial.Month);
                fechaInicial = fechaInicial.AddDays(Math.Min(diaAsignado, ultimoDiaMesInicio) - 1);

                // Calcular FECHA FINAL (fechaInicial + años)
                DateTime fechaFinal = fechaInicio.AddYears(años);
                int ultimoDiaMesFinal = DateTime.DaysInMonth(fechaFinal.Year, fechaFinal.Month);
                fechaFinal = new DateTime(fechaFinal.Year, fechaFinal.Month, Math.Min(diaAsignado, ultimoDiaMesFinal));

                // Mostrar resultados
                dtpInicio.Value = fechaInicial;
                dtpFinal.Value = fechaFinal;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular fechas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CalcularAmortizacion(double principal)
        {
            double tasaInteresAnual = string.IsNullOrEmpty(txtInteres.Text) ? 0 : double.Parse(txtInteres.Text);
            double tasaInteresMensual = tasaInteresAnual / 100 / 12;
            double periodos = double.Parse(txtMeses.Text);
            double cuota;

            if (tasaInteresMensual == 0)
                cuota = principal / periodos;
            else
                cuota = (principal * tasaInteresMensual) / (1 - Math.Pow(1 + tasaInteresMensual, -periodos));

            txtCuota.Text = cuota.ToString("N2");
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            // Validación mejorada
            if (!ValidarDatos())
                return;

            // Obtener valores
            double montoOriginal = double.Parse(txtMonto.Text);
            double prima = string.IsNullOrEmpty(txtPrima.Text) ? 0 : double.Parse(txtPrima.Text);

            // Calcular
            CalcularFechas(dtpInicio.Value, int.Parse(txtDia.Text));
            CalcularAmortizacion(montoOriginal - prima);



        }
        private string numtowords(double numero)
        {
            // Obtener la cultura específica para Honduras
            CultureInfo cultura = new CultureInfo("es-HN");

            // Separar parte entera y decimal
            int parteEntera = (int)Math.Floor(numero);
            int parteDecimal = (int)Math.Round((numero - parteEntera) * 100);

            // Convertir parte entera a palabras
            string textoParteEntera = parteEntera.ToWords(cultura);

            // Construir el resultado final
            string resultado;

            if (parteDecimal > 0)
            {
                // Si hay decimales, incluirlos en el formato adecuado
                string textoParteDecimal = parteDecimal.ToWords(cultura);
                resultado = $"{textoParteEntera} con {textoParteDecimal} centavos";
            }
            else
            {
                // Si no hay decimales, formato simple
                resultado = textoParteEntera;
            }

            // Mejorar presentación: primera letra en mayúscula
            return char.ToUpper(resultado[0]) + resultado.Substring(1);
        }
        private void mostrarinform()
        {
            string numero;
            Random random = new Random();
            numero = random.Next(100000, 999999).ToString();

            try
            {
                // Configurar el ReportViewer
                LocalReport report = new LocalReport();
                report.ReportEmbeddedResource = "SistemaInmobiliaria.Reports.FacturaPrima.rdlc";

                List<FactPrimaModel> datosFactura = new FactPrimaController().GenerarFactura(
                    numero,
                    txtIdentidad.Text,
                    txtCliente.Text,
                    txtDireccion.Text,
                    txtLote.Text,
                    txtPrima.Text,
                    numtowords(double.Parse(txtPrima.Text))
                );

                ReportDataSource rds = new ReportDataSource("DataSet1", datosFactura);
                report.DataSources.Clear();
                report.DataSources.Add(rds);
                report.Refresh();

                // Configurar los parámetros de imagen
                string deviceInfo =
                    @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
              </DeviceInfo>";

                Warning[] warnings;
                List<Stream> streams = new List<Stream>();

                Stream CreateStream(string name, string fileNameExtension, Encoding encoding,
                                    string mimeType, bool willSeek)
                {
                    Stream stream = new MemoryStream();
                    streams.Add(stream);
                    return stream;
                }

                // Renderizar el informe como imágenes EMF
                report.Render("Image", deviceInfo, CreateStream, out warnings);

                foreach (Stream stream in streams)
                    stream.Position = 0;

                // Imprimir las imágenes
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrinterSettings.PrinterName = new PrinterSettings().PrinterName; // o especificar otro
                printDoc.PrintPage += (sender, e) =>
                {
                    Metafile pageImage = new Metafile(streams[currentPageIndex]);
                    e.Graphics.DrawImage(pageImage, e.PageBounds);

                    currentPageIndex++;
                    e.HasMorePages = (currentPageIndex < streams.Count);
                };

                currentPageIndex = 0;
                printDoc.Print();

                // Cerrar los streams
                foreach (Stream stream in streams)
                    stream.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir el informe:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Necesario como variable global o de clase
        private int currentPageIndex = 0;


        private bool ValidarDatos()
        {
            if (!double.TryParse(txtMonto.Text, out double monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtAnios.Text, out int años) || años <= 0)
            {
                MessageBox.Show("Ingrese un número de años válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;

        }

        private void txtAnios_TextChanged(object sender, EventArgs e)
        {
            Calcularmeses();
        }
        private void Formatear(TextBox txt)
        {
            void AplicarFormato(object sender, EventArgs e)
            {
                TextBox box = (TextBox)sender;

                if (string.IsNullOrWhiteSpace(box.Text))
                    return;

                int cursorPos = box.SelectionStart;
                string textoLimpio = box.Text.Replace(",", "");

                if (decimal.TryParse(textoLimpio, out decimal valorDecimal))
                {
                    string nuevoTexto;

                    if (textoLimpio.Contains('.'))
                    {
                        string[] partes = textoLimpio.Split('.');
                        string parteEntera = partes[0];
                        string parteDecimal = partes.Length > 1 ? partes[1] : "";

                        if (long.TryParse(parteEntera, out long entero))
                            nuevoTexto = $"{entero:N0}.{parteDecimal}";
                        else
                            nuevoTexto = textoLimpio;
                    }
                    else
                    {
                        nuevoTexto = valorDecimal.ToString("N0");
                    }

                    // Calcular nueva posición del cursor
                    if (cursorPos > 0)
                    {
                        int digitosAntesDelCursor = box.Text
                            .Substring(0, cursorPos)
                            .Replace(",", "")
                            .Length;

                        int nuevaPosicion = 0;
                        int digitosEncontrados = 0;

                        foreach (char c in nuevoTexto)
                        {
                            if (digitosEncontrados >= digitosAntesDelCursor)
                                break;

                            if (char.IsDigit(c))
                                digitosEncontrados++;

                            nuevaPosicion++;
                        }

                        cursorPos = nuevaPosicion;
                    }

                    box.Text = nuevoTexto;
                    box.SelectionStart = cursorPos;
                }
            }

            // Asignar evento y aplicar una vez al iniciar
            txt.TextChanged -= AplicarFormato;
            txt.TextChanged += AplicarFormato;
            AplicarFormato(txt, EventArgs.Empty); // Ejecuta formateo inicial
        }

        private void ckModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckModificar.Checked)
            {
                txtPrecioLote.ReadOnly = false;

            }
            else
            {
                txtPrecioLote.ReadOnly = true;
            }
        }

        private void txtPrecioLote_TextChanged(object sender, EventArgs e)
        {
            txtMonto.Text = txtPrecioLote.Text;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            frmListaLote frm = new frmListaLote(this);
            frm.ShowDialog();
        }
        public void CargarLote(int id, string numero, string precio, string Estado, string metros, string varas, string descripcion)
        {
            var mensaje = new Toast();
            //si IdContratG es distinto de Entonces estado estado ya no importa
            if ((Estado == "Vendido" || Estado == "Apartado") && IdContratoG == 0)
            {
                mensaje.Show(Toast.ToastType.Error, "El lote seleccionado se encuentra " + Estado);
                return;
            }

            IdLoteG = id;
            txtPrecioLote.Text = precio.Replace("L", ""); ;
            txtLote.Text = numero;
            cmbEstadoL.Text = Estado;
            txtMetros.Text = metros;
            txtVaras.Text = varas;
            txtDescripcionL.Text = descripcion;
        }
        public void CargarCliente(string id)
        {
            IdCliente = int.Parse(id);
            List<string> datosCliente = clienteC.CargarCliente(id.ToString());
            if (datosCliente == null) return;
            txtIdentidad.Text = datosCliente[1];
            txtCliente.Text = $"{datosCliente[2]} {datosCliente[3]}";
            txtTelefono.Text = datosCliente[4];
            txtDireccion.Text = datosCliente[5];
        }





        private void btnCargarC_Click(object sender, EventArgs e)
        {
            frmListaCliente frm = new frmListaCliente(this);
            frm.ShowDialog();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cancelar la operación?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //limpiar cajas de texto
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Text = string.Empty;
                    }
                }

            }
        }

        #region
        public void CargarLote(string idLote)
        {
            LoteController lotec = new LoteController();
            List<string> datos = lotec.CargarLote(idLote.ToString());
            if (datos == null) return;
            IdLoteG = int.Parse(datos[0]);
            txtLote.Text = datos[1];
            txtMetros.Text = datos[2];
            txtVaras.Text = datos[3];
            txtPrecioLote.Text = datos[4];
            cmbEstadoL.Text = datos[5];
            txtDescripcionL.Text = datos[6];

        }
        public void CargarContrato(int Id)
        {
            var datos = new ContratoController();
            List<string> list = new List<string>();
            list = datos.CargarContrato(Id);

            IdContratoG = int.Parse(list[0]);
            CargarCliente(list[9]);
            dtpInicio.Value = DateTime.Parse(list[1]);
            dtpFinal.Value = DateTime.Parse(list[2]);
            txtDia.Text = dtpInicio.Value.ToString("dd");
            txtMonto.Text = list[3];
            txtMeses.Text = list[4];
            txtAnios.Text = (double.Parse(list[4]) / 12).ToString("0.##");
            txtCuota.Text = list[5];
            txtInteresAtraso.Text = list[6];
            txtInteres.Text = "0.00";
            txtDescripcion.Text = "Contrato actualizado";
            txtCliente.Text = list[10];
            txtLote.Text = list[12];
            txtPrecioLote.Text = list[13];
            IdLoteG = int.Parse(list[11]);

            ckPrima.Checked = bool.Parse(list[14]);
            CargarLote(IdLoteG.ToString());

        }

        public void GuardarContrato()
        {
            var datos = new ContratoModel();

            datos.IdLote = IdLoteG;
            datos.IdCliente = IdCliente;
            datos.FechaInicio = dtpInicio.Value.ToString("yyyy-MM-dd");
            datos.FechaFin = dtpFinal.Value.ToString("yyyy-MM-dd");
            datos.MontoTotal = string.IsNullOrEmpty(txtPrima.Text)
                ? double.Parse(txtMonto.Text)
                : double.Parse(txtMonto.Text) - double.Parse(txtPrima.Text);
            datos.CantidadCuota = double.Parse(txtMeses.Text);
            datos.CuotaFinal = double.Parse(txtCuota.Text);
            datos.InteresRetraso = double.Parse(txtInteresAtraso.Text);
            datos.Estado = txtEstado.Text;
            datos.Prima = string.IsNullOrEmpty(txtPrima.Text) ? false : true;
            datos.Descripcion = txtDescripcion.Text;
            if (contratoC.GuardarContrato(datos))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Contrato guardado con éxito");
                new LoteController().ActualizarLote2(IdLoteG, txtMonto.Text, cmbEstadoL.Text);
                //LimpiarCampos(txtMonto, txtPrecioLote, txtCliente, txtLote, txtCuota, txtInteres, txtInteresAtraso, txtPrecioCasa, txtMeses, txtInteresAtraso, txtInteres, txtDescripcion);
                _frmListaContrato.ListarContratos();
                this.Close();
            }
            else
            {
                CustomAlert.ShowAlert(AlertType.Error, "Error", "Error al guardar el contrato");
            }

        }
        public void ActualizarContrato()
        {
            var datos = new ContratoModel();

            datos.IdContrato = IdContratoG;
            datos.IdLote = IdLoteG;
            datos.IdCliente = IdCliente;
            datos.FechaInicio = dtpInicio.Value.ToString("yyyy-MM-dd");
            datos.FechaFin = dtpFinal.Value.ToString("yyyy-MM-dd");
            datos.MontoTotal = string.IsNullOrEmpty(txtPrima.Text)
                ? double.Parse(txtMonto.Text)
                : double.Parse(txtMonto.Text) - double.Parse(txtPrima.Text);
            datos.CantidadCuota = double.Parse(txtMeses.Text);
            datos.CuotaFinal = double.Parse(txtCuota.Text);
            datos.InteresRetraso = double.Parse(txtInteresAtraso.Text);
            datos.Estado = txtEstado.Text;
            datos.Descripcion = txtDescripcion.Text;
            datos.Prima = ckPrima.Checked && string.IsNullOrEmpty(txtPrima.Text);


            if (contratoC.ActualizarContrato(datos))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Contrato actualizado con éxito");
                new LoteController().ActualizarLote2(IdLoteG, txtMonto.Text, cmbEstadoL.Text);

                //LimpiarCampos(txtMonto, txtPrecioLote, txtCliente, txtLote, txtCuota, txtInteres, txtInteresAtraso, txtPrecioCasa, txtMeses, txtInteresAtraso, txtInteres, txtDescripcion);
                _frmListaContrato.ListarContratos();
                this.Close();
            }
            else
            {
                CustomAlert.ShowAlert(AlertType.Error, "Error", "Error al actualizar el contrato");
            }
        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                toast.Show(Toast.ToastType.Warning, "Seleccione un cliente");
                return;
            }
            else if (IdLoteG == 0)
            {
                toast.Show(Toast.ToastType.Warning, "Seleccione un lote");
                return;
            }
            if (ValidarCampos((txtMonto, "No hay monto"), (txtMeses, "No hay cuotas"), (txtInteresAtraso, "Agregue un interes de retraso"), (txtCuota, "Agregue una cuota")))
            {
                if (IdContratoG == 0)
                {
                    GuardarContrato();

                    if (!string.IsNullOrEmpty(txtPrima.Text))
                    {
                        DialogResult res = CustomAlert.ShowConfirm(AlertType.Info, "¿Mensaje", "Desea imprimir la factura?");
                        if (res == DialogResult.OK)
                        {
                            mostrarinform();
                        }

                    }
                }
                else
                {
                    ActualizarContrato();
                }

            }
        }
        public bool ValidarCampos(params (TextBox caja, string mensaje)[] campos)
        {
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.caja.Text))
                {
                    string mensaje = campo.mensaje;

                    // Si el mensaje no termina en punto, lo agregamos por estética
                    if (!mensaje.Trim().EndsWith("."))
                    {
                        mensaje = mensaje.Trim() + ".";
                    }

                    toast.Show(Toast.ToastType.Warning, $"{mensaje}");
                    campo.caja.Focus();
                    return false;
                }
            }
            return true;
        }
        void LimpiarCampos(params TextBox[] cajas)
        {
            foreach (TextBox caja in cajas)
            {
                caja.Clear();
            }
            IdLoteG = 0;
            IdCliente = 0;
            IdContratoG = 0;
        }

        private void ckActivo_CheckedChanged(object sender, EventArgs e)
        {
            txtEstado.Text = ckActivo.Checked ? "Activo" : "Inactivo";
        }



        private void btnCancelarTodo_Click(object sender, EventArgs e)
        {
            //recorrer todos los textbox y limpiarlos
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
            foreach (Control control in panel3.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
            foreach (Control control in panel1.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
            IdLoteG = 0;
            IdCliente = 0;
            IdContratoG = 0;
        }

        private void btnCargarV_Click_1(object sender, EventArgs e)
        {

        }


    }
}
