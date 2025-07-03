using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace SistemaInmobiliaria.Controllers
{
    internal class SettingController
    {
        public enum ButtonType
        {
            Primary,
            Secondary,
            Success,
            Danger,
            Warning,
            Info,
            Light,
            Dark
        }
        public void AjustarColumnas(DataGridView dgvDatos)
        {
            dgvDatos.SuspendLayout();

            // Configuración general
            dgvDatos.ReadOnly = true; // Hace todas las celdas de solo lectura de una vez
            dgvDatos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDatos.Font.FontFamily, 10.5f, FontStyle.Bold);
            dgvDatos.EnableHeadersVisualStyles = false;
            dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToOrderColumns = false;
            dgvDatos.AllowUserToResizeRows = false;
            dgvDatos.ColumnHeadersHeight = 45;
            dgvDatos.ScrollBars = ScrollBars.Both;

            // Ajuste de columnas (optimizado)
            foreach (DataGridViewColumn column in dgvDatos.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            // Ajustar la última columna para que ocupe el espacio restante
            if (dgvDatos.Columns.Count > 0)
            {
                dgvDatos.Columns[dgvDatos.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgvDatos.ResumeLayout();
        }

        public void AjustarColumnas(ListView listView)
        {
            if (listView.Columns.Count == 0) return;

            using (Graphics g = listView.CreateGraphics())
            {
                int totalWidth = 0;

                for (int i = 0; i < listView.Columns.Count; i++)
                {
                    ColumnHeader col = listView.Columns[i];
                    float maxWidth = g.MeasureString(col.Text, listView.Font).Width;

                    foreach (ListViewItem item in listView.Items)
                    {
                        string text;

                        // Protección contra subíndices inválidos
                        if (i == 0)
                        {
                            text = item.Text;
                        }
                        else if (item.SubItems.Count > i && item.SubItems[i] != null)
                        {
                            text = item.SubItems[i].Text;
                        }
                        else
                        {
                            text = string.Empty; // valor por defecto
                        }

                        float textWidth = g.MeasureString(text, listView.Font).Width;

                        if (textWidth > maxWidth)
                            maxWidth = textWidth;
                    }

                    // Ajuste con margen
                    int finalWidth = (int)Math.Ceiling(maxWidth) + 20;

                    // Si es la última columna, ajustar al ancho restante
                    if (i == listView.Columns.Count - 1)
                    {
                        int espacioRestante = listView.ClientSize.Width - totalWidth;
                        finalWidth = Math.Max(finalWidth, espacioRestante);
                    }

                    col.Width = finalWidth;
                    totalWidth += finalWidth;
                }
            }
        }

        [DllImport("gdi32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public static void AplicarEstiloBootstrap(ButtonType type, Button boton)
        {
            int radio = 0; // Aumentamos el radio para bordes más suaves (Bootstrap usa ~6px)
            if (boton.Width <= 40) radio = 10;
            if (boton.Width > 40 && boton.Width <= 80) radio = 6;
            if (boton.Width > 80) radio = 3;
            // Configuración de estilo base
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = new Font("Segoe UI", 10, FontStyle.Regular, GraphicsUnit.Point, 0, true); // Mejor renderizado de texto
            boton.Cursor = Cursors.Hand;
            //Segun el parametro colores de boostrap 
            //Primary,
            //Secondary,
            //Success,
            //Danger,
            //Warning,
            //Info,
            //Light,
            //Dark
            switch (type)
            {
                case ButtonType.Primary:
                    boton.BackColor = ColorTranslator.FromHtml("#007bff");
                    boton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#0069d9");
                    boton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#0069d9");
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Secondary:
                    boton.BackColor = ColorTranslator.FromHtml("#6c757d");
                    boton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#545b62");
                    boton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#545b62");
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Success:
                    boton.BackColor = ColorTranslator.FromHtml("#28a745");
                    boton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#1e7e34");
                    boton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1e7e34");
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Danger:
                    boton.BackColor = ColorTranslator.FromHtml("#dc3545");
                    boton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#bd2130");
                    boton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#bd2130");
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Warning:
                    boton.BackColor = ColorTranslator.FromHtml("#ffc107");
                    boton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#d39e00");
                    boton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#d39e00");
                    boton.ForeColor = Color.Black;
                    break;
                case ButtonType.Info:
                    boton.BackColor = ColorTranslator.FromHtml("#17a2b8");
                    boton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#138496");
                    boton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#138496");
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Light:
                    boton.BackColor = ColorTranslator.FromHtml("#f8f9fa");
                    boton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#e2e6ea");
                    boton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#e2e6ea");
                    boton.ForeColor = Color.Black;
                    break;
                case ButtonType.Dark:
                    boton.BackColor = ColorTranslator.FromHtml("#343a40");
                    boton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#1d2124");
                    boton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#1d2124");
                    boton.ForeColor = Color.White;
                    break;
                default:
                    boton.BackColor = Color.FromArgb(108, 117, 125);
                    boton.ForeColor = Color.White;
                    break;
            }
            // Habilitar doble buffer para reducir el parpadeo
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance).SetValue(boton, true, null);

            // Configurar región redondeada
            ActualizarRegionRedondeada(boton, radio);

            // Redimensionamiento
            boton.Resize += (sender, e) => ActualizarRegionRedondeada(boton, radio);


        }

        public static void ActualizarRegionRedondeada(Control control, int radio)
        {
            IntPtr regionPtr = CreateRoundRectRgn(0, 0, control.Width + 1, control.Height + 1, radio * 2, radio * 2);

            // Liberar la región anterior si existe
            if (control.Region != null)
            {
                control.Region.Dispose();
            }

            // Crear nueva región
            control.Region = Region.FromHrgn(regionPtr);

            // Forzar redibujado
            control.Invalidate();
        }


        private ProgressBar progressBar;
        private Label labelStatus;
        private Panel panelProgress; // Panel contenedor para mayor control
        private Timer progressTimer;
        private int puntoCount = 0;
        private bool isWorking = false;

        // MÉTODO ÚNICO - Solo llamas este método: MostrarTrabajando()
        public async void MostrarTrabajando(Form form)
        {
            try
            {
                if (isWorking) return;
                isWorking = true;

                // Crear panel contenedor si no existe
                if (panelProgress == null)
                {
                    panelProgress = new Panel();
                    panelProgress.Size = new System.Drawing.Size(300, 100); // Tamaño fijo para el panel
                    panelProgress.Location = new System.Drawing.Point(
                        (form.ClientSize.Width - 300) / 2,
                        (form.ClientSize.Height - 100) / 2); // Centrado en la pantalla
                    panelProgress.BackColor = Color.FromArgb(200, Color.White); // Semitransparente
                    panelProgress.BorderStyle = BorderStyle.None;
                    panelProgress.Anchor = AnchorStyles.None; // Sin anclaje para mantenerlo centrado
                    form.Controls.Add(panelProgress);
                }

                // Crear ProgressBar si no existe
                if (progressBar == null)
                {
                    progressBar = new ProgressBar();
                    progressBar.Style = ProgressBarStyle.Marquee;
                    progressBar.MarqueeAnimationSpeed = 30;
                    progressBar.Size = new System.Drawing.Size(260, 25);
                    progressBar.Location = new System.Drawing.Point(20, 60); // Centrado en el panel
                    panelProgress.Controls.Add(progressBar);
                }

                // Crear Label si no existe
                if (labelStatus == null)
                {
                    labelStatus = new Label();
                    labelStatus.Size = new System.Drawing.Size(260, 25);
                    labelStatus.Location = new System.Drawing.Point(20, 20); // Arriba del ProgressBar
                    labelStatus.TextAlign = ContentAlignment.MiddleCenter;
                    labelStatus.Font = new System.Drawing.Font("Arial", 10);
                    panelProgress.Controls.Add(labelStatus);
                }

                // Crear Timer si no existe
                if (progressTimer == null)
                {
                    progressTimer = new Timer();
                    progressTimer.Interval = 500;
                    progressTimer.Tick += (s, e) =>
                    {
                        puntoCount = (puntoCount + 1) % 4;
                        string puntos = new string('.', puntoCount);
                        labelStatus.Text = $"Trabajando{puntos}";
                    };
                }

                // Ajustar posición del panel si el formulario cambia de tamaño
                form.Resize += (s, e) =>
                {
                    if (panelProgress != null)
                    {
                        panelProgress.Location = new System.Drawing.Point(
                            (form.ClientSize.Width - panelProgress.Width) / 2,
                            (form.ClientSize.Height - panelProgress.Height) / 2);
                    }
                };

                // Mostrar elementos y traer al frente
                panelProgress.Visible = true;
                panelProgress.BringToFront();
                progressTimer.Start();

                // Deshabilitar todos los controles excepto el panel
                foreach (Control control in form.Controls)
                {
                    if (control != panelProgress)
                        control.Enabled = false;
                }

                // Simular tarea
                Random random = new Random();
                int tiempoTrabajo = random.Next(1000, 10000);
                await Task.Delay(tiempoTrabajo);

                // Aquí tu lógica real
            }
            finally
            {
                // Limpiar al final
                progressTimer?.Stop();
                panelProgress?.SendToBack();
                panelProgress.Visible = false;

                foreach (Control control in form.Controls)
                {
                    control.Enabled = true;
                }

                isWorking = false;
            }
        }

    }
}
