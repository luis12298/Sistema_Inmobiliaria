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

        public static void ApplyBootstrapStyle(TextBox textBox, int paddingTop = -1)
        {
            textBox.Multiline = true;
            textBox.BorderStyle = BorderStyle.None;
            textBox.Height = 35;

            int y = textBox.Location.Y;
            int x = textBox.Location.X;
            textBox.Location = new Point(x, y);
            textBox.Font = new Font("Segoe UI", 10.75F, FontStyle.Regular, GraphicsUnit.Point, 0);

            // Aplicar redondeo
            RedondearTextBox(textBox, 10);
            if (paddingTop <= 0) paddingTop = 2;
            CenterTextBoxCursorVertically(textBox, 4, 1);

            textBox.Enter += (s, e) =>
            {
                textBox.Parent?.Invalidate();
            };
            textBox.Leave += (s, e) =>
            {
                textBox.Parent?.Invalidate();
            };

            textBox.LocationChanged += (s, e) => textBox.Parent?.Invalidate();
            textBox.SizeChanged += (s, e) => textBox.Parent?.Invalidate();

            if (textBox.Parent != null)
            {
                textBox.Parent.Paint += (s, e) => PaintTextBoxBorder(textBox, e.Graphics);
                textBox.Parent.Invalidate();
            }

            // 🔥 Forzar que el efecto se dibuje si ya está en Focus
            if (textBox.Focused)
                textBox.Parent?.Invalidate();
        }


        private static void PaintTextBoxBorder(TextBox textBox, Graphics g)
        {
            if (!textBox.Visible) return;

            bool isFocused = textBox.Focused;
            const int borderRadius = 6;

            Rectangle textBoxRect = new Rectangle(textBox.Left, textBox.Top, textBox.Width, textBox.Height);
            Rectangle borderRect = new Rectangle(textBox.Left - 1, textBox.Top - 1, textBox.Width + 2, textBox.Height + 2);

            SmoothingMode original = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Limpiar alrededor del TextBox
            using (GraphicsPath clearPath = GetRoundPath(
                new RectangleF(borderRect.X - 2, borderRect.Y - 2, borderRect.Width + 4, borderRect.Height + 4),
                borderRadius + 10))
            using (SolidBrush clearBrush = new SolidBrush(textBox.Parent.BackColor))
            {
                g.FillPath(clearBrush, clearPath);
            }

            // Glow cuando está enfocado
            if (isFocused)
            {
                for (int i = 5; i >= 1; i--)
                {
                    int safeRadiusGlow = Math.Min(4 + i, Math.Min(textBox.Width / 2, textBox.Height / 2));
                    Rectangle shadowRect = new Rectangle(
                        borderRect.X - i,
                        borderRect.Y - i,
                        borderRect.Width + (i * 2),
                        borderRect.Height + (i * 2)
                    );

                    using (GraphicsPath shadowPath = GetRoundPath(shadowRect, safeRadiusGlow))
                    using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(194, 219, 253))) // Color Bootstrap original
                    {
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }
            }

            // Fondo del TextBox
            using (GraphicsPath bgPath = GetRoundPath(
                new RectangleF(textBoxRect.X - 0.5f, textBoxRect.Y - 0.5f, textBoxRect.Width + 1f, textBoxRect.Height + 1f),
                borderRadius))
            using (SolidBrush bgBrush = new SolidBrush(textBox.BackColor))
            {
                g.FillPath(bgBrush, bgPath);
            }

            // Color del borde
            Color borderColor = isFocused ? Color.FromArgb(128, 189, 255) : Color.FromArgb(206, 212, 218);

            // Borde redondeado
            using (GraphicsPath borderPath = GetRoundPath(
                new RectangleF(borderRect.X, borderRect.Y, borderRect.Width, borderRect.Height),
                borderRadius))
            using (Pen borderPen = new Pen(borderColor, isFocused ? 1.5f : 1f))
            {
                borderPen.Alignment = PenAlignment.Inset;
                g.DrawPath(borderPen, borderPath);
            }

            g.SmoothingMode = original;
        }

        public static void RedondearTextBox(TextBox txt, int radio)
        {
            RectangleF rect = new RectangleF(0, 0, txt.Width, txt.Height);
            using (GraphicsPath path = GetRoundPath(rect, radio))
            {
                txt.Region = new Region(path);
            }

            // Redibujar en resize
            txt.Resize += (s, e) =>
            {
                RectangleF r = new RectangleF(0, 0, txt.Width, txt.Height);
                using (GraphicsPath p = GetRoundPath(r, radio))
                {
                    txt.Region = new Region(p);
                }
            };
        }

        public static GraphicsPath GetRoundPath(RectangleF rect, int radius)
        {
            // Limitar el radio solo por la altura
            float actualRadius = Math.Min(radius, rect.Height / 2f);
            float diameter = actualRadius * 2f;

            GraphicsPath path = new GraphicsPath();

            if (actualRadius <= 0)
            {
                path.AddRectangle(rect);
            }
            else
            {
                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
                path.AddLine(rect.X + actualRadius, rect.Y, rect.Right - actualRadius, rect.Y);
                path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
                path.AddLine(rect.Right, rect.Y + actualRadius, rect.Right, rect.Bottom - actualRadius);
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddLine(rect.Right - actualRadius, rect.Bottom, rect.X + actualRadius, rect.Bottom);
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
                path.AddLine(rect.X, rect.Bottom - actualRadius, rect.X, rect.Y + actualRadius);
            }

            path.CloseFigure();
            return path;
        }
        private const int EM_SETRECT = 0xB3;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref RECT lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        public static void CenterTextBoxCursorVertically(TextBox textBox, int indent = -1, int ptop = -1)
        {
            if (!textBox.Multiline) return;

            // Tamaño del área de cliente
            Rectangle clientRect = textBox.ClientRectangle;
            //obtener la posicion del cursor 
            Point cursorPos = textBox.GetPositionFromCharIndex(textBox.SelectionStart);
            using (Graphics g = textBox.CreateGraphics())
            {
                float textHeight = textBox.Font.GetHeight(g);

                // Calculamos el padding vertical
                int padding = (int)((clientRect.Height - textHeight) / 2);
                int leftIndent = indent >= 0 ? indent : clientRect.Left;
                RECT rect = new RECT
                {
                    Left = leftIndent,       // mantener igual
                    Top = padding + ptop,                // centrar arriba
                    Right = clientRect.Right,     // mantener igual
                    Bottom = clientRect.Bottom    // mantener igual
                };

                SendMessage(textBox.Handle, EM_SETRECT, 0, ref rect);
            }
        }


    }
}
