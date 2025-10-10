using FontAwesome.Sharp;
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
using Image = System.Drawing.Image;
using Rectangle = System.Drawing.Rectangle;

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
            dgvDatos.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && dgvDatos.Columns[e.ColumnIndex].Name == "colMixta" && e.RowIndex >= 0)
                {
                    // Pinta el fondo y bordes de la celda
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    // Carga la imagen solid
                    Image img = IconChar.Eye.ToBitmap(20, 20, Color.Black);

                    // Posición de la imagen al inicio (lado izquierdo)
                    int imgX = e.CellBounds.Left + 3; // 5px de margen desde el borde izquierdo
                    int imgY = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;

                    // Dibuja la imagen
                    e.Graphics.DrawImage(img, new Rectangle(imgX, imgY, img.Width, img.Height));

                    // Obtiene el texto de la celda
                    string cellText = e.FormattedValue?.ToString() ?? "";

                    if (!string.IsNullOrEmpty(cellText))
                    {
                        // Posición del texto después de la imagen
                        int textX = imgX + img.Width + 1; //  separación entre imagen y texto
                        int textY = e.CellBounds.Top;
                        int textWidth = e.CellBounds.Right - textX;
                        int textHeight = e.CellBounds.Height;

                        Rectangle textRect = new Rectangle(textX, textY, textWidth, textHeight);

                        // Dibuja el texto
                        TextRenderer.DrawText(e.Graphics, cellText, e.CellStyle.Font,
                            textRect, e.CellStyle.ForeColor,
                            TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                    }

                    e.Handled = true;
                }
            };
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

        private ReportViewer reportViewer;
        private IconButton btnRegresar;

        private void mostrarinform(int Id)
        {
            string numero;
            Random random = new Random();
            numero = random.Next(100000, 999999).ToString();

            try
            {
                // Crear ReportViewer
                reportViewer = new ReportViewer
                {
                    Dock = DockStyle.Fill,
                    ProcessingMode = ProcessingMode.Local
                };

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.FullPage;

                // Configuración de página
                var pageSettings = new System.Drawing.Printing.PageSettings
                {
                    PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100),
                    Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0),
                    Landscape = false
                };
                reportViewer.SetPageSettings(pageSettings);

                // Configuración del informe
                LocalReport report = reportViewer.LocalReport;
                report.ReportEmbeddedResource = "SistemaInmobiliaria.Reports.FacturaCuota.rdlc";

                // Obtener datos
                List<FactCuotaModel> datosFactura = new FactPrimaController().FacturaPago(Id);


                ReportDataSource rds = new ReportDataSource("DataSet2", datosFactura);

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);

                // habilitar imágenes externas antes de pasar parámetros
                reportViewer.LocalReport.EnableExternalImages = true;
                // Preparar rutas (asegúrate de que existan los archivos)
                string rutaLogo = @"file:///" + datosFactura[0].RutaLogo.Replace("\\", "/");
                string rutaFirma = @"file:///" + datosFactura[0].RutaFirma.Replace("\\", "/");

                // Crear los parámetros
                ReportParameter[] parametros = new ReportParameter[]
                {
    new ReportParameter("RutaImagen", rutaLogo),
    new ReportParameter("FirmaImagen", rutaFirma)
                };

                // Asignar los parámetros al reporte
                reportViewer.LocalReport.SetParameters(parametros);
                reportViewer.RefreshReport();

                // Botón Regresar
                btnRegresar = new IconButton
                {
                    Text = "Regresar",
                    Dock = DockStyle.Top,
                    Height = 40,
                    BackColor = Color.LightGray,
                    IconChar = IconChar.AngleLeft,
                    IconSize = 28,
                    TextAlign = ContentAlignment.MiddleRight,
                    TextImageRelation = TextImageRelation.ImageBeforeText,
                };
                btnRegresar.Click += (s, e) =>
                {
                    this.Controls.Remove(reportViewer);
                    this.Controls.Remove(btnRegresar);
                    reportViewer.Dispose();
                    btnRegresar.Dispose();
                };

                // Agregar al formulario
                BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Warning, btnRegresar);
                this.Controls.Add(reportViewer);
                this.Controls.Add(btnRegresar);

                btnRegresar.BringToFront();
                reportViewer.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar la vista previa:\n{ex.Message}\n\nDetalle: {ex.InnerException}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            colMixta.Text = "Ver factura";

            colMixta.ToolTipText = "Imprimir factura";
            colMixta.UseColumnTextForButtonValue = true; // Para que muestre el texto en cada botón

            // Agrega la columna al final
            dgvDatos.Columns.Add(colMixta);
            colMixta.DisplayIndex = dgvDatos.Columns.Count - 1;
        }

    }
}
