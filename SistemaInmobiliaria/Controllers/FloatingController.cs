using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{
    internal class FloatingController
    {
        public void FloatingLabelInput(TextBox textBox, string placeholder)
        {
            Label label = new Label();
            Color colorDeFondo = textBox.BackColor;
            textBox.Multiline = true;
            textBox.Height = 35;
            textBox.Font = new Font("Segoe UI", 13.75F, FontStyle.Regular, GraphicsUnit.Point);
            //mantener en la misma posicion
            int y = textBox.Location.Y;
            int x = textBox.Location.X;
            textBox.Location = new Point(x, y);
            label.Text = placeholder;
            label.AutoSize = true;
            label.ForeColor = Color.Gray;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Cursor = Cursors.IBeam;
            label.Font = new Font(textBox.Font.FontFamily, 10, FontStyle.Regular);

            // Sincronizar propiedades iniciales
            label.Visible = textBox.Visible;
            label.Enabled = textBox.Enabled;

            textBox.Parent.Controls.Add(label);

            // Variables para mantener la posición actualizada dinámicamente
            Point GetPlaceholderPosition() => new Point(textBox.Left + 10, textBox.Top + (textBox.Height - label.Height) / 2);
            Point GetLabelPosition() => new Point(textBox.Left + 3, textBox.Top - 25); // posición fija para evitar salto

            void AjustarEstadoLabel()
            {
                // Verificar si el label debe estar visible
                if (!textBox.Visible || !textBox.Enabled)
                {
                    label.Visible = false;
                    return;
                }

                // Sincronizar visibilidad y estado
                label.Visible = textBox.Visible;
                label.Enabled = textBox.Enabled;

                if (string.IsNullOrEmpty(textBox.Text)) MostrarComoPlaceholder();
                else MostrarComoLabel();
            }

            void MostrarComoPlaceholder()
            {
                // Solo mostrar si el textbox está visible y habilitado
                if (!textBox.Visible || !textBox.Enabled)
                {
                    label.Visible = false;
                    return;
                }

                label.Location = GetPlaceholderPosition();
                label.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);

                // Ajustar color según el estado del textbox
                if (!textBox.Enabled)
                {
                    label.ForeColor = SystemColors.GrayText;
                    label.Cursor = Cursors.Default;
                }
                else
                {
                    label.ForeColor = Color.Gray;
                    label.Cursor = Cursors.IBeam;
                }

                label.BackColor = textBox.ReadOnly ? Color.FromArgb(240, 240, 240) : colorDeFondo;
                label.Visible = true;
                label.BringToFront();
            }

            void MostrarComoLabel()
            {
                // Solo mostrar si el textbox está visible
                if (!textBox.Visible)
                {
                    label.Visible = false;
                    return;
                }

                label.Visible = true;
                label.Location = GetLabelPosition();
                label.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Ajustar color según el estado del textbox
                if (!textBox.Enabled)
                {
                    label.ForeColor = SystemColors.GrayText;
                    label.Cursor = Cursors.Default;
                }
                else
                {
                    label.ForeColor = Color.Black;
                    label.Cursor = Cursors.Default;
                }

                label.BackColor = Color.Transparent;
                label.BringToFront();
            }

            AjustarEstadoLabel();

            // Eventos existentes
            textBox.Enter += (s, e) => MostrarComoLabel();
            textBox.Leave += (s, e) => AjustarEstadoLabel();
            textBox.TextChanged += (s, e) => AjustarEstadoLabel();

            // Evento del label con validación de estado
            label.Click += (s, e) =>
            {
                if (textBox.Enabled && textBox.Visible)
                {
                    textBox.Focus();
                }
            };

            // Eventos de posición y tamaño existentes
            textBox.SizeChanged += (s, e) => AjustarEstadoLabel();
            textBox.LocationChanged += (s, e) => AjustarEstadoLabel();
            textBox.Parent.Resize += (s, e) => AjustarEstadoLabel();

            // NUEVOS: Eventos para sincronizar las propiedades del textbox
            textBox.VisibleChanged += (s, e) => AjustarEstadoLabel();
            textBox.EnabledChanged += (s, e) => AjustarEstadoLabel();
        }


    }
}
