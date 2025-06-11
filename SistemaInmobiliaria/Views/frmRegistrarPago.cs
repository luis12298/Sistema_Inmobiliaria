using Microsoft.Reporting.WinForms;
using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmRegistrarPago : Form
    {
        PagoController pagoC = new PagoController();
        SettingController settingC = new SettingController();
        Toast toastC = new Toast();
        public int idContratoG = 0;
        public int idClienteG = 0;
        public int IdG = 0;
        public int idPagoG = 0;
        public frmRegistrarPago(int Id)
        {
            InitializeComponent();
            IdG = Id;


            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnVerPagos, "Ver pagos");
            toolTip.SetToolTip(btnVolver, "Volver");
            toolTip.SetToolTip(btnImprimirFactura, "Imprimir factura");
            toolTip.SetToolTip(btnEliminarPago, "Eliminar Pago");
            toolTip.SetToolTip(btnPlan, "Plan amortizacion");
            toolTip.SetToolTip(btnVerPago, "Ver pagos");
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Warning, btnRegistrar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Success, btnVerPagos);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Info, btnImprimirFactura);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Danger, btnEliminarPago);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Light, btnVolver);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Danger, btnEliminarPago);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Secondary, btnPlan);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Success, btnVerPago);
            BootstrapStyler.ApplyBootstrapStyle(txtNoCuota);
            BootstrapStyler.ApplyBootstrapStyle(txtMontoPagar);
            Formatear(txtMontoPagar);
            new FloatingController().FloatingLabelInput(txtNoCuota, "No Cuota");
            new FloatingController().FloatingLabelInput(txtMontoPagar, "Monto a Pagar");


            ContratoModel.IdContratoG = Id;
            //Cargar(Id);
            CargarDatos(Id);
            //centrar label en el form
            this.Resize += (s, e) => (label1).Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);

        }
        void Estilos(DataGridView dgvDatos)
        {
            //Aplicar color rojo a la columna que diga pendiente
            dgvDatos.CellFormatting += (sender, e) =>
            {
                if (dgvDatos.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
                {
                    if (e.Value.ToString() == "Pendiente")
                    {
                        // Cambiar el color de la fuente a rojo
                        e.CellStyle.ForeColor = Color.Red;

                    }
                    else if (e.Value.ToString() == "Pagada")
                    {

                        e.CellStyle.ForeColor = Color.Green;
                    }
                }
            };
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
        public frmRegistrarPago()
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnVerPagos, "Ver pagos");
            toolTip.SetToolTip(btnVolver, "Volver");

            Cargar(ContratoModel.IdContratoG);

            //centrar label en el form
            this.Resize += (s, e) => (label1).Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);

        }
        private void frmRegistrarPago_Load(object sender, EventArgs e)
        {

        }
        private void Cargar(int Id)
        {
            var datos = pagoC.CargarPagos(Id);
            DataView dv = new DataView(datos);
            dgvDatos.DataSource = dv;

            dgvDatos.Columns["IdContrato"].Visible = false;
            dgvDatos.Columns["IdCliente"].Visible = false;


            dgvDatos.DataBindingComplete += (sender, e) =>
            {
                settingC.AjustarColumnas(dgvDatos);
                Estilos(dgvDatos);
                resumen();
            };
            AgregarBoton();

        }
        public async void CargarDatos(int Id)
        {
            try
            {


                // 2. Habilitar DoubleBuffered mediante reflexión para evitar parpadeos
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, this.dgvDatos, new object[] { true });

                dgvDatos.SuspendLayout();
                dgvDatos.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => pagoC.CargarPagos(Id));

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
                Encabezado(Id);
                dgvDatos.ResumeLayout();
                settingC.AjustarColumnas(dgvDatos);
                AgregarBoton();
                Estilos(dgvDatos);
                resumen();
                this.dgvDatos.Columns["IdContrato"].Visible = false;
                this.dgvDatos.Columns["IdCliente"].Visible = false;
                dgvDatos.CellFormatting += (sender, e) =>
                {
                    var columnasFormateadas = new List<string> { "MontoCuota", "MontoPagado" };

                    string nombreColumna = dgvDatos.Columns[e.ColumnIndex].Name;

                    if (columnasFormateadas.Contains(nombreColumna) && e.Value != null && e.Value is decimal)
                    {
                        decimal valor = (decimal)e.Value;
                        e.Value = string.Format(new System.Globalization.CultureInfo("es-Hn"), "{0:C2}", valor);
                        e.FormattingApplied = true;
                    }
                };
            }
        }

        private void DataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.Tag is DataTable datos)
            {
                if (e.RowIndex < datos.Rows.Count && e.ColumnIndex < datos.Columns.Count)
                {
                    // Obtener el nombre de la columna del DataGridView
                    string nombreColumna = dgv.Columns[e.ColumnIndex].Name;

                    // Buscar el índice de esta columna en el DataTable
                    int indiceColumna = datos.Columns.IndexOf(nombreColumna);

                    // Si encontramos la columna, asignar el valor
                    if (indiceColumna >= 0)
                    {
                        e.Value = datos.Rows[e.RowIndex][indiceColumna];
                    }
                }
            }
        }
        void AgregarBoton()
        {
            // First check if the column already exists and remove it
            if (dgvDatos.Columns.Contains("colMixta"))
            {
                dgvDatos.Columns.Remove("colMixta");
            }

            DataGridViewTextBoxColumn colMixta = new DataGridViewTextBoxColumn();
            colMixta.HeaderText = "Acción";
            colMixta.Name = "colMixta";
            colMixta.ReadOnly = true;

            // Add the column at the end by specifying the index
            dgvDatos.Columns.Add(colMixta);
            // Move the column to the end explicitly
            colMixta.DisplayIndex = dgvDatos.Columns.Count - 1;

            // Populate the rows with buttons or checkboxes based on state
            for (int i = 0; i < dgvDatos.Rows.Count; i++)
            {
                string estado = dgvDatos.Rows[i].Cells["Estado"].Value?.ToString() ?? "";
                if (estado.ToLower() == "pagada")
                {
                    DataGridViewCheckBoxCell chkCell = new DataGridViewCheckBoxCell();
                    chkCell.Value = true;
                    dgvDatos.Rows[i].Cells["colMixta"] = chkCell;
                }
                else
                {
                    DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                    btnCell.Style.ForeColor = Color.FromArgb(13, 110, 253);
                    btnCell.Style.Font = new Font(dgvDatos.Font, FontStyle.Bold);
                    btnCell.Value = "Seleccionar";
                    dgvDatos.Rows[i].Cells["colMixta"] = btnCell;
                }
            }
        }

        public void Encabezado(int Id)
        {
            List<string> datos = new PagoController().Encabezado(Id);
            lblCliente.Text = $"Cliente seleccionado: {datos[0]} {datos[1]}";

        }
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            dgvDatos.Rows[index].Selected = true;
            if (e.ColumnIndex == dgvDatos.Columns["colMixta"].Index)
            {
                string estado = dgvDatos.Rows[e.RowIndex].Cells["Estado"].Value?.ToString() ?? "";

                if (estado.ToLower() == "pagada")
                {
                    //Para editar
                    return;
                }
                else
                {

                    idContratoG = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdContrato"].Value.ToString());
                    txtNoCuota.Text = dgvDatos.Rows[e.RowIndex].Cells["NoCuota"].Value.ToString();
                    txtMontoPagar.Text = dgvDatos.Rows[e.RowIndex].Cells["MontoCuota"].Value.ToString();
                    dateTimePicker1.Value = DateTime.Parse(dgvDatos.Rows[e.RowIndex].Cells["FechaPago"].Value.ToString());

                }
            }
        }

        private void btnVerPagos_Click(object sender, EventArgs e)
        {
            if (IdG == 0)
            {
                toastC.Show(Toast.ToastType.Warning, "Seleccione un contrato");
                return;
            }
            frmVerPago frm = new frmVerPago(IdG);
            frm.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmPrincipal.loadform(new frmListaCobro());
        }

        private void ckModificar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckModificar.Checked)
            {
                txtMontoPagar.ReadOnly = false;
            }
            else
            {
                txtMontoPagar.ReadOnly = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (idContratoG == 0)
            {
                toastC.Show(Toast.ToastType.Warning, "Seleccione un registro");
                return;
            }
            if (string.IsNullOrEmpty(txtMontoPagar.Text))
            {
                toastC.Show(Toast.ToastType.Warning, "Ingrese el monto a pagar");
                return;
            }
            Guardar();
        }
        public void Guardar()
        {

            var datos = new PagoModel();
            datos.IdContrato = idContratoG;
            datos.NoCuota = int.Parse(txtNoCuota.Text);
            datos.MontoPagado = double.Parse(txtMontoPagar.Text);
            datos.FechaCuota = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            datos.Estado = "Pagada";
            datos.FechaPago = DateTime.Now.ToString("yyyy-MM-dd");
            datos.UsuarioCreo = UsuarioModel.Usuario;
            if (pagoC.GuardarPago(datos))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Pago registrado con éxito");
                Cargar(idContratoG);
                ckModificar.Checked = false;
                txtMontoPagar.Text = string.Empty;
                txtNoCuota.Text = string.Empty;
            }
            else
            {
                CustomAlert.ShowAlert(AlertType.Error, "Error", "Error al registrar el pago");
            }
        }
        private void resumen()
        {
            // Sumar MontoPagado si Estado == "Pagada"
            TotalPagado.Text = dgvDatos.Rows
                .Cast<DataGridViewRow>()
                .Where(row => (row.Cells["Estado"].Value?.ToString().ToLower() ?? "") == "pagada")
                .Sum(row => Convert.ToDouble(row.Cells["MontoPagado"].Value ?? 0))
                .ToString("N2");

            // Sumar MontoCuota si Estado == "Pendiente"
            TotalRestante.Text = dgvDatos.Rows
                .Cast<DataGridViewRow>()
                .Where(row => (row.Cells["Estado"].Value?.ToString().ToLower() ?? "") == "pendiente")
                .Sum(row => Convert.ToDouble(row.Cells["MontoCuota"].Value ?? 0))
                .ToString("N2");


            //contar cuotas pagadas si es una o mas

            txtCuotaPagada.Text = dgvDatos.Rows
     .Cast<DataGridViewRow>()
     .Count(row => (row.Cells["Estado"].Value?.ToString().ToLower() ?? "") == "pagada")
     .ToString();
            txtCuotaPendiente.Text = dgvDatos.Rows
     .Cast<DataGridViewRow>()
     .Count(row => (row.Cells["Estado"].Value?.ToString().ToLower() ?? "") == "pendiente")
     .ToString();

        }

        private void btnImprimirFactura_Click(object sender, EventArgs e)
        {
            if (IdG == 0)
            {
                toastC.Show(Toast.ToastType.Warning, "Seleccione un registro");
                return;
            }
            frmVerPago frm = new frmVerPago(IdG);
            frm.ShowDialog();
        }


        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            if (IdG == 0)
            {
                toastC.Show(Toast.ToastType.Warning, "Seleccione un registro");
                return;
            }
            frmEliminarPago frm = new frmEliminarPago(this, IdG);
            frm.ShowDialog();

        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            if (IdG == 0)
            {
                toastC.Show(Toast.ToastType.Warning, "Seleccione un registro");
                return;
            }
            mostrarinform(IdG);
        }
        private void mostrarinform(int Id)
        {
            try
            {
                Form formularioVistaPrevia = new Form
                {
                    Text = "Vista Previa del Informe",
                    Width = 800,
                    Height = 600
                };
                ReportViewer reportViewer = new ReportViewer
                {
                    Dock = DockStyle.Fill,
                    ProcessingMode = ProcessingMode.Local
                };

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.FullPage;

                // Configuración más precisa del tamaño de página y márgenes
                var pageSettings = new System.Drawing.Printing.PageSettings();
                pageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                pageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10); // Márgenes más equilibrados
                pageSettings.Landscape = false;
                reportViewer.SetPageSettings(pageSettings);

                // Configuraciones adicionales que pueden ayudar
                reportViewer.LocalReport.DisplayName = "Plan de Amortización";

                // Generar los datos y asignarlos al ReportViewer
                LocalReport report = reportViewer.LocalReport;
                report.ReportEmbeddedResource = "SistemaInmobiliaria.Reports.PlanAmortizacion.rdlc";
                List<PlanAmortizacionModel> datosFactura = new ReporteController().PlanAmortizacion(Id);
                ReportDataSource rds = new ReportDataSource("DataSet3", datosFactura);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);

                // Configurar el informe antes de renderizarlo
                reportViewer.LocalReport.Refresh();
                reportViewer.RefreshReport();

                formularioVistaPrevia.Controls.Add(reportViewer);
                formularioVistaPrevia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar la vista previa:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PagosClientes(int Id)
        {

            try
            {
                Form formularioVistaPrevia = new Form
                {
                    Text = "Vista Previa del Informe",
                    Width = 800,
                    Height = 600
                };

                ReportViewer reportViewer = new ReportViewer
                {
                    Dock = DockStyle.Fill,
                    ProcessingMode = ProcessingMode.Local
                };


                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.FullPage;

                var pageSettings = new System.Drawing.Printing.PageSettings();
                pageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
                pageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 10, 10);
                pageSettings.Landscape = false;
                reportViewer.SetPageSettings(pageSettings);

                // 🔹 Generar los datos y asignarlos al ReportViewer

                LocalReport report = reportViewer.LocalReport;
                report.ReportEmbeddedResource = "SistemaInmobiliaria.Reports.ReportePago.rdlc";
                List<PagoContratoModel> datosFactura = new ReporteController().ReportePagoContrato(Id, lblCliente.Text, TotalPagado.Text, TotalRestante.Text, txtCuotaPagada.Text, txtCuotaPendiente.Text);

                ReportDataSource rds = new ReportDataSource("DataSet4", datosFactura);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.RefreshReport();

                formularioVistaPrevia.Controls.Add(reportViewer);
                formularioVistaPrevia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar la vista previa:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerPago_Click(object sender, EventArgs e)
        {
            if (IdG == 0)
            {
                toastC.Show(Toast.ToastType.Warning, "Seleccione un contrato");
                return;
            }
            PagosClientes(IdG);
        }
    }
}