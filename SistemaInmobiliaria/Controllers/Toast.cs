using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{
    internal class Toast
    {
        public enum ToastType
        {
            Success,
            Info,
            Warning,
            Error
        }

        public void Show(ToastType type, string message)
        {
            Form toastForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                Size = new Size(350, 100),
                Opacity = 0.95,
                Padding = new Padding(0),
                BackColor = Color.White,
                TopMost = true,
            };

            string title;
            Color barColor;
            Color progressColor;
            string icon;

            switch (type)
            {
                case ToastType.Success:
                    title = "Éxito";
                    barColor = Color.FromArgb(56, 142, 60);
                    progressColor = Color.FromArgb(40, 120, 50);
                    icon = "✅";
                    break;
                case ToastType.Info:
                    title = "Información";
                    barColor = Color.FromArgb(2, 119, 189);
                    progressColor = Color.FromArgb(0, 80, 150);
                    icon = "ℹ️";
                    break;
                case ToastType.Warning:
                    title = "Advertencia";
                    barColor = Color.FromArgb(245, 124, 0);
                    progressColor = Color.FromArgb(200, 100, 0);
                    icon = "⚠️";
                    break;
                case ToastType.Error:
                    title = "Error";
                    barColor = Color.FromArgb(211, 47, 47);
                    progressColor = Color.FromArgb(180, 30, 30);
                    icon = "❎";
                    break;
                default:
                    title = "Mensaje";
                    barColor = Color.Gray;
                    progressColor = Color.DarkGray;
                    icon = "?";
                    break;
            }

            // Barra de progreso
            var progressBar = new ProgressBar
            {
                Dock = DockStyle.Bottom,
                Height = 4,
                Style = ProgressBarStyle.Continuous,
                Maximum = 3000,
                Value = 3000,
                ForeColor = progressColor
            };
            toastForm.Controls.Add(progressBar);

            // Barra lateral de color
            var sideBar = new Panel { Dock = DockStyle.Left, Width = 8, BackColor = barColor };

            // Panel principal
            var mainPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15, 12, 35, 12), BackColor = Color.White };

            // Panel del icono
            var iconPanel = new Panel { Dock = DockStyle.Left, Width = 40, BackColor = Color.Transparent };
            var iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = barColor,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            iconPanel.Controls.Add(iconLabel);

            // Botón de cierre (X)
            var closeButton = new Button
            {
                Text = "❎",
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Gray,
                BackColor = Color.White,
                FlatAppearance = { BorderSize = 0 },
                //Cambiar solo el tamaño de la letra
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Size = new Size(40, 40),
                Location = new Point(toastForm.Width - 40, 3),
                //Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.BorderColor = Color.White;
            closeButton.FlatAppearance.MouseDownBackColor = Color.White;
            closeButton.FlatAppearance.MouseOverBackColor = Color.White;
            closeButton.Click += (s, e) =>
            {
                toastForm.Close();
            };
            toastForm.Controls.Add(closeButton);

            // Panel de contenido
            var contentPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent, Padding = new Padding(5, 0, 0, 0) };
            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var messageLabel = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(80, 80, 80),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                Padding = new Padding(0, 10, 0, 0)
            };
            contentPanel.Controls.Add(messageLabel);
            contentPanel.Controls.Add(titleLabel);

            mainPanel.Controls.Add(contentPanel);
            mainPanel.Controls.Add(iconPanel);
            toastForm.Controls.Add(mainPanel);
            toastForm.Controls.Add(sideBar);

            // Ajustar altura dinámicamente
            using (Graphics g = toastForm.CreateGraphics())
            {
                SizeF titleSize = g.MeasureString(title, titleLabel.Font);
                SizeF messageSize = g.MeasureString(message, messageLabel.Font, contentPanel.Width - 10);
                int requiredHeight = (int)(titleSize.Height + messageSize.Height) + 60; // + espacio extra
                toastForm.Height = Math.Max(100, Math.Min(requiredHeight, 300));
            }

            // Posicionar en esquina superior derecha
            var screen = Screen.PrimaryScreen.WorkingArea;
            toastForm.Location = new Point(screen.Right - toastForm.Width - 10, screen.Top + 50);
            toastForm.Show();

            // Temporizadores
            int timeLeft = 3000;
            Timer fadeOut = new Timer { Interval = 50 };
            Timer timer = new Timer { Interval = 100 };

            timer.Tick += (s, e) =>
            {
                timeLeft -= timer.Interval;
                if (timeLeft > 0 && !toastForm.IsDisposed)
                {
                    progressBar.Value = timeLeft;
                }
                else
                {
                    timer.Stop();
                    fadeOut.Start();
                }
            };

            fadeOut.Tick += (s, e) =>
            {
                if (!toastForm.IsDisposed && toastForm.Opacity > 0.1)
                {
                    toastForm.Opacity -= 0.05;
                }
                else
                {
                    fadeOut.Stop();
                    if (!toastForm.IsDisposed) toastForm.Close();
                }
            };

            timer.Start();
        }
    }
}