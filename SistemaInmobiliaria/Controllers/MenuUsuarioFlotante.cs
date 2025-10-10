using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Linq;

namespace SistemaInmobiliaria.Controllers
{
    public static class UsuarioMenu
    {
        private static UsuarioMenuForm _currentMenu;

        public static void Show(Form parentForm, Button anchorButton, string username,
            EventHandler logoutHandler = null, EventHandler helpHandler = null)
        {
            CloseCurrentMenu();
            _currentMenu = new UsuarioMenuForm(parentForm, anchorButton, username, logoutHandler, helpHandler);
            _currentMenu.MenuClosed += () => _currentMenu = null;
            _currentMenu.Show(parentForm);
        }

        public static void Close() => CloseCurrentMenu();

        private static void CloseCurrentMenu()
        {
            _currentMenu?.CloseMenu();
        }
    }

    public class UsuarioMenuForm : Form
    {
        // Constantes para el efecto de sombra
        private const int CS_DROPSHADOW = 0x00020000;

        private const int WM_NCPAINT = 0x0085;

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private readonly Form _parentForm;
        private readonly Button _anchorButton;
        private readonly EventHandler _logoutHandler;
        private readonly EventHandler _helpHandler;
        private bool _aeroEnabled;

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        public event Action MenuClosed;

        public UsuarioMenuForm(Form parent, Button anchor, string username,
            EventHandler logoutHandler, EventHandler helpHandler)
        {
            _parentForm = parent ?? throw new ArgumentNullException(nameof(parent));
            _anchorButton = anchor ?? throw new ArgumentNullException(nameof(anchor));
            _logoutHandler = logoutHandler;
            _helpHandler = helpHandler;
            _aeroEnabled = CheckAeroEnabled();

            InitializeComponents(username);
            ConfigureEvents();
            PositionMenu();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return enabled == 1;
            }
            return false;
        }

        private void InitializeComponents(string username)
        {
            // Configuración básica del formulario
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            BackColor = Color.FromArgb(248, 249, 250);
            Size = new Size(300, 160);
            ShowInTaskbar = false;
            TopMost = true;
            Owner = _parentForm;

            // Forma redondeada
            ApplyRoundedForm();

            // Controles
            CreateAvatar();
            CreateLabels(username);
            CreateSeparator();
            CreateMenuButtons();
        }

        private void ApplyRoundedForm()
        {
            var path = new GraphicsPath();
            int radius = 13;
            var rect = new Rectangle(0, 0, Width, Height);

            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            Region = new Region(path);

        }


        private void CreateAvatar()
        {
            var avatar = new PictureBox
            {
                Size = new Size(48, 48),
                Location = new Point(10, 15),
                BackColor = Color.Transparent
            };

            avatar.Paint += PaintAvatar;
            Controls.Add(avatar);
        }

        private void PaintAvatar(object sender, PaintEventArgs e)
        {
            var avatar = (PictureBox)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Fondo circular
            using (var brush = new SolidBrush(Color.FromArgb(242, 242, 242)))
                e.Graphics.FillEllipse(brush, 0, 0, avatar.Width - 1, avatar.Height - 1);

            // Icono de usuario
            try
            {
                using (var icon = FormsIconHelper.ToBitmap(IconChar.User, IconFont.Solid, 26, Color.DarkGray))
                {
                    int x = (avatar.Width - icon.Width) / 2;
                    int y = (avatar.Height - icon.Height) / 2;
                    e.Graphics.DrawImage(icon, x, y);
                }
            }
            catch { }

            // Borde
            using (var pen = new Pen(Color.LightGray, 1))
                e.Graphics.DrawEllipse(pen, 0, 0, avatar.Width - 1, avatar.Height - 1);
        }

