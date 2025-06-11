using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
            // Desactivar la actualización visual para mejorar el rendimiento
            dgvDatos.SuspendLayout();

            try
            {
                using (Graphics g = dgvDatos.CreateGraphics())
                {
                    foreach (DataGridViewColumn col in dgvDatos.Columns)
                    {
                        col.ReadOnly = true;

                        // Obtener el ancho del texto más largo en la columna
                        float maxWidth = g.MeasureString(col.HeaderText, dgvDatos.Font).Width;

                        // Recorrer las filas visibles para encontrar el texto más ancho
                        foreach (DataGridViewRow row in dgvDatos.Rows)
                        {
                            if (row.Cells[col.Index].Value != null)
                            {
                                float textWidth = g.MeasureString(row.Cells[col.Index].Value.ToString(), dgvDatos.Font).Width;
                                if (textWidth > maxWidth)
                                {
                                    maxWidth = textWidth;
                                }
                            }
                        }

                        // Ajustar el ancho de la columna sumando un pequeño margen
                        col.Width = (int)maxWidth + 50;
                    }
                }

                // Ajustar la última columna para que ocupe el espacio restante
                if (dgvDatos.Columns.Count > 0)
                {
                    dgvDatos.Columns[dgvDatos.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            finally
            {
                // Reactivar la actualización visual
                dgvDatos.ResumeLayout();
            }

            // Evitar que se agreguen filas manualmente
            dgvDatos.AllowUserToAddRows = false;

            // Aumentar la altura de los encabezados
            dgvDatos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDatos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            // **Aumentar aún más la altura de los encabezados**
            dgvDatos.ColumnHeadersHeight = 45; // Puedes cambiar a un valor mayor si lo deseas
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
                    boton.BackColor = Color.FromArgb(13, 110, 253);
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(11, 94, 215);
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(11, 94, 215);
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Secondary:
                    boton.BackColor = Color.FromArgb(108, 117, 125);
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(108, 117, 125);
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(92, 99, 106);
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Success:
                    boton.BackColor = Color.FromArgb(25, 135, 84);
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 115, 71);
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(21, 115, 71);
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Danger:
                    boton.BackColor = Color.FromArgb(220, 53, 69);
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(187, 45, 59);
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(187, 45, 59);
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Warning:
                    boton.BackColor = Color.FromArgb(255, 193, 7);
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 202, 44);
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 202, 44);
                    boton.ForeColor = Color.Black;
                    break;
                case ButtonType.Info:
                    boton.BackColor = Color.FromArgb(13, 202, 240);
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(49, 210, 242);
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 210, 242);
                    boton.ForeColor = Color.White;
                    break;
                case ButtonType.Light:
                    boton.BackColor = Color.FromArgb(248, 249, 250);
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(249, 250, 251);
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(249, 250, 251);
                    boton.ForeColor = Color.Black;
                    break;
                case ButtonType.Dark:
                    boton.BackColor = Color.FromArgb(33, 37, 41);
                    boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(28, 31, 35);
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 31, 35);
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

        private static void ActualizarRegionRedondeada(Control control, int radio)
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




    }
}
