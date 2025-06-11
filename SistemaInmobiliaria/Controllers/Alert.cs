using Handy.DotNETCoreCompatibility.ColourTranslations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;
using static SistemaInmobiliaria.Controllers.Alert;

namespace SistemaInmobiliaria.Controllers
{
    internal class Alert
    {

        public class SweetAlert
        {


            public enum AlertType
            {
                Success,
                Info,
                Warning,
                Error
            }

            public class CustomAlert : Form
            {
                private Label _iconLabel;
                private Label _titleLabel;
                private Label _messageLabel;
                private Button _okButton;
                private Button _cancelButton;
                private Panel _buttonPanel;
                private Panel _contentPanel;

                private DialogResult _result = DialogResult.None;
                protected override CreateParams CreateParams
                {
                    get
                    {
                        const int CS_DROPSHADOW = 0x20000;
                        CreateParams cp = base.CreateParams;
                        cp.ClassStyle |= CS_DROPSHADOW;
                        return cp;
                    }
                }
                public CustomAlert(AlertType type, string title, string message, bool isConfirm = false)
                {
                    // Configurar formulario
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.StartPosition = FormStartPosition.CenterScreen;
                    this.Size = new Size(400, 250);
                    this.BackColor = Color.FromArgb(250, 248, 248);
                    this.ShowInTaskbar = false;

                    // Panel principal con borde redondeado
                    _contentPanel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.FromArgb(250, 248, 248),
                    };

                    // Icono (arriba)
                    _iconLabel = new Label
                    {
                        Font = new Font("Segoe UI", 30, FontStyle.Regular),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Height = 80
                    };

