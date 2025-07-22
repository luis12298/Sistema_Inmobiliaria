using FontAwesome.Sharp;
using Handy.DotNETCoreCompatibility.ColourTranslations;
using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmDashboard : Form
    {
        ReporteController reporteC = new ReporteController();
        SettingController settingC = new SettingController();
        public frmDashboard()
        {
            InitializeComponent();
            CargarDatos(dgvDatos);
            this.Resize += (s, e) =>
            {

                label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
                label2.Location = new Point((this.Width - label2.Width) / 2, label2.Location.Y);
            };

            CargarCobros(dgvDatos2);
            this.dgvDatos.CellFormatting += (sender, e) =>
            {
                var columnasFormateadas = new List<string> { "Cuota", "MontoAtrasado" };

                string nombreColumna = dgvDatos.Columns[e.ColumnIndex].Name;

                if (columnasFormateadas.Contains(nombreColumna) && e.Value != null && e.Value is decimal)
                {
                    decimal valor = (decimal)e.Value;
                    e.Value = string.Format(new System.Globalization.CultureInfo("es-Hn"), "{0:C2}", valor);
                    e.FormattingApplied = true;
                }

            };
            this.dgvDatos2.CellFormatting += (sender, e) =>
            {
                var columnasFormateadas = new List<string> { "Cuota", "MontoPagado", "Saldo" };

                string nombreColumna = dgvDatos2.Columns[e.ColumnIndex].Name;

                if (columnasFormateadas.Contains(nombreColumna) && e.Value != null && e.Value is decimal)
                {
                    decimal valor = (decimal)e.Value;
                    e.Value = string.Format(new System.Globalization.CultureInfo("es-Hn"), "{0:C2}", valor);
                    e.FormattingApplied = true;
                }

            };
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Warning, btnRecordatorio);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Success, btnWhatsApp);
            dgvDatos.CellPainting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvDatos.Columns["Estado"].Index)
                {
                    e.Handled = true;
                    e.PaintBackground(e.CellBounds, true);

                    string estado = e.FormattedValue?.ToString() ?? "";
                    Color backColor = Color.Gray;
                    Color foreColor = Color.White;
                    //size

                    // Definir colores según el estado
                    if (estado == "Pagado")
                    {
                        backColor = Color.FromArgb(198, 239, 206);  // verde suave
                        foreColor = Color.FromArgb(0, 97, 0);        // verde oscuro
                    }
                    else if (estado == "Atrasado")
                    {
                        backColor = Color.FromArgb(255, 199, 206);  // rojo suave
                        foreColor = Color.FromArgb(156, 0, 6);       // rojo oscuro
                    }
                    else if (estado == "Pendiente")
                    {
                        backColor = ColorTranslator.FromHtml("#fde68a");
                        foreColor = ColorTranslator.FromHtml("#a5673f");
                    }
                    Font customFont = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size - 1 / 2, FontStyle.Regular);
                    Size textSize = TextRenderer.MeasureText(estado, customFont);

                    Rectangle rect = new Rectangle(
            e.CellBounds.X + 4,
                    e.CellBounds.Y + 2,
                        Math.Min(textSize.Width + 12, e.CellBounds.Width - 8),
            e.CellBounds.Height - 6
        );

                    using (GraphicsPath path = GetRoundedRectPath(rect, 16))
                    using (SolidBrush b = new SolidBrush(backColor))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(b, path);
                    }

                    TextRenderer.DrawText(
                    e.Graphics,
                    estado,
                    customFont,   // usar la fuente personalizada
                    rect,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );

                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
                }
            };
            dgvDatos2.CellPainting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvDatos2.Columns["Estado"].Index)
                {
                    e.Handled = true;
                    e.PaintBackground(e.CellBounds, true);

                    string estado = e.FormattedValue?.ToString() ?? "";
                    Color backColor = Color.Gray;
                    Color foreColor = Color.White;
                    //size

                    // Definir colores según el estado
                    if (estado == "Pagado")
                    {
                        backColor = Color.FromArgb(198, 239, 206);  // verde suave
                        foreColor = Color.FromArgb(0, 97, 0);        // verde oscuro
                    }
                    else if (estado == "Atrasado")
                    {
                        backColor = Color.FromArgb(255, 199, 206);  // rojo suave
                        foreColor = Color.FromArgb(156, 0, 6);       // rojo oscuro
                    }
                    else if (estado == "Pendiente")
                    {
                        backColor = ColorTranslator.FromHtml("#fde68a");
                        foreColor = ColorTranslator.FromHtml("#a5673f");
                    }
                    Font customFont = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size - 1 / 2, FontStyle.Regular);
                    Size textSize = TextRenderer.MeasureText(estado, customFont);
                    Rectangle rect = new Rectangle(
              e.CellBounds.X + 4,
              e.CellBounds.Y + 2,
Math.Min(textSize.Width + 12, e.CellBounds.Width - 8),
              e.CellBounds.Height - 6
                      );

                    using (GraphicsPath path = GetRoundedRectPath(rect, 16))
                    using (SolidBrush b = new SolidBrush(backColor))
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.FillPath(b, path);
                    }

                    TextRenderer.DrawText(
                    e.Graphics,
                    estado,
                    customFont,   // usar la fuente personalizada
                    rect,
                    foreColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );

                    e.Paint(e.CellBounds, DataGridViewPaintParts.Border);
                }
            };

        }
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private async void CargarDatos(DataGridView dataGridView)
        {
            try
            {

                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dataGridView, new object[] { true });

                dataGridView.SuspendLayout();
                dataGridView.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => reporteC.CargarClientesAtrasados());

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

                lblTotal.Text = $"Total: {dataGridView.Rows.Count.ToString()}";
                GraficarClientesAtrasadosPorMes(dataGridView, chart1);
            }
            AgregarBoton(dgvDatos);
        }
        public string SumaTotalCuota()
        {
            return dgvDatos2.Rows
                .Cast<DataGridViewRow>()
                .Sum(row => Convert.ToDouble(row.Cells["Cuota"].Value ?? 0))
                .ToString("N2");
        }
        private async void CargarCobros(DataGridView dataGridView)
        {
            try
            {

                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dataGridView, new object[] { true });

                dataGridView.SuspendLayout();
                dataGridView.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => reporteC.CargarCobrosMes());

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

                SumaTotalCuota();
                string text = label2.Text;
                label2.Text = $"{text} (L.{SumaTotalCuota()})";
            }
            AgregarBoton(dgvDatos2);
        }

        void AgregarBoton(DataGridView dgvDatos)
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
            colMixta.Text = "Seleccionar";
            colMixta.ToolTipText = "Seleccionar";
            colMixta.UseColumnTextForButtonValue = true; // Para que muestre el texto en cada botón

            // Agrega la columna al final
            dgvDatos.Columns.Add(colMixta);
            colMixta.DisplayIndex = dgvDatos.Columns.Count - 1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frmInicio formPrincipal = Application.OpenForms.OfType<frmInicio>().FirstOrDefault();

            // Si existe el formulario principal, mostrar su panel de inicio
            if (formPrincipal != null)
            {
                formPrincipal.loadform(new frmDashboard());
            }

            // Cerrar este formulario
            this.Close();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos.Rows[index].Selected = true;
            int Id = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdContrato"].Value.ToString());
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmRegistrarPago frm = new frmRegistrarPago(Id);
            //si exsite el boton
            if (e.ColumnIndex == dgvDatos.Columns["colMixta"].Index)
            {
                frmPrincipal.SetRutaText("Contrato / Tramites / Cobrar");
                frmPrincipal.loadform(frm);
            }
            btnRecordatorio.Visible = true;
        }
        public void GraficarClientesAtrasadosPorMes(DataGridView dataGridView1, Chart chart1)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());

            var ordenMeses = new Dictionary<string, int>
    {
        {"Enero", 1}, {"Febrero", 2}, {"Marzo", 3}, {"Abril", 4}, {"Mayo", 5}, {"Junio", 6},
        {"Julio", 7}, {"Agosto", 8}, {"Septiembre", 9}, {"Octubre", 10}, {"Noviembre", 11}, {"Diciembre", 12}
    };

            var colores = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown,
                               Color.Pink, Color.Gray, Color.Cyan, Color.Magenta, Color.Yellow, Color.Lime };

            var resultado = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["MesAtrasado"].Value != null && !row.IsNewRow)
                .GroupBy(row => row.Cells["MesAtrasado"].Value.ToString())
                .Select(g => new { Mes = g.Key, Cantidad = g.Count(), Orden = ordenMeses.ContainsKey(g.Key) ? ordenMeses[g.Key] : 99 })
                .OrderBy(x => x.Orden)
                .ToList();

            if (resultado.Any())
            {
                Series serie = new Series("Clientes Atrasados") { ChartType = SeriesChartType.Column };
                serie["PointWidth"] = "0.1";

                for (int i = 0; i < resultado.Count; i++)
                {
                    var item = resultado[i];
                    int index = serie.Points.AddXY(item.Mes, item.Cantidad);

                    serie.Points[index].Color = colores[i % colores.Length];
                    serie.Points[index].Label = item.Cantidad.ToString();
                    serie.Points[index].LabelForeColor = Color.White;
                    serie.Points[index].Font = new Font("Arial", 18, FontStyle.Bold);
                    serie["LabelStyle"] = "Bottom"; // Posición del texto (encima de la barra)
                }

                chart1.Series.Add(serie);
            }
        }

        private void dgvDatos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos2.Rows[index].Selected = true;
            int Id = int.Parse(dgvDatos2.Rows[e.RowIndex].Cells["IdContrato"].Value.ToString());
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmRegistrarPago frm = new frmRegistrarPago(Id);
            //si exsite el boton
            if (e.ColumnIndex == dgvDatos2.Columns["colMixta"].Index)
            {
                frmPrincipal.SetRutaText("Contrato / Tramites / Cobrar");
                frmPrincipal.loadform(frm);
            }
            btnWhatsApp.Visible = true;

        }

        private void dgvDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el DataGridView que generó el evento
                DataGridView dgv = sender as DataGridView;

                // Seleccionar la celda en la que se hizo clic derecho
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Crear el menú contextual
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                // Opción "Copiar"
                var copyCell = new ToolStripMenuItem("Copiar");
                copyCell.Click += (s, ev) =>
                {
                    if (dgv.SelectedCells.Count > 1)
                    {
                        // Copiar rango de celdas seleccionadas
                        StringBuilder sb = new StringBuilder();
                        int minRow = dgv.SelectedCells.Cast<DataGridViewCell>().Min(c => c.RowIndex);
                        int maxRow = dgv.SelectedCells.Cast<DataGridViewCell>().Max(c => c.RowIndex);
                        int minCol = dgv.SelectedCells.Cast<DataGridViewCell>().Min(c => c.ColumnIndex);
                        int maxCol = dgv.SelectedCells.Cast<DataGridViewCell>().Max(c => c.ColumnIndex);

                        for (int row = minRow; row <= maxRow; row++)
                        {
                            List<string> rowValues = new List<string>();
                            for (int col = minCol; col <= maxCol; col++)
                            {
                                var cell = dgv.Rows[row].Cells[col];
                                rowValues.Add(cell.Value?.ToString() ?? "");
                            }
                            sb.AppendLine(string.Join("\t", rowValues));
                        }

                        Clipboard.SetText(sb.ToString());
                    }
                    else if (dgv.CurrentCell != null && !dgv.CurrentCell.IsInEditMode)
                    {
                        Clipboard.SetText(dgv.CurrentCell.Value?.ToString());
                    }
                };
                contextMenu.Items.Add(copyCell);

                // Opción "Copiar toda la fila"
                var copyRow = new ToolStripMenuItem("Copiar fila");
                copyRow.Click += (s, ev) =>
                {
                    if (dgv.CurrentRow != null)
                    {
                        var row = dgv.CurrentRow;
                        string rowData = "";

                        // Concatenar los valores de todas las celdas de la fila
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                rowData += cell.Value.ToString() + "\t"; // Separador de tabulación
                            }
                        }

                        // Copiar al portapapeles
                        Clipboard.SetText(rowData.TrimEnd('\t'));
                    }
                };
                contextMenu.Items.Add(copyRow);

                // Opción "Copiar fila con encabezados"
                var copyRowWithHeaders = new ToolStripMenuItem("Copiar fila con encabezado");
                copyRowWithHeaders.Click += (s, ev) =>
                {
                    if (dgv.CurrentRow != null)
                    {
                        var row = dgv.CurrentRow;
                        StringBuilder sb = new StringBuilder();

                        // Agregar encabezados
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            sb.Append(column.HeaderText + "\t");
                        }
                        sb.AppendLine();

                        // Agregar valores de la fila
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sb.Append((cell.Value?.ToString() ?? "") + "\t");
                        }

                        // Copiar al portapapeles
                        Clipboard.SetText(sb.ToString().TrimEnd('\t'));
                    }
                };
                contextMenu.Items.Add(copyRowWithHeaders);

                // Mostrar el menú contextual en la posición del clic derecho
                contextMenu.Show(dgv, dgv.PointToClient(Control.MousePosition));
            }
        }

        private void dgvDatos2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el DataGridView que generó el evento
                DataGridView dgv = sender as DataGridView;

                // Seleccionar la celda en la que se hizo clic derecho
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Crear el menú contextual
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                // Opción "Copiar"
                var copyCell = new ToolStripMenuItem("Copiar");
                copyCell.Click += (s, ev) =>
                {
                    if (dgv.SelectedCells.Count > 1)
                    {
                        // Copiar rango de celdas seleccionadas
                        StringBuilder sb = new StringBuilder();
                        int minRow = dgv.SelectedCells.Cast<DataGridViewCell>().Min(c => c.RowIndex);
                        int maxRow = dgv.SelectedCells.Cast<DataGridViewCell>().Max(c => c.RowIndex);
                        int minCol = dgv.SelectedCells.Cast<DataGridViewCell>().Min(c => c.ColumnIndex);
                        int maxCol = dgv.SelectedCells.Cast<DataGridViewCell>().Max(c => c.ColumnIndex);

                        for (int row = minRow; row <= maxRow; row++)
                        {
                            List<string> rowValues = new List<string>();
                            for (int col = minCol; col <= maxCol; col++)
                            {
                                var cell = dgv.Rows[row].Cells[col];
                                rowValues.Add(cell.Value?.ToString() ?? "");
                            }
                            sb.AppendLine(string.Join("\t", rowValues));
                        }

                        Clipboard.SetText(sb.ToString());

                    }
                    else if (dgv.CurrentCell != null && !dgv.CurrentCell.IsInEditMode)
                    {
                        Clipboard.SetText(dgv.CurrentCell.Value?.ToString());
                    }
                };
                contextMenu.Items.Add(copyCell);

                // Opción "Copiar toda la fila"
                var copyRow = new ToolStripMenuItem("Copiar fila");
                copyRow.Click += (s, ev) =>
                {
                    if (dgv.CurrentRow != null)
                    {
                        var row = dgv.CurrentRow;
                        string rowData = "";

                        // Concatenar los valores de todas las celdas de la fila
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                rowData += cell.Value.ToString() + "\t"; // Separador de tabulación
                            }
                        }

                        // Copiar al portapapeles
                        Clipboard.SetText(rowData.TrimEnd('\t'));

                    }
                };
                contextMenu.Items.Add(copyRow);

                // Opción "Copiar fila con encabezados"
                var copyRowWithHeaders = new ToolStripMenuItem("Copiar fila con encabezado");
                copyRowWithHeaders.Click += (s, ev) =>
                {
                    if (dgv.CurrentRow != null)
                    {
                        var row = dgv.CurrentRow;
                        StringBuilder sb = new StringBuilder();

                        // Agregar encabezados
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            sb.Append(column.HeaderText + "\t");
                        }
                        sb.AppendLine();

                        // Agregar valores de la fila
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sb.Append((cell.Value?.ToString() ?? "") + "\t");
                        }

                        // Copiar al portapapeles
                        Clipboard.SetText(sb.ToString().TrimEnd('\t'));

                    }
                };
                contextMenu.Items.Add(copyRowWithHeaders);



                // Mostrar el menú contextual en la posición del clic derecho
                contextMenu.Show(dgv, dgv.PointToClient(Control.MousePosition));
            }
        }

        private void btnRecordatorio_Click(object sender, EventArgs e)
        {
            try
            {
                string cliente = dgvDatos.SelectedRows[0].Cells[3].Value.ToString();
                string cuota = dgvDatos.SelectedRows[0].Cells[6].Value.ToString();
                string fecha = Convert.ToDateTime(dgvDatos.SelectedRows[0].Cells[5].Value.ToString().ToString()).ToShortDateString();
                string residencial = "Residencial El Ciprés";
                string cuenta = "21-602-032425-0 Luis Gerardo Guevara";

                string mensaje = $"Estimado/a {cliente} recordarle que tiene un pago de L.{Convert.ToDouble(cuota).ToString("N2")} pendiente a su terreno en {residencial}. La Fecha de pago fue {fecha}. La cuenta a depositar es {cuenta}. Administrador General. Saludos.";
                MostrarRecordatorio($"{mensaje}");


            }
            catch
            {
                return;
            }


        }
        private void MostrarRecordatorio(string mensaje)
        {
            Form frm = new Form
            {
                Text = "Recordatorio",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                Size = new System.Drawing.Size(400, 300),
                MaximizeBox = false,
                MinimizeBox = false,
                Padding = new Padding(5),
            };

            TextBox txt = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Text = mensaje,
                ScrollBars = ScrollBars.Both,
                BackColor = Color.White,
                Font = new Font("Arial", 11.5F)
            };

            IconButton btn = new IconButton
            {
                Text = "Copiar",
                Dock = DockStyle.Bottom,
                Height = 40,
                IconSize = 28,
                IconChar = FontAwesome.Sharp.IconChar.Copy,
                IconColor = Color.White,
                TextAlign = ContentAlignment.MiddleRight,
                UseVisualStyleBackColor = true,
                TextImageRelation = TextImageRelation.ImageBeforeText,

            };

            btn.Click += (s, e) =>
            {
                Clipboard.SetText(txt.Text);
                new MiniToast().Show(MiniToast.ToastType.Success, "Copiado", frm);
            };
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btn);
            frm.Controls.Add(txt);
            frm.Controls.Add(btn);
            frm.ShowDialog();
        }

        public void NotifyWhatsapp(string numero, string mensaje)
        {


            // Codificar el mensaje para que funcione en URL
            string mensajeCodificado = HttpUtility.UrlEncode(mensaje);

            // Crear la URL de WhatsApp Web con el número y el mensaje
            string url = $"https://wa.me/{numero.Replace("+", "")}?text={mensajeCodificado}";

            // Abrir el navegador con la URL
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void btnWhatsApp_Click(object sender, EventArgs e)
        {
            string cliente = dgvDatos2.SelectedRows[0].Cells[3].Value.ToString();
            string telefono = dgvDatos2.SelectedRows[0].Cells[2].Value.ToString();
            string fecha = dgvDatos2.SelectedRows[0].Cells[6].Value.ToString();
            string cuota = dgvDatos2.SelectedRows[0].Cells[7].Value.ToString();
            string mensaje = $"Estimado/a *{cliente}*, le recordamos amablemente que el día *{Convert.ToDateTime(fecha).ToShortDateString()}* corresponde la cancelación de su cuota de *L.{cuota}* por concepto de terreno. El pago puede realizarse a la cuenta *21-602-032425-0* a nombre de *Luis Gerardo Guevara*. Agradecemos su atención y cumplimiento. Saludos cordiales.";
            DialogResult result = CustomAlert.ShowConfirm(AlertType.Info, "Mensaje", "¿Enviar recordatorio por WhatsApp?");

            if (result == DialogResult.OK)
            {


                NotifyWhatsapp(telefono, mensaje);
            }
            else
            {
                MostrarRecordatorio(mensaje);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                dgvDatos.ClearSelection();
                dgvDatos2.ClearSelection();
                btnRecordatorio.Visible = false;
                btnWhatsApp.Visible = false;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}