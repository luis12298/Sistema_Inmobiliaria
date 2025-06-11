using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{
    internal class PlaceholderController
    {
        public static void SetPlaceholder(TextBox textBox, string placeholder)
        {
            Label placeholderLabel = new Label();
            Color colorDeFondo = textBox.BackColor;

            // Configuración inicial
            placeholderLabel.Text = placeholder;
            placeholderLabel.AutoSize = true;
            placeholderLabel.ForeColor = Color.Gray;
            placeholderLabel.BackColor = colorDeFondo;
            placeholderLabel.Font = textBox.Font;
            placeholderLabel.Cursor = Cursors.IBeam;

            textBox.Parent.Controls.Add(placeholderLabel);
            placeholderLabel.BringToFront();

            // Función para actualizar la posición del label basado en la posición del cursor
            void UpdateLabelPosition()
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    int cursorPosition = textBox.SelectionStart;
                    Point cursorPoint;

                    if (cursorPosition == 0)
                    {
                        cursorPoint = new Point(
                            textBox.Location.X + 5 * 7,
                            textBox.Location.Y + (textBox.Height - textBox.Font.Height) / 2
                        );
                    }
                    else
                    {
                        Point startPoint = textBox.GetPositionFromCharIndex(cursorPosition);
                        cursorPoint = new Point(
                            textBox.Location.X + startPoint.X + 5,
                            textBox.Location.Y + (textBox.Height - textBox.Font.Height) / 2
                        );
                    }

                    placeholderLabel.Location = cursorPoint;
                    placeholderLabel.Visible = true;
                }
                else
                {
                    placeholderLabel.Visible = false;
                }
            }

            // ✅ Ejecutar UpdateLabelPosition luego de que el formulario termine de cargar los controles
            if (textBox.IsHandleCreated)
            {
                textBox.BeginInvoke((MethodInvoker)(() => UpdateLabelPosition()));
            }
            else
            {
                textBox.HandleCreated += (s, e) =>
                {
                    textBox.BeginInvoke((MethodInvoker)(() => UpdateLabelPosition()));
                };
            }


            // Asociar eventos
            textBox.TextChanged += (s, e) => UpdateLabelPosition();
            textBox.KeyUp += (s, e) => UpdateLabelPosition();
            textBox.MouseClick += (s, e) => UpdateLabelPosition();
            textBox.MouseUp += (s, e) => UpdateLabelPosition();
            textBox.GotFocus += (s, e) => UpdateLabelPosition();

            // Hacer que el label enfoque el textbox al hacer clic
            placeholderLabel.Click += (s, e) =>
            {
                textBox.Focus();
                textBox.SelectionStart = textBox.Text.Length;
            };
        }


    }
}