                    // Título (debajo del icono)
                    _titleLabel = new Label
                    {
                        Font = new Font("Segoe UI", 16, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top,
                        Height = 35,
                        ForeColor = Color.FromArgb(70, 70, 70)
                    };

                    // Mensaje (debajo del título)
                    _messageLabel = new Label
                    {
                        Font = new Font("Segoe UI", 11),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        Padding = new Padding(20, 0, 20, 20),
                        ForeColor = Color.FromArgb(100, 100, 100),
                        AutoSize = false
                    };

                    // Botones
                    _buttonPanel = new Panel
                    {
                        Dock = DockStyle.Bottom,
                        Height = 70,
                        BackColor = Color.FromArgb(250, 248, 248)
                    };

                    _okButton = new Button
                    {
                        Text = "OK",
                        Width = 100,
                        Height = 40,
                        BackColor = Color.FromArgb(102, 102, 255),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Font = new Font("Segoe UI", 10, FontStyle.Regular)
                    };
                    _okButton.FlatAppearance.BorderSize = 0;
                    _okButton.Click += (s, e) =>
                    {
                        _result = DialogResult.OK;
                        this.Close();
                    };

                    _cancelButton = new Button
                    {
                        Text = "Cancel",
                        Width = 130,
                        Height = 40,
                        BackColor = Color.FromArgb(220, 53, 69),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Visible = isConfirm,
                        Font = new Font("Segoe UI", 10, FontStyle.Regular)
                    };
                    _cancelButton.FlatAppearance.BorderSize = 0;
                    _cancelButton.Click += (s, e) =>
                    {
                        _result = DialogResult.Cancel;
                        this.Close();
                    };

                    // Añadir botones
                    _buttonPanel.Controls.Add(_okButton);
                    if (isConfirm) _buttonPanel.Controls.Add(_cancelButton);

                    // Añadir controles al panel
                    _contentPanel.Controls.Add(_messageLabel);
                    _contentPanel.Controls.Add(_titleLabel);
                    _contentPanel.Controls.Add(_iconLabel);
                    _contentPanel.Controls.Add(_buttonPanel);

                    // Añadir panel al formulario
                    this.Controls.Add(_contentPanel);

                    // Configurar tipo
                    ConfigureAlert(type, title, message, isConfirm);

                    // Agregar sombra y bordes redondeados
                    this.Paint += (s, e) =>
                    {
                        using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                        {
                            int radius = 10;
                            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                            path.AddArc(this.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                            path.AddArc(this.Width - radius * 2, this.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                            path.AddArc(0, this.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                            path.CloseAllFigures();

                            this.Region = new Region(path);

                            // Dibujar sombra
                            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                                Color.FromArgb(230, 230, 230), 1, ButtonBorderStyle.Solid,
                                Color.FromArgb(230, 230, 230), 1, ButtonBorderStyle.Solid,
                                Color.FromArgb(230, 230, 230), 1, ButtonBorderStyle.Solid,
                                Color.FromArgb(230, 230, 230), 1, ButtonBorderStyle.Solid);
                        }
                    };
                }

                private void ConfigureAlert(AlertType type, string title, string message, bool isConfirm)
                {
                    string iconText;
                    Color iconColor;
                    Color okColor;

                    switch (type)
                    {
                        case AlertType.Success:
                            iconText = "✓";
                            iconColor = Color.FromArgb(92, 184, 92); // Verde claro
                            okColor = Color.FromArgb(92, 184, 92);
                            break;
                        case AlertType.Info:
                            iconText = "ℹ";
                            iconColor = Color.FromArgb(91, 192, 222); // Azul claro
                            okColor = Color.FromArgb(91, 192, 222);
                            break;
                        case AlertType.Warning:
                            iconText = "!";
                            iconColor = Color.FromArgb(240, 173, 78); // Naranja
                            okColor = Color.FromArgb(240, 173, 78);
                            break;
                        case AlertType.Error:
                            iconText = "✕";
                            iconColor = Color.FromArgb(217, 83, 79); // Rojo
                            okColor = Color.FromArgb(217, 83, 79);
                            break;
                        default:
                            iconText = "?";
                            iconColor = Color.Gray;
                            okColor = Color.Gray;
                            break;
                    }

                    // Crear borde circular alrededor del icono
                    _iconLabel.Paint += (s, e) =>
                    {
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        // Dibujar círculo
                        int diameter = 70;
                        int x = (_iconLabel.Width - diameter) / 2;
                        int y = (_iconLabel.Height - diameter) / 2;

                        using (var pen = new Pen(Color.FromArgb(30, iconColor), 2))
                        {
                            e.Graphics.DrawEllipse(pen, x, y, diameter, diameter);
                        }

                        // Dibujar ícono en el centro
                        SizeF textSize = e.Graphics.MeasureString(iconText, _iconLabel.Font);
                        e.Graphics.DrawString(iconText, _iconLabel.Font, new SolidBrush(iconColor),
                            (_iconLabel.Width - textSize.Width) / 2,
                            (_iconLabel.Height - textSize.Height) / 2);
                    };

                    _iconLabel.Text = "";  // Vacío porque lo dibujamos manualmente
                    _titleLabel.Text = title;
                    _messageLabel.Text = message;

                    if (isConfirm)
                    {
                        _okButton.Text = "Si!";
                        _okButton.Width = 130;
                        _okButton.BackColor = Color.FromArgb(92, 184, 92); // Verde para "Yes"
                        _cancelButton.Text = "No!";
                        _cancelButton.BackColor = Color.FromArgb(217, 83, 79); // Rojo para "No"
                    }
                    else
                    {
                        _okButton.Text = "OK";
                        _okButton.BackColor = Color.FromArgb(102, 102, 255); // Morado para OK
                    }

                    // Centrar botones
                    CenterButtons(isConfirm);
                }

                private void CenterButtons(bool isConfirm)
                {
                    if (isConfirm)
                    {
                        // Aumentar la separación entre botones
                        _cancelButton.Location = new Point(50, 15);
                        _okButton.Location = new Point(this.ClientSize.Width - _okButton.Width - 50, 15);
                    }
                    else
                    {
                        _okButton.Location = new Point((this.ClientSize.Width - _okButton.Width) / 2, 15);
                    }
                }

                protected override void OnPaint(PaintEventArgs e)
                {
                    base.OnPaint(e);

                    // Agregar sombra al formulario
                    const int shadowSize = 5;
                    const int shadowOpacity = 100;

                    for (int i = 1; i <= shadowSize; i++)
                    {
                        int opacity = shadowOpacity - (i * (shadowOpacity / shadowSize));
                        using (Pen shadowPen = new Pen(Color.FromArgb(opacity, Color.Black)))
                        {
                            e.Graphics.DrawRectangle(shadowPen,
                                new Rectangle(i, i, this.Width - i * 2, this.Height - i * 2));
                        }
                    }
                }

                public static DialogResult ShowAlert(AlertType type, string title, string message)
                {
                    using (var alert = new CustomAlert(type, title, message, false))
                    {
                        alert.ShowDialog();
                        return alert._result;
                    }
                }

                public static DialogResult ShowConfirm(AlertType type, string title, string message)
                {
                    using (var alert = new CustomAlert(type, title, message, true))
                    {
                        alert.ShowDialog();
                        return alert._result;
                    }
                }
            }
        }
    }
}
//Para su uso
//var alert = new SweetAlert();
//CustomAlert.ShowAlert(AlertType.Info, "Good job!", "You clicked the button!");
//DialogResult result = CustomAlert.ShowConfirm(AlertType.Warning, "Are you sure?", "You won't be able to revert this!");
//if (result == DialogResult.OK)
//{
//    MessageBox.Show("Ok");
//}
//else
//{
//    MessageBox.Show("Cancel");
//}