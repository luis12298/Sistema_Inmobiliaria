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
    public static class MenuUsuarioFlotante
    {
        private static Panel menuFlotante;
        private static Button botonAncla;
        private static Form formActual;

        public static void Mostrar(Form form, Button boton, string userLog, EventHandler onCerrarSesion = null, EventHandler onAyuda = null)
        {
            if (menuFlotante != null && !menuFlotante.IsDisposed)
            {
                Cerrar(form);
                return;
            }

            Color bcolor = ColorTranslator.FromHtml("#F3F8FF");

            menuFlotante = new Panel
            {
                BackColor = bcolor,
                Size = new Size(250, 150),
                Visible = false,
            };
            botonAncla = boton;
            formActual = form;
            menuFlotante.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, menuFlotante.Width + 1, menuFlotante.Height + 1, 12, 12));
            menuFlotante.Paint += (sender, e) =>
            {
                using (Pen borderPen = new Pen(ColorTranslator.FromHtml("#D3D3D3"), 1))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawRoundedRectangle(borderPen, new Rectangle(0, 0, menuFlotante.Width - 1, menuFlotante.Height - 1), 10);
                }
            };
            ReposicionarMenu();


            PictureBox avatar = new PictureBox
            {
                Size = new Size(48, 48),
                Location = new Point(10, 15),
                BackColor = Color.Transparent
            };
            avatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(ColorTranslator.FromHtml("#f2f2f2")))
                    e.Graphics.FillEllipse(brush, 0, 0, avatar.Width - 1, avatar.Height - 1);

                using (Bitmap iconBmp = FormsIconHelper.ToBitmap(IconChar.User, IconFont.Solid, 26, Color.DarkGray))
                {
                    int x = (avatar.Width - iconBmp.Width) / 2;
                    int y = (avatar.Height - iconBmp.Height) / 2;
                    e.Graphics.DrawImage(iconBmp, x, y);
                }

                using (Pen borderPen = new Pen(Color.LightGray, 1))
                    e.Graphics.DrawEllipse(borderPen, 0, 0, avatar.Width - 1, avatar.Height - 1);
            };

            Label lblNombre = new Label
            {
                Text = "Usuario",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(70, 18),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label lblUserLog = new Label
            {
                Text = userLog,
                ForeColor = Color.DarkGray,
                Font = new Font("Segoe UI", 8),
                Location = new Point(70, 42),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            lblUserLog.MouseEnter += (s, e) => { lblUserLog.ForeColor = Color.Black; };
            lblUserLog.MouseLeave += (s, e) => { lblUserLog.ForeColor = Color.DarkGray; };
            //copiar al portapapeles el texto del labe
            Panel linea = new Panel
            {
                Size = new Size(220, 1),
                Location = new Point(15, 70),
                BackColor = Color.FromArgb(70, 70, 70)
            };

            IconButton btnCerrarSesion = CrearBotonMenu("Cerrar sesión", 80, (s, e) =>
            {
                Cerrar(form);
                if (onCerrarSesion != null)
                    onCerrarSesion.Invoke(s, e);
                else
                    MessageBox.Show("Sesión cerrada");
            });
            btnCerrarSesion.IconChar = IconChar.SignOutAlt;
            btnCerrarSesion.IconColor = Color.Black;
            btnCerrarSesion.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#DEECFF");
            btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCerrarSesion.IconSize = 20;

            IconButton ayuda = CrearBotonMenu("Ayuda", 115, (s, e) =>
            {
                Cerrar(form);
                if (onAyuda != null)
                    onAyuda.Invoke(s, e);
                else
                    MessageBox.Show("Ayuda");
            });
            ayuda.IconChar = IconChar.QuestionCircle;
            ayuda.IconColor = Color.Black;
            ayuda.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#DEECFF");
            ayuda.ImageAlign = ContentAlignment.MiddleLeft;
            ayuda.TextImageRelation = TextImageRelation.ImageBeforeText;
            ayuda.IconSize = 20;

            menuFlotante.Controls.Add(avatar);
            menuFlotante.Controls.Add(lblNombre);
            menuFlotante.Controls.Add(lblUserLog);
            menuFlotante.Controls.Add(linea);
            menuFlotante.Controls.Add(ayuda);
            menuFlotante.Controls.Add(btnCerrarSesion);

            form.Controls.Add(menuFlotante);
            menuFlotante.BringToFront();
            menuFlotante.Visible = true;
            form.MouseDown += CerrarMenuAlHacerClicFuera;
            form.Resize += Form_ResizeReposicionarMenu;
            AgregarEventosCerrarMenu(form, form);
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddArc(bounds.X + bounds.Width - cornerRadius * 2, bounds.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddArc(bounds.X + bounds.Width - cornerRadius * 2, bounds.Y + bounds.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.CloseFigure();
            graphics.DrawPath(pen, path);
        }
        private static void ReposicionarMenu()
        {
            if (menuFlotante == null || menuFlotante.IsDisposed || formActual == null || botonAncla == null)
                return;

            Point botonPantalla = botonAncla.PointToScreen(Point.Empty);
            Point botonRelativo = formActual.PointToClient(botonPantalla);
            menuFlotante.Location = new Point(botonRelativo.X - 200, botonRelativo.Y + botonAncla.Height + 5);
        }

        private static void Form_ResizeReposicionarMenu(object sender, EventArgs e)
        {
            ReposicionarMenu();
        }

        private static IconButton CrearBotonMenu(string texto, int posY, EventHandler onClick)
        {
            IconButton btn = new IconButton
            {
                Text = texto,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(15, posY),
                Size = new Size(220, 30),
                TextAlign = ContentAlignment.MiddleLeft,
                TabStop = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 36, 36);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 36, 36);
            btn.Click += onClick;
            return btn;
        }

        private static void CerrarMenuAlHacerClicFuera(object sender, MouseEventArgs e)
        {
            if (menuFlotante == null || menuFlotante.IsDisposed || menuFlotante.Parent == null)
                return;

            Form form = menuFlotante.FindForm();
            if (form == null)
                return;

            Point puntoEnPanel = menuFlotante.PointToClient(form.PointToScreen(e.Location));

            if (!menuFlotante.ClientRectangle.Contains(puntoEnPanel))
            {
                Cerrar(form);
            }
        }

        private static void AgregarEventosCerrarMenu(Form form, Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control != menuFlotante)
                {
                    control.MouseDown += CerrarMenuAlHacerClicFuera;
                    if (control.HasChildren)
                        AgregarEventosCerrarMenu(form, control);
                }
            }
        }

        private static void RemoverEventosCerrarMenu(Form form, Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                control.MouseDown -= CerrarMenuAlHacerClicFuera;
                if (control.HasChildren)
                    RemoverEventosCerrarMenu(form, control);
            }
        }

        public static void Cerrar(Form form)
        {
            if (menuFlotante != null && !menuFlotante.IsDisposed)
            {
                form.Controls.Remove(menuFlotante);
                menuFlotante.Dispose();
                menuFlotante = null;
                form.MouseDown -= CerrarMenuAlHacerClicFuera;
                form.Resize -= Form_ResizeReposicionarMenu;
                RemoverEventosCerrarMenu(form, form);
                botonAncla = null;
                formActual = null;
            }
        }
    }
}