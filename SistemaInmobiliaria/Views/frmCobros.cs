using FontAwesome.Sharp;
using Newtonsoft.Json.Linq;
using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmCobros : Form
    {
        SettingController settingC = new SettingController();
        ReporteController reporteC = new ReporteController();
        public frmCobros()
        {
            InitializeComponent();
            CargarCobros(dgvDatos2);
            BootstrapStyler.ApplyBootstrapStyle(txtFiltrar);

            PlaceholderController.SetPlaceholder(txtFiltrar, "Ingresa una opcion para filtrar", 25, 0);

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

            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Success, btnWhatsApp);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnEjecutar);
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
            dgvDatos2.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && dgvDatos2.Columns[e.ColumnIndex].Name == "colMixta" && e.RowIndex >= 0)
                {
                    // Pinta el fondo y bordes de la celda
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    // Carga la imagen solid
                    Image img = IconChar.Check.ToBitmap(20, 20, Color.Black);

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
                frmPrincipal.loadform(frm, "frmCobros");
            }
            btnWhatsApp.Visible = true;
        }

        private void btnWhatsApp_Click(object sender, EventArgs e)
        {
            try
            {
                string cliente = dgvDatos2.SelectedRows[0].Cells[3].Value.ToString();
                string telefono = dgvDatos2.SelectedRows[0].Cells[2].Value.ToString();
                string fecha = dgvDatos2.SelectedRows[0].Cells[6].Value.ToString();
                string cuota = dgvDatos2.SelectedRows[0].Cells[7].Value.ToString();
                string lote = dgvDatos2.SelectedRows[0].Cells[10].Value.ToString();
                string jsonString = File.ReadAllText(@"C:\Data\settings.json");

                var jsonObj = JObject.Parse(jsonString);
                string plantilla = jsonObj["MensajeW"]?.ToString() ?? "";

                // Diccionario de valores
                var valores = new Dictionary<string, string>
{
    { "[Cliente]", cliente },
    { "[Fecha]", Convert.ToDateTime(fecha).ToShortDateString() },
    { "[Cuota]", Convert.ToDouble(cuota).ToString("N2") },
    { "[Lote]", lote }

};

                DialogResult result = MessageBox.Show("¿Desea enviar el recordatorio por WhatsApp?", "Recordatorio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                // Reemplazar dinámicamente
                foreach (var kvp in valores)
                {
                    plantilla = plantilla.Replace(kvp.Key, kvp.Value);
                }

                string mensaje = plantilla;

                if (result == DialogResult.OK)
                {


                    NotifyWhatsapp(telefono, mensaje);
                }
                else
                {
                    MostrarRecordatorio(mensaje);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void FiltrarDataGridView(string filtro)
        {
            filtro = filtro.Trim().ToLower();

            // Si no hay filtro, mostramos todo
            if (string.IsNullOrEmpty(filtro))
            {
                foreach (DataGridViewRow row in dgvDatos2.Rows)
                {
                    if (!row.IsNewRow)
                        row.Visible = true;
                }
                return;
            }

            // Si la fila actual va a quedar oculta, quitamos selección antes
            dgvDatos2.CurrentCell = null;

            foreach (DataGridViewRow row in dgvDatos2.Rows)
            {
                if (row.IsNewRow) continue;

                bool coincide = row.Cells.Cast<DataGridViewCell>()
                    .Any(c => c.Value != null &&
                              c.Value.ToString().ToLower().Contains(filtro));

                row.Visible = coincide;
                label1.Visible = true;
                label1.Text = $"L.{dgvDatos2.Rows.Cast<DataGridViewRow>().Where(r => r.Visible).Sum(r => Convert.ToDouble(r.Cells[7].Value)).ToString("N2", new CultureInfo("es-HN"))}";

            }
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltrar.Text;
            FiltrarDataGridView(filtro);
        }
        private void FiltrarDataGridViewPorFechas(DateTime fechaInicio, DateTime fechaFin, int columnaFecha = 0)
        {
            // Quitar selección actual para evitar errores con filas ocultas
            dgvDatos2.CurrentCell = null;

            foreach (DataGridViewRow row in dgvDatos2.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = false;

                // Asegúrate de que la celda no sea null
                if (row.Cells[columnaFecha].Value != null)
                {
                    DateTime fecha;
                    // Intentamos convertir la celda a fecha
                    if (DateTime.TryParse(row.Cells[columnaFecha].Value.ToString(), out fecha))
                    {
                        // Si está dentro del rango, la mostramos
                        if (fecha >= fechaInicio && fecha <= fechaFin)
                        {
                            visible = true;
                        }
                    }
                }

                row.Visible = visible;
                label1.Visible = true;
                //sumar total de columna cuota filtrada por fechas
                label1.Text = $"L.{dgvDatos2.Rows.Cast<DataGridViewRow>().Where(r => r.Visible).Sum(r => Convert.ToDouble(r.Cells[7].Value)).ToString("N2", new CultureInfo("es-HN"))}";


            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            FiltrarDataGridViewPorFechas(dtpInicio.Value, dtpFinal.Value, 6);
        }

        private void iconButton1_Click(object sender, EventArgs e)
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
    }
}
