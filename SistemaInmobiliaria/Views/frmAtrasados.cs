using FontAwesome.Sharp;
using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaInmobiliaria.Views
{
    public partial class frmAtrasados : Form
    {
        ReporteController reporteC = new ReporteController();
        SettingController settingC = new SettingController();
        public frmAtrasados()
        {
            InitializeComponent();
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Warning, btnRecordatorio);
            CargarDatos(dgvDatos);

            this.Resize += (s, e) =>
            {

                label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
            };


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

        public DataGridView GetDataGridView()
        {
            return dgvDatos;
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

            }
            AgregarBoton(dgvDatos);
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                dgvDatos.ClearSelection();
                //dgvDatos2.ClearSelection();
                btnRecordatorio.Visible = false;
                //btnWhatsApp.Visible = false;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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
    }
}
