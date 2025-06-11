using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SistemaInmobiliaria.Controllers
{
    public static class BootstrapStyler
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);


        public static void ApplyBootstrapStyle(TextBox textBox)
        {
            textBox.Multiline = true;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Height = 35;
            //mantener en la misma posicion
            int y = textBox.Location.Y;
            int x = textBox.Location.X;
            textBox.Location = new Point(x, y);
            textBox.Font = new Font("Segoe UI", 11.75F, FontStyle.Regular, GraphicsUnit.Point);




            SetPadding(textBox);
            TextBoxIndent.AplicarIndentacionVisual(textBox, 10);
            textBox.Enter += (s, e) => textBox.Parent?.Invalidate();
            textBox.Leave += (s, e) => textBox.Parent?.Invalidate();


            if (textBox.Parent != null)
                textBox.Parent.Paint += (s, e) => PaintTextBoxBorder(textBox, e.Graphics);


        }


        private static void PaintTextBoxBorder(TextBox textBox, Graphics g)
        {
            if (!textBox.Visible) return;

            bool isFocused = textBox.Focused;

            // 1. Ocultar el borde FixedSingle nativo pintándolo del color del fondo
            using (var borderOverlayBrush = new SolidBrush(textBox.BackColor))
            {
                // Área exterior del TextBox (donde está el borde FixedSingle)
                g.FillRectangle(borderOverlayBrush,
                    textBox.Left - 1,
                    textBox.Top - 1,
                    textBox.Width + 2,
                    textBox.Height + 2);
            }

            // 2. Dibujar el fondo del TextBox (para tapar completamente el borde nativo)
            using (var bgBrush = new SolidBrush(textBox.BackColor))
            {
                g.FillRectangle(bgBrush,
                    textBox.Left,
                    textBox.Top,
                    textBox.Width,
                    textBox.Height);
            }

            // 3. Ahora dibujamos nuestro borde personalizado estilo Bootstrap
            Rectangle borderRect = new Rectangle(
                textBox.Left - 1,
                textBox.Top - 1,
                textBox.Width + 1,
                textBox.Height + 1
            );

            Color borderColor = isFocused ? Color.FromArgb(128, 189, 255) : Color.FromArgb(206, 212, 218);

            SmoothingMode original = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (isFocused)
            {
                Rectangle shadowRect = new Rectangle(
                    borderRect.X - 3,
                    borderRect.Y - 3,
                    borderRect.Width + 6,
                    borderRect.Height + 6
                );

                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(64, 0, 123, 255)))
                    g.FillRectangle(shadowBrush, shadowRect);
            }

            using (Pen borderPen = new Pen(borderColor, 1))
                g.DrawRectangle(borderPen, borderRect);

            g.SmoothingMode = original;
        }
        private const int EM_SETRECT = 0xB3;

        [DllImport(@"User32.dll", EntryPoint = @"SendMessage", CharSet = CharSet.Auto)]
        private static extern int SendMessageRefRect(IntPtr hWnd, uint msg, int wParam, ref RECT rect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }
        }

        public static void SetPadding(TextBox textBox)
        {
            textBox.Height = 35;

            // Calculamos la altura del texto usando la fuente del TextBox
            using (Graphics g = textBox.CreateGraphics())
            {
                SizeF textSize = g.MeasureString("Text", textBox.Font);
                int verticalPadding = (int)((textBox.ClientSize.Height - textSize.Height) / 2);

                // Evitamos valores negativos por si el texto es más grande que el TextBox
                verticalPadding = Math.Max(0, verticalPadding);

                var rect = new Rectangle(
                    4, // padding izquierdo
                    verticalPadding,
                    textBox.ClientSize.Width - 4,
                    textBox.ClientSize.Height - verticalPadding);

                RECT rc = new RECT(rect);
                SendMessageRefRect(textBox.Handle, EM_SETRECT, 0, ref rc);
            }

            textBox.Invalidate();
        }


    }
}
