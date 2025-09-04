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
    internal class PlaceholderController
    {
        public static void SetPlaceholder(TextBox textBox, string placeholder, int indent, int paddingTop = -1)
        {
            Label placeholderLabel = new Label();
            Color colorDeFondo = textBox.BackColor;

            // Configuración inicial del label placeholder
            placeholderLabel.Text = placeholder;
            placeholderLabel.AutoSize = true;
            placeholderLabel.ForeColor = Color.Gray;
            placeholderLabel.BackColor = colorDeFondo;
            placeholderLabel.Font = textBox.Font;
            placeholderLabel.Cursor = Cursors.IBeam;


            textBox.Parent.Controls.Add(placeholderLabel);
            SetNoPadding(placeholderLabel);
            if (paddingTop < 0) paddingTop = 2;
            CenterTextBoxCursorVertically(textBox, indent, paddingTop);
            placeholderLabel.BringToFront();

            // Función para actualizar la posición del label basado en la posición del cursor
            void UpdateLabelPosition()
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    // MÉTODO FORZADO: Usar GetPositionFromCharIndex(0) para posición exacta del cursor
                    Point cursorPos = textBox.GetPositionFromCharIndex(0);

                    // Posición X forzada exactamente donde está el cursor + indent
                    int placeholderX = textBox.Location.X + cursorPos.X + indent + 1;

                    // Calcular la posición Y para centrar verticalmente el texto
                    int textHeight = TextRenderer.MeasureText("A", textBox.Font).Height;
                    int placeholderY = textBox.Location.Y + (textBox.Height - textHeight) / 2;

                    Point placeholderPos = new Point(placeholderX, placeholderY);
                    placeholderLabel.Location = placeholderPos;
                    placeholderLabel.Visible = true;
                }
                else
                {
                    placeholderLabel.Visible = false;
                }
            }

            // Ejecutar UpdateLabelPosition después de que el formulario termine de cargar los controles
            void InitializePlaceholder()
            {
                if (textBox.IsHandleCreated)
                {
                    textBox.BeginInvoke((MethodInvoker)UpdateLabelPosition);
                }
                else
                {
                    textBox.HandleCreated += (s, e) =>
                        textBox.BeginInvoke((MethodInvoker)UpdateLabelPosition);
                }
            }

            InitializePlaceholder();

            // Asociar eventos para mantener sincronizada la posición del placeholder
            textBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBox.Parent?.Invalidate();
                }
            };
            textBox.TextChanged += (s, e) => UpdateLabelPosition();
            textBox.GotFocus += (s, e) => UpdateLabelPosition();
            textBox.LocationChanged += (s, e) => UpdateLabelPosition();
            textBox.SizeChanged += (s, e) => UpdateLabelPosition();

            // Hacer que el label enfoque el textbox al hacer clic
            placeholderLabel.Click += (s, e) =>
            {
                textBox.Focus();
                textBox.SelectionStart = 0; // Posicionar cursor al inicio
            };
        }

        public static void SetNoPadding(Label label)
        {
            // Para que el fondo se pinte automáticamente y evitemos manchas
            label.BackColor = Color.White;  // O el color que quieras de fondo

            // Deshabilitar el dibujo estándar del texto para evitar solapamiento
            label.Paint += (sender, e) =>
            {
                e.Graphics.Clear(label.BackColor);

                TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding;

                TextRenderer.DrawText(e.Graphics, label.Text, label.Font, label.ClientRectangle, label.ForeColor, Color.Transparent, flags);
            };

            // Opcional: evitar que se dibuje el texto normal (pero Label no tiene propiedad directa para eso)
            // Sin embargo, puedes probar forzar estilo para que no dibuje texto:

            label.Update();
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
