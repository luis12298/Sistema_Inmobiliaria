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

        public enum ButtonSize
        {
            Small,      // btn-sm
            Normal,     // btn (default)
            Large       // btn-lg
        }

        [DllImport("gdi32.dll")]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public static void AplicarEstiloBootstrap(ButtonType type, Button boton, ButtonSize size = ButtonSize.Normal)
        {
            // Configuración de estilo base
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;

            // Configurar fuente y padding según el tamaño
            ConfigurarTamano(boton, size);

            // Aplicar colores según el tipo
            AplicarColores(boton, type);

            // Habilitar doble buffer para reducir el parpadeo
            typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance)?.SetValue(boton, true, null);

            // Configurar región redondeada inicial
            ActualizarRegionRedondeada(boton);

            // Manejar redimensionamiento
            boton.Resize += (sender, e) => ActualizarRegionRedondeada(boton);
        }

        private static void ConfigurarTamano(Button boton, ButtonSize size)
        {
            switch (size)
            {
                case ButtonSize.Small:
                    boton.Font = new Font("Segoe UI", 8.75f, FontStyle.Regular, GraphicsUnit.Point, 0, true);

                    boton.MinimumSize = new Size(0, 24); // Bootstrap btn-sm min-height
                    break;

                case ButtonSize.Normal:
                    boton.Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, 0, true);

                    boton.MinimumSize = new Size(0, 32); // Bootstrap btn min-height
                    break;

                case ButtonSize.Large:
                    boton.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0, true);

                    boton.MinimumSize = new Size(0, 40); // Bootstrap btn-lg min-height
                    break;
            }
        }

        private static void AplicarColores(Button boton, ButtonType type)
        {
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
        }

        public static void ActualizarRegionRedondeada(Control control)
        {
            int radio = CalcularRadioBorder(control);

            if (radio <= 0)
            {
                // Si el radio es 0 o negativo, usar región rectangular
                if (control.Region != null)
                {
                    control.Region.Dispose();
                    control.Region = null;
                }
                return;
            }

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

        private static int CalcularRadioBorder(Control control)
        {
            // Bootstrap usa border-radius: 0.375rem (6px) como estándar
            const int radioPorDefecto = 4;
            const int radioMinimo = 2;

            // Para botones muy pequeños, reducir el radio proporcionalmente
            // Bootstrap también reduce el radio en componentes pequeños
            int alturaMinima = 20; // Altura mínima para radio completo

            if (control.Height < alturaMinima)
            {
                // Calcular radio proporcional: entre 2px y 6px basado en la altura
                double factor = (double)control.Height / alturaMinima;
                int radioCalculado = (int)Math.Round(radioPorDefecto * factor);

                // Asegurar que esté entre el mínimo y el máximo
                return Math.Max(radioMinimo, Math.Min(radioCalculado, radioPorDefecto));
            }

            // Para botones muy anchos pero bajos, limitar el radio a la mitad de la altura
            int radioMaximoPorAltura = control.Height / 2;

            return Math.Min(radioPorDefecto, radioMaximoPorAltura);
        }

        // Método de conveniencia para aplicar estilo rápidamente
        public static void AplicarPrimary(Button boton) => AplicarEstiloBootstrap(ButtonType.Primary, boton);
        public static void AplicarSecondary(Button boton) => AplicarEstiloBootstrap(ButtonType.Secondary, boton);
        public static void AplicarSuccess(Button boton) => AplicarEstiloBootstrap(ButtonType.Success, boton);
        public static void AplicarDanger(Button boton) => AplicarEstiloBootstrap(ButtonType.Danger, boton);
        public static void AplicarWarning(Button boton) => AplicarEstiloBootstrap(ButtonType.Warning, boton);
        public static void AplicarInfo(Button boton) => AplicarEstiloBootstrap(ButtonType.Info, boton);
        public static void AplicarLight(Button boton) => AplicarEstiloBootstrap(ButtonType.Light, boton);
        public static void AplicarDark(Button boton) => AplicarEstiloBootstrap(ButtonType.Dark, boton);
    }
}