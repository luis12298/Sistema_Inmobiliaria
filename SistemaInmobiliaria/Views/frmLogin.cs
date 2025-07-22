using FontAwesome.Sharp;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmLogin : Form
    {
        UsuarioController usuarioC = new UsuarioController();
        private ContextMenuStrip menuContextual;

        public frmLogin()
        {
            InitializeComponent();
            InicializarMenuContextualGoogle();
            new ToolTip().SetToolTip(btnGoogle, "Iniciar con Google, clic derecho para salir");
            this.MinimumSize = new Size(450, 570);

            //floatingC.FloatingLabelInput(txtUsuario, "Usuario");
            //floatingC.FloatingLabelInput(txtContrasena, "Contraseña");

            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Primary, btnIniciar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Light, btnGoogle);
            SettingController settingController = new SettingController();
            BootstrapStyler.ApplyBootstrapStyle(txtUsuario);
            BootstrapStyler.ApplyBootstrapStyle(txtContrasena);
            TextBoxIndent.AplicarIndentacionVisual(txtUsuario, 35);
            TextBoxIndent.AplicarIndentacionVisual(txtContrasena, 35);
            PlaceholderController.SetPlaceholder(txtUsuario, "Usuario");
            PlaceholderController.SetPlaceholder(txtContrasena, "Contraseña");
            txtContrasena.PasswordChar = '\u25CF';
            //evitar saltos de lineas en los textbox
            txtUsuario.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    txtContrasena.Focus();
                }
            };
            txtContrasena.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    btnIniciar.PerformClick();
                }
            };
            this.Shown += (s, e) =>
            {
                txtUsuario.Focus();
            };
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Paint += (s, e) =>
            {
                // Verificar que el rectángulo tenga dimensiones válidas
                if (this.ClientRectangle.Width > 0 && this.ClientRectangle.Height > 0)
                {
                    Color color1 = ColorTranslator.FromHtml("#4E71FF");
                    Color color2 = ColorTranslator.FromHtml("#5409DA");
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, 90f))
                    {
                        e.Graphics.FillRectangle(brush, this.ClientRectangle);
                    }
                }
            };
            AplicarBordesRedondeados(panel1, 8);
            AgregarSombraConPanel(panel1);

            //InicializarArchivoLicencia();
            DateTime fechaActual = DateTime.Now;
            if (fechaActual.Day >= 28 && fechaActual.Day <= 30)
            {
                if (new LicenciaInfo().VerificarLicencia("cipres"))
                {
                    //MessageBox.Show("Nice");
                }
                else
                {
                    btnIniciar.Enabled = false;
                    btnGoogle.Enabled = false;
                }
            }
            else
            {
                //MessageBox.Show("Prosiga");
            }

        }
        //private void InicializarArchivoLicencia()
        //{
        //    string pathJson = @"C:\Data\licencia.json";

        //    // Leer el archivo existente
        //    string existingJson = File.ReadAllText(pathJson);
        //    JObject jsonObject = JObject.Parse(existingJson);

        //    // Modificar la propiedad estado
        //    jsonObject["estado"] = "false";

        //    // Escribir de vuelta al archivo
        //    File.WriteAllText(pathJson, jsonObject.ToString(Formatting.Indented));
        //}


        public void AgregarSombraConPanel(Panel panelPrincipal)
        {
            int sombraTamaño = 20;  // Aumenté el tamaño para mejor difuminado
            int radio = 8;

            // Crear el panel de sombra (más grande que el panel principal)
            Panel sombra = new Panel
            {
                BackColor = Color.Transparent,
                Size = new Size(panelPrincipal.Width + sombraTamaño * 2,
                               panelPrincipal.Height + sombraTamaño * 2),
                Location = new Point(panelPrincipal.Left - sombraTamaño,
                                   panelPrincipal.Top - sombraTamaño),
                Parent = panelPrincipal.Parent
            };

            // Dibujar la sombra difuminada
            sombra.Paint += (s, e) =>
            {
                // Crear un rectángulo del tamaño del panel principal
                Rectangle rectPrincipal = new Rectangle(
                    sombraTamaño,
                    sombraTamaño,
                    panelPrincipal.Width,
                    panelPrincipal.Height);

                using (GraphicsPath path = RoundedRect(rectPrincipal, radio))
                {
                    // Configuración para mejor difuminado
                    int pasosDifuminado = sombraTamaño;
                    Color colorSombra = Color.FromArgb(4, 0, 0, 0);

                    for (int i = pasosDifuminado; i >= 1; i--)
                    {
                        int alpha = colorSombra.A * i / pasosDifuminado;
                        using (Pen pen = new Pen(Color.FromArgb(alpha, colorSombra), i))
                        {
                            e.Graphics.DrawPath(pen, path);
                        }
                    }

                    // Relleno central
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(15, 0, 0, 0)))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
            };

            // Asegurar el orden z
            sombra.SendToBack();
            panelPrincipal.BringToFront();

            // Manejar cambios en el panel principal
            panelPrincipal.LocationChanged += (s, e) =>
            {
                sombra.Location = new Point(panelPrincipal.Left - sombraTamaño,
                                          panelPrincipal.Top - sombraTamaño);
            };

            panelPrincipal.SizeChanged += (s, e) =>
            {
                sombra.Size = new Size(panelPrincipal.Width + sombraTamaño * 2,
                                     panelPrincipal.Height + sombraTamaño * 2);
                sombra.Invalidate();
            };
        }


        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            int diameter = radius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Esquina superior izquierda
            path.AddArc(arc, 180, 90);

            // Esquina superior derecha
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Esquina inferior derecha
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Esquina inferior izquierda
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        private void AplicarBordesRedondeados(Panel panel, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, panel.Width, panel.Height);
            using (GraphicsPath path = RoundedRect(bounds, radius))
            {
                panel.Region = new Region(path);
            }
        }
        private void frmLogin_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtContrasena.Text))
            {
                new Toast().Show(Toast.ToastType.Warning, "Ingrese un usuario y una contraseña");
                return;
            }
            List<string> datos = usuarioC.Login(txtUsuario.Text, txtContrasena.Text);
            if (datos.Count > 0)
            {
                UsuarioModel.Usuario = datos[1];

                this.Hide();
                frmInicio frm = new frmInicio();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                UsuarioController.Intentos();
                return;
            }

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (txtContrasena.PasswordChar == '\u25CF')
            {
                btnMostrar.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                txtContrasena.PasswordChar = '\0';
            }
            else
            {
                btnMostrar.IconChar = FontAwesome.Sharp.IconChar.Eye;
                txtContrasena.PasswordChar = '\u25CF';
            }
        }

        private void btnRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRecuperar frm = new frmRecuperar();
            frm.ShowDialog();
        }
        string tokenPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "token");
        private void btnGoogle_Click(object sender, EventArgs e)
        {
            AutenticacionModerna();
        }
        private async void AutenticacionModerna()
        {
            try
            {
                var clientSecrets = new ClientSecrets
                {
                    ClientId = "144004458730-ga8dnuqa88bdpgo9h7gdh8katl2bf2nr.apps.googleusercontent.com",
                    ClientSecret = "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"
                };

                var dataStore = new FileDataStore("token", true);
                var tokenPath = Path.Combine(dataStore.FolderPath, "user");

                // Verifica si ya existe un token guardado
                bool tokenExistente = Directory.Exists(tokenPath) && Directory.GetFiles(tokenPath).Length > 0;

                if (tokenExistente)
                {
                    DialogResult result = CustomAlert.ShowConfirm(AlertType.Warning, "Mensaje", "¿Desea cerrar sesión y volver a iniciar con otra cuenta?");
                    if (result == DialogResult.OK)
                    {
                        // Borra el token para forzar nuevo login
                        await dataStore.DeleteAsync<TokenResponse>("user");

                    }

                }

                var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientSecrets,
                    Scopes = new[] {
                "https://www.googleapis.com/auth/userinfo.email",
                "https://www.googleapis.com/auth/userinfo.profile"
            },
                    DataStore = dataStore
                });

                var codeReceiver = new LocalServerCodeReceiver(); // abrirá navegador
                var credential = await new AuthorizationCodeInstalledApp(flow, codeReceiver).AuthorizeAsync("user", CancellationToken.None);

                var oauth2Service = new Oauth2Service(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Google Auth Example"
                });

                var userInfo = await oauth2Service.Userinfo.Get().ExecuteAsync();

                CorreoController correoC = new CorreoController();
                string datos = correoC.usuario(userInfo.Email.ToString());

                if (datos != null)
                {
                    UsuarioModel.Usuario = datos;

                    this.Hide();
                    frmInicio frm = new frmInicio();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No estás registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CerrarSesion();
                }
            }
            catch (GoogleApiException ex)
            {
                MessageBox.Show($"Error de API de Google: {ex.Message}", "Mensaje");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No Logueado. Error: {ex.Message}", "Mensaje");
            }
        }

        private async void CerrarSesion()
        {
            try
            {
                var fileDataStore = new FileDataStore("token", true);
                var token = await fileDataStore.GetAsync<TokenResponse>("user");

                if (token != null && !string.IsNullOrEmpty(token.RefreshToken))
                {
                    using (var client = new HttpClient())
                    {
                        var revokeUrl = $"https://accounts.google.com/o/oauth2/revoke?token={token.RefreshToken}";
                        var response = await client.GetAsync(revokeUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            await fileDataStore.DeleteAsync<TokenResponse>("user"); // borra los tokens locales también
                            //MessageBox.Show("Sesión cerrada correctamente.", "Mensaje");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo cerrar la sesión correctamente.", "Mensaje");
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("No hay sesión activa de Google.", "Mensaje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar sesión: {ex.Message}", "Mensaje");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {


        }
        private void InicializarMenuContextualGoogle()
        {
            var menu = new ContextMenuStrip();



            var itemSalir = new ToolStripMenuItem("Cerrar Sesión");
            itemSalir.Image = FormsIconHelper.ToBitmap(IconChar.SignOutAlt, IconFont.Auto, 16, Color.Black);
            itemSalir.Click += (s, e) => CerrarSesion();
            menu.Items.Add(itemSalir);

            // Asociar al botón
            btnGoogle.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    menu.Show(btnGoogle, new Point(e.X, e.Y));
                }
            };
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarSesion();
        }

        private static readonly string rutaArchivo = "licencia.json";
        private static readonly string firebaseUrl = "https://tu-proyecto.firebaseio.com/";
        private static readonly string clienteId = "cliente123"; // puede venir de config




    }
}
