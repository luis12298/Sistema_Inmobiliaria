using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Components
{
    internal static class FloatingLabel
    {
        public static void FloatingLabelInput(TextBox textBox, string placeholder)
        {
            Label label = new Label();
            Color colorDeFondo = textBox.BackColor;

            // Altura del TextBox
            textBox.Multiline = true;
            textBox.Height = 38;
            textBox.Font = new Font("Segoe UI", 10.75F, FontStyle.Regular, GraphicsUnit.Point);

            // Mantener posición original
            int x = textBox.Location.X;
            int y = textBox.Location.Y;
            textBox.Location = new Point(x, y);

            // Configurar Label inicial
            label.Text = placeholder;
            label.AutoSize = false; // importante: controlamos el tamaño manualmente
            label.ForeColor = Color.Gray;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Cursor = Cursors.IBeam;
            label.Font = new Font(textBox.Font.FontFamily, 10F, FontStyle.Regular);

            label.Visible = textBox.Visible;
            label.Enabled = textBox.Enabled;
            label.Padding = Padding.Empty;
            label.Margin = Padding.Empty;

            textBox.Parent.Controls.Add(label);
            label.BringToFront();

            const int leftPadding = 7;
            const float placeholderFontSize = 10f;
            const float floatingFontSize = 8.25f;

            Size MeasureTextSize(string text, Font font)
            {
                // Medición más ajustada sin padding
                var flags = TextFormatFlags.NoPadding;
                return TextRenderer.MeasureText(text, font, new Size(int.MaxValue, int.MaxValue), flags);
            }

            void ApplyPlaceholderLayout()
            {
                using (var f = new Font("Segoe UI", placeholderFontSize, FontStyle.Regular))
                {
                    var size = MeasureTextSize(label.Text, f);
                    label.Font = (Font)f.Clone();
                    label.Size = size;
                    label.Location = new Point(textBox.Left + leftPadding, textBox.Top + (textBox.Height - size.Height) / 2);
                }

                label.BackColor = textBox.ReadOnly ? Color.FromArgb(240, 240, 240) : colorDeFondo;
                label.ForeColor = textBox.Enabled ? Color.Gray : SystemColors.GrayText;
                label.Cursor = textBox.Enabled ? Cursors.IBeam : Cursors.Default;
                label.Visible = true;
                label.BringToFront();
            }

            void ApplyFloatingLabelLayout()
            {
                using (var f = new Font("Segoe UI", floatingFontSize, FontStyle.Bold))
                {
                    var size = MeasureTextSize(label.Text, f);
                    label.Font = (Font)f.Clone();
                    label.Size = size;
                    // Centrar verticalmente respecto a la línea superior del TextBox
                    label.Location = new Point(textBox.Left + leftPadding, textBox.Top - (size.Height / 2));
                    CenterTextBoxCursorVertically(textBox, 3);
                }

                label.BackColor = Color.Transparent;
                label.ForeColor = textBox.Enabled ? Color.Black : SystemColors.GrayText;
                label.Cursor = Cursors.Default;
                label.Visible = true;
                label.BringToFront();
            }

            void AjustarEstadoLabel()
            {
                if (!textBox.Visible || !textBox.Enabled)
                {
                    label.Visible = false;
                    return;
                }

                if (string.IsNullOrEmpty(textBox.Text))
                    ApplyPlaceholderLayout();
                else
                    ApplyFloatingLabelLayout();
            }

            // Eventos
            textBox.Enter += (s, e) => ApplyFloatingLabelLayout();
            textBox.Leave += (s, e) => AjustarEstadoLabel();
            textBox.TextChanged += (s, e) => AjustarEstadoLabel();

            label.Click += (s, e) =>
            {
                if (textBox.Enabled && textBox.Visible)
                    textBox.Focus();
            };

            textBox.SizeChanged += (s, e) => AjustarEstadoLabel();
            textBox.LocationChanged += (s, e) => AjustarEstadoLabel();
            textBox.Parent.Resize += (s, e) => AjustarEstadoLabel();
            textBox.VisibleChanged += (s, e) => AjustarEstadoLabel();
            textBox.EnabledChanged += (s, e) => AjustarEstadoLabel();

            // Estado inicial
            AjustarEstadoLabel();
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
