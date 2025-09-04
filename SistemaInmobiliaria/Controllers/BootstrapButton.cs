using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{
    internal class BootstrapButton
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

        [DllImport("gdi32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public static void AplicarEstiloBootstrap(ButtonType type, Button boton)
        {
            int radio = 6; // Aumentamos el radio para bordes más suaves (Bootstrap usa ~6px)

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



    }
}
