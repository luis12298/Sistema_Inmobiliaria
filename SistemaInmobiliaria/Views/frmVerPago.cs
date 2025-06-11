using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmVerPago : Form
    {
        ReporteController reporteC = new ReporteController();
        SettingController settingC = new SettingController();
        public int IdG;
        public frmVerPago(int Id)
        {
            InitializeComponent();
            CargarDatos(dgvDatos, Id);
            IdG = Id;
            this.Size = new Size(1024, 600);
            FloatingController floatingC = new FloatingController();
            floatingC.FloatingLabelInput(txtFiltrar, "Filtrar");
            BootstrapStyler.ApplyBootstrapStyle(txtFiltrar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Info, btnExportar);

        }


        private async void CargarDatos(DataGridView dataGridView, int Id)
        {
            try
            {


                // 2. Habilitar DoubleBuffered mediante reflexión para evitar parpadeos
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dataGridView, new object[] { true });

                dataGridView.SuspendLayout();
                dataGridView.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => reporteC.verpagos(Id));

                // Asignar DataSource (el DataGridView manejará los datos automáticamente)
                dataGridView.DataSource = datos;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 10. Reanudar el layout una vez terminada la carga

                dataGridView.ResumeLayout();
                settingC.AjustarColumnas(dataGridView);

            }
            AgregarBoton();
        }
        private void AplicarFiltroBusqueda(DataGridView dataGridView, string textoBusqueda)
        {


            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                dataGridView.DataSource = reporteC.verpagos(IdG);
                return;
            }

            DataTable filteredTable = reporteC.verpagos(IdG).Clone();
            string searchText = textoBusqueda.ToLower();

            foreach (DataRow row in reporteC.verpagos(IdG).Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    if (item?.ToString().ToLower().Contains(searchText) == true)
                    {
                        filteredTable.ImportRow(row);
                        break;
                    }
                }
            }

            dataGridView.DataSource = filteredTable;
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda(dgvDatos, txtFiltrar.Text);
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos.Rows[index].Selected = true;

            if (e.ColumnIndex == dgvDatos.Columns["colMixta"].Index)
            {
                int Id = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdPago"].Value.ToString());
                mostrarinform(Id);

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewAPdf(dgvDatos);
        }
        public void ExportarDataGridViewAPdf(DataGridView dgv)
        {
            Toast toast = new Toast();
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            // Crear documento con margen de 1 cm (28.35 puntos)
            Document doc = new Document(PageSize.LETTER, 28.35f, 28.35f, 28.35f, 28.35f);

            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Archivo PDF (*.pdf)|*.pdf";
                save.FileName = "Reporte.pdf";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                    doc.Open();

                    PdfPTable table = new PdfPTable(dgv.ColumnCount);
                    table.WidthPercentage = 100;

                    // Agregar encabezados
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    // Agregar filas
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Value is DateTime fecha)
                                {
                                    table.AddCell(fecha.ToShortDateString());
                                }
                                else
                                {
                                    table.AddCell(cell.Value?.ToString() ?? "");
                                }
                            }
                        }
                    }


                    doc.Add(table);
                    toast.Show(Toast.ToastType.Success, "Pdf generado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message);
            }
            finally
            {
                if (doc.IsOpen())
                    doc.Close();
            }
        }

        private void mostrarinform(int Id)
        {
            string numero;
            Random random = new Random();
            numero = random.Next(100000, 999999).ToString();
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
                pageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                pageSettings.Landscape = false;
                reportViewer.SetPageSettings(pageSettings);

                // 🔹 Generar los datos y asignarlos al ReportViewer
                LocalReport report = reportViewer.LocalReport;
                report.ReportEmbeddedResource = "SistemaInmobiliaria.Reports.FacturaCuota.rdlc";
                List<FactCuotaModel> datosFactura = new FactPrimaController().FacturaPago(Id);

                ReportDataSource rds = new ReportDataSource("DataSet2", datosFactura); // Asegúrate que "DataSet1" coincida con el nombre en el RDLC
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
        void AgregarBoton()
        {
            // Verifica si la columna ya existe y la elimina
            if (dgvDatos.Columns.Contains("colMixta"))
            {
                dgvDatos.Columns.Remove("colMixta");
            }

            // Crea una columna de tipo botón
            DataGridViewButtonColumn colMixta = new DataGridViewButtonColumn();
            colMixta.HeaderText = "Acción";
            colMixta.Name = "colMixta";
            colMixta.Text = "Imprimir";
            colMixta.ToolTipText = "Imprimir factura";
            colMixta.UseColumnTextForButtonValue = true; // Para que muestre el texto en cada botón

            // Agrega la columna al final
            dgvDatos.Columns.Add(colMixta);
            colMixta.DisplayIndex = dgvDatos.Columns.Count - 1;
        }

    }
}
