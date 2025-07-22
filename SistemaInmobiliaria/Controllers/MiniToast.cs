using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{
    internal class MiniToast
    {
        public enum ToastType { Success, Error }

        public void Show(ToastType type, string message, Form parent)
        {
            var toast = new Form
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                Size = new Size(300, 50),
                BackColor = Color.FromArgb(100, 110, 120),
                Opacity = 0.95,
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 300, 50, 16, 16))
            };

            Color color = type == ToastType.Success ? Color.FromArgb(76, 175, 80) : Color.FromArgb(244, 67, 54);
            string icon = type == ToastType.Success ? "✔️" : "❌";

            var iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 18),
                ForeColor = color,
                AutoSize = false,
                Size = new Size(40, 40),
                Location = new Point(10, 1),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var msgLabel = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10),
                AutoSize = false,
                Size = new Size(150, 30),
                Location = new Point(55, 12),
                ForeColor = Color.White
            };

            var closeButton = new Button
            {
                Text = "✖",
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                Size = new Size(30, 30),
                Location = new Point(toast.Width - 35, 5),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) => toast.Close();

            var bottomBar = new Panel
            {
                BackColor = color,
                Height = 5,
                Width = toast.Width,
                Location = new Point(0, toast.Height - 6)
            };

            toast.Controls.Add(iconLabel);
            toast.Controls.Add(msgLabel);
            toast.Controls.Add(closeButton);
            toast.Controls.Add(bottomBar);

            // Mostrar dentro del formulario padre (centrado arriba)
            toast.Location = new Point((parent.Width - toast.Width) / 2, 50);
            parent.Controls.Add(toast);
            toast.BringToFront();
            toast.Show();

            // Barra de progreso
            int totalDuration = 2500, elapsed = 0, interval = 50;
            Timer progressTimer = new Timer { Interval = interval };

            progressTimer.Tick += (s, e) =>
            {
                elapsed += interval;
                double percent = 1 - (double)elapsed / totalDuration;
                bottomBar.Width = (int)(toast.Width * percent);

                if (elapsed >= totalDuration)
                {
                    progressTimer.Stop();
                    toast.Close();
                }
            };

            progressTimer.Start();

        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

    }
}