        private void CreateLabels(string username)
        {
            // Etiqueta "Usuario"
            var lblTitle = new Label
            {
                Text = "Usuario",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(70, 18),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            Controls.Add(lblTitle);


            // Nombre de usuario
            var lblUsername = new TextBox
            {
                Text = username ?? "Invitado",
                BorderStyle = BorderStyle.None,
                Height = 20,
                ForeColor = Color.FromArgb(100, 100, 100),
                Font = new Font("Segoe UI", 8),
                Location = new Point(70, 42),
                AutoSize = true,
                Cursor = Cursors.Hand,
                ReadOnly = true,
                TabStop = false,
                BackColor = Color.White,

            };

            //lblUsername.MouseEnter += (s, e) => lblUsername.ForeColor = Color.Black;
            //lblUsername.MouseLeave += (s, e) => lblUsername.ForeColor = Color.FromArgb(100, 100, 100);
            lblUsername.GotFocus += (s, e) => HideCaret(lblUsername.Handle);
            lblUsername.MouseDown += (s, e) =>
            {
                HideCaret(lblUsername.Handle);
            };
            Controls.Add(lblUsername);
            new ToolTip().SetToolTip(lblUsername, "Doble clic para copiar");
            lblUsername.DoubleClick += (s, e) => Clipboard.SetText(lblUsername.Text);
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        private void CreateSeparator()
        {
            var separator = new Panel
            {
                Size = new Size(270, 1),
                Location = new Point(15, 70),
                BackColor = Color.FromArgb(230, 230, 230)
            };
            Controls.Add(separator);
        }

        private void CreateMenuButtons()
        {
            // Botón de cerrar sesión
            var btnLogout = CreateMenuButton("Cerrar sesión", 80, IconChar.SignOutAlt, OnLogoutClick);

            using (GraphicsPath path = CreateRoundRectRgn(
       new RectangleF(0, 0, btnLogout.Width, btnLogout.Height), 8))
            {
                btnLogout.Region = new Region(path);
            }
            Controls.Add(btnLogout);

            // Botón de ayuda
            var btnHelp = CreateMenuButton("Ayuda", 115, IconChar.QuestionCircle, OnHelpClick);


            using (GraphicsPath path = CreateRoundRectRgn(
        new RectangleF(0, 0, btnHelp.Width, btnHelp.Height), 8))
            {
                btnHelp.Region = new Region(path);
            }
            Controls.Add(btnHelp);

            btnLogout.MouseEnter += (s, e) =>
            {
                btnLogout.BackColor = ColorTranslator.FromHtml("#1d2124");
                btnLogout.ForeColor = Color.White;
                btnLogout.IconColor = Color.White;
            };
            btnLogout.MouseLeave += (s, e) =>
            {
                btnLogout.BackColor = Color.Transparent;
                btnLogout.ForeColor = Color.Black;
                btnLogout.IconColor = Color.Black;
            };

            btnHelp.MouseEnter += (s, e) =>
            {
                btnHelp.BackColor = ColorTranslator.FromHtml("#1d2124");
                btnHelp.ForeColor = Color.White;
                btnHelp.IconColor = Color.White;
            };
            btnHelp.MouseLeave += (s, e) =>
            {
                btnHelp.BackColor = Color.Transparent;
                btnHelp.ForeColor = Color.Black;
                btnHelp.IconColor = Color.Black;
            };
        }

        private IconButton CreateMenuButton(string text, int top, IconChar icon, EventHandler clickHandler)
        {
            return new IconButton
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                //ForeColor = Color.Black,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(15, top),
                Size = new Size(270, 35),
                TextAlign = ContentAlignment.MiddleLeft,
                TabStop = false,
                IconChar = icon,
                IconColor = Color.Black,
                IconSize = 20,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                FlatAppearance = {
                    BorderSize = 0,
                    MouseOverBackColor = ColorTranslator.FromHtml("#1d2124"),
                    MouseDownBackColor = Color.FromArgb(222, 236, 255)
                }
            }.WithClickHandler(clickHandler);
        }

        private void OnLogoutClick(object sender, EventArgs e)
        {
            CloseMenu();
            _logoutHandler?.Invoke(sender, e);
        }

        private void OnHelpClick(object sender, EventArgs e)
        {
            CloseMenu();
            _helpHandler?.Invoke(sender, e);
        }

        private void ConfigureEvents()
        {
            Deactivate += (s, e) => CloseMenu();

            if (_parentForm != null)
            {
                _parentForm.Move += RepositionMenu;
                _parentForm.Resize += RepositionMenu;
                _parentForm.Activated += (s, e) => BringToFront();
                _parentForm.FormClosing += (s, e) => CloseMenu();
            }
        }

        private void PositionMenu()
        {
            if (_anchorButton == null || _parentForm == null || IsDisposed) return;

            try
            {
                var buttonLocation = _anchorButton.PointToScreen(Point.Empty);
                Location = new Point(
                    buttonLocation.X + _anchorButton.Width - Width - 5,
                    buttonLocation.Y + _anchorButton.Height + 2);
            }
            catch { }
        }

        GraphicsPath CreateRoundRectRgn(RectangleF Rect, int radius)
        {
            float m = 2.75F;
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();

            GraphPath.AddArc(Rect.X + m, Rect.Y + m, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2 + m, Rect.Y + m, Rect.Width - r2 - m, Rect.Y + m);
            GraphPath.AddArc(Rect.X + Rect.Width - radius - m, Rect.Y + m, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width - m, Rect.Y + r2, Rect.Width - m, Rect.Height - r2 - m);
            GraphPath.AddArc(Rect.X + Rect.Width - radius - m,
                           Rect.Y + Rect.Height - radius - m, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2 - m, Rect.Height - m, Rect.X + r2 - m, Rect.Height - m);
            GraphPath.AddArc(Rect.X + m, Rect.Y + Rect.Height - radius - m, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X + m, Rect.Height - r2 - m, Rect.X + m, Rect.Y + r2 + m);

            GraphPath.CloseFigure();
            return GraphPath;
        }

        private void RepositionMenu(object sender, EventArgs e) => PositionMenu();

        public void CloseMenu()
        {
            if (IsDisposed) return;

            try
            {
                if (_parentForm != null && !_parentForm.IsDisposed)
                {
                    _parentForm.Move -= RepositionMenu;
                    _parentForm.Resize -= RepositionMenu;
                }

                MenuClosed?.Invoke();
                Dispose();
            }
            catch { }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                MenuClosed = null;
            }
            base.Dispose(disposing);
        }
    }

    internal static class ControlExtensions
    {
        public static T WithClickHandler<T>(this T control, EventHandler handler) where T : Control
        {
            if (handler != null)
            {
                control.Click += handler;
            }
            return control;
        }
    }
}
