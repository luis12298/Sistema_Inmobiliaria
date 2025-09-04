using FontAwesome.Sharp;
using Google.Apis.Oauth2.v2.Data;
using Humanizer;
using iTextSharp.text.xml.simpleparser.handler;
using Microsoft.Reporting.WinForms;
using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Views
{
    public partial class frmInicio : Form
    {
        private Form currentForm;
        //PlaceholderController placeholderC = new PlaceholderController();
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public frmInicio()
        {
            InitializeComponent();
            // Task.Run(() =>
            //{
            //    GoogleSheetsUploader.SubirData(
            //        new ContratoController().CargarContratos(),
            //        "13wKBFb870tPTUV7D-xb_L5jiF0dDrqcIdxLEB-aqzCI",
            //        "Hoja 1"
            //    );

            //    GoogleSheetsUploader.SubirData(
            //        new ReporteController().CargarCobrosMes(),
            //        "13wKBFb870tPTUV7D-xb_L5jiF0dDrqcIdxLEB-aqzCI",
            //        "Hoja 2"
            //    );
            //    //1 de enero del año actual
            //    string fecha = DateTime.Now.Year + "-01-01";
            //    string fechaF = DateTime.Now.ToString("yyyy-MM-dd");
            //    GoogleSheetsUploader.SubirData(new ReporteGeneralController().FechasPagadas(fecha, fechaF), "13wKBFb870tPTUV7D-xb_L5jiF0dDrqcIdxLEB-aqzCI", "Hoja 3");
            //});
            this.WindowState = FormWindowState.Maximized;
            // Agrega un separador flexible que empuja los ítems siguientes hacia la derecha
            //obtener año actual
            int year = DateTime.Now.Year;
            label2.Text = $"Sistema Inmobiliaria {year}";
            loadform(new frmDashboard());
            IniciarReloj();
            ColorGradient(pnlSidebar);

            SetLeftAlignedIcon(btnDropCliente, IconChar.UserGroup, 35, Color.Black);
            SetLeftAlignedIcon(btnDropContrato, IconChar.FileSignature, 35, Color.Black);
            SetLeftAlignedIcon(btnDropLote, IconChar.MapLocation, 35, Color.Black);
            SetLeftAlignedIcon(btnDropUsuario, IconChar.UserAlt, 35, Color.Black);
            SetLeftAlignedIcon(btnDropOtros, IconChar.Cogs, 35, Color.Black);
            BootstrapStyler.ApplyBootstrapStyle(txtFiltrar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Warning, btnCerrar);

            PlaceholderController.SetPlaceholder(txtFiltrar, "Ingresa una opcion para filtrar", 25, 0);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Light, iconButton1);
            this.Resize += (s, e) =>
            {
                (txtFiltrar).Location = new Point((this.Width - txtFiltrar.Width) / 2, txtFiltrar.Location.Y);
                //TextBoxIndent.AplicarIndentacionVisual(txtFiltrar, 35);

                int x = txtFiltrar.Left = (panel2.Width - txtFiltrar.Width) / 2;
                txtFiltrar.Left = (panel2.Width - txtFiltrar.Width) / 2;
                txtFiltrar.Top = (panel2.Height - txtFiltrar.Height) / 2;
                iconPictureBox2.Location = new Point((x + 2), iconPictureBox2.Location.Y);

            };

            new ToolTip().SetToolTip(label3, "Dashboard");
            txtFiltrar.KeyPress += (s, e) => e.Handled = e.KeyChar == (char)Keys.Enter;

        }


        public void SetRutaText(string text)
        {
            lblRuta.Text = text;
        }



        public void SetLeftAlignedIcon(Button button, IconChar icon, int iconSize, Color iconColor)
        {
            // Crear el ícono como imagen

            Image iconImage = icon.ToBitmap(iconSize, iconSize, iconColor);

            // Crear una nueva imagen con el ancho del botón y altura del ícono
            Bitmap composedImage = new Bitmap(button.Width, iconSize);

            using (Graphics g = Graphics.FromImage(composedImage))
            {
                // Dibujar el ícono alineado a la izquierda, centrado verticalmente
                int x = 5; // izquierda forzada
                int y = 0; // ya que la imagen tiene la misma altura que el ícono, está centrado verticalmente
                g.DrawImage(iconImage, x, y, iconSize, iconSize);
            }

            // Asignar la imagen como fondo del botón
            button.BackgroundImage = composedImage;
            button.BackgroundImageLayout = ImageLayout.None; // Para que no lo estire
            button.TextAlign = ContentAlignment.MiddleLeft; // Mueve el texto a la derecha del ícono
            button.Padding = new Padding(iconSize + 4, 0, 0, 0); // Espacio entre ícono y texto
        }


        //private void MostrarMenu(Button boton)
        //{
        //    try
        //    {
        //        // Crear el menú primero
        //        ContextMenuStrip menu = new ContextMenuStrip();
        //        menu.Renderer = new ToolStripProfessionalRenderer();
        //        menu.ShowImageMargin = true;
        //        menu.ShowCheckMargin = false;

        //        // Usuario
        //        ToolStripMenuItem opcion1 = new ToolStripMenuItem($"Usuario: {UsuarioModel.Usuario}");
        //        opcion1.Image = FontAwesome.Sharp.IconChar.UserAlt.ToBitmap(16, 16, Color.Black);

        //        // Ayuda
        //        ToolStripMenuItem opcion2 = new ToolStripMenuItem("Ayuda");
        //        opcion2.Image = FontAwesome.Sharp.IconChar.QuestionCircle.ToBitmap(16, 16, Color.Black);
        //        opcion2.Click += (s, e) =>
        //        {
        //            System.Diagnostics.Process.Start("https://github.com/luis12298/Sistema_Inmobiliaria");
        //        };

        //        // Salir
        //        ToolStripMenuItem Msalir = new ToolStripMenuItem("Salir");
        //        Msalir.Image = FontAwesome.Sharp.IconChar.SignOutAlt.ToBitmap(16, 16, Color.Black);
        //        Msalir.Click += (s, e) =>
        //        {
        //            this.Hide();
        //            frmLogin frmLogin = new frmLogin();
        //            frmLogin.ShowDialog();
        //            this.Close();
        //        };

        //        // Agregar ítems al menú
        //        menu.Items.Add(opcion1);
        //        menu.Items.Add(opcion2);
        //        menu.Items.Add(new ToolStripSeparator());
        //        menu.Items.Add(Msalir);

        //        // OBTENER EL TAMAÑO REAL DEL MENÚ
        //        // Necesitamos mostrarlo temporalmente para obtener sus dimensiones
        //        Point tempPoint = new Point(-1000, -1000); // Fuera de la pantalla
        //        menu.Show(tempPoint);

        //        // Obtener dimensiones reales del menú
        //        int menuWidth = menu.Width;
        //        int menuHeight = menu.Height;

        //        // Cerrar el menú temporal
        //        menu.Hide();

        //        // Crear el panel con las dimensiones del menú + espacio para el triángulo
        //        Panel panelMenu = new Panel();
        //        panelMenu.BackColor = Color.White;
        //        panelMenu.Size = new Size(menuWidth, 20); // Solo altura para el triángulo

        //        // Calcular posición
        //        Point botonPantalla = boton.PointToScreen(Point.Empty);
        //        Point posicionForm = this.PointToClient(botonPantalla);
        //        int offsetX = -120;
        //        int offsetY = boton.Height + 15;

        //        panelMenu.Location = new Point(posicionForm.X + offsetX, posicionForm.Y + offsetY - 10);

        //        // Agregar el panel al formulario
        //        this.Controls.Add(panelMenu);
        //        panelMenu.BringToFront();

        //        // Evento Paint del panel para dibujar el triángulo
        //        panelMenu.Paint += (s, e) =>
        //        {
        //            Graphics g = e.Graphics;
        //            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        //            int trianguloWidth = 16;
        //            int trianguloHeight = 13;
        //            int trianguloX = panelMenu.Width - 30; // Ajustado según el ancho real del menú

        //            // Crear puntos del triángulo (apuntando hacia arriba)
        //            Point[] triangulo = {
        //        new Point(trianguloX, trianguloHeight),
        //        new Point(trianguloX + trianguloWidth/2, 0),
        //        new Point(trianguloX + trianguloWidth, trianguloHeight)
        //    };

        //            // Dibujar triángulo relleno
        //            using (SolidBrush brush = new SolidBrush(Color.Black))
        //            {
        //                g.FillPolygon(brush, triangulo);
        //            }

        //            // Dibujar borde del triángulo
        //            using (Pen pen = new Pen(Color.Black, 1))
        //            {
        //                g.DrawPolygon(pen, triangulo);
        //            }
        //        };

        //        // Evento para remover el panel cuando se cierre el menú
        //        menu.Closed += (s, e) =>
        //        {
        //            this.Controls.Remove(panelMenu);
        //            panelMenu.Dispose();
        //        };

        //        // Mostrar el menú en la posición correcta (debajo del panel)
        //        menu.Show(new Point(botonPantalla.X + offsetX, botonPantalla.Y + offsetY));

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}



        private void IniciarReloj()
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += (s, e) =>
            {
                lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public void loadform(object Form)
        {
            try
            {
                // Cerrar el formulario actual, si existe
                if (currentForm != null)
                {
                    currentForm.Close();
                    currentForm = null;
                }
                if (this.Main.Controls.Contains(currentForm))
                {
                    currentForm.BringToFront();
                    return;
                }

                // Eliminar controles existentes en el panel Main
                if (this.Main.Controls.Count > 0)
                {
                    Main.Controls.Clear();
                }

                // Convertir el objeto recibido a Form
                Form form = Form as Form;
                if (form != null)
                {
                    form.TopLevel = false; // Configurar como control secundario
                    form.FormBorderStyle = FormBorderStyle.None; // Sin borde
                    form.Dock = DockStyle.Fill; // Llenar completamente el panel
                    form.AutoScroll = true; // Habilitar desplazamiento si es necesario
                    form.BackColor = Color.White; // Fondo blanco

                    // Agregar el formulario al panel principal
                    this.Main.Controls.Add(form);
                    this.Main.Tag = form;

                    // Mostrar el formulario
                    form.Show();

                    // Evento al cerrar el formulario
                    form.FormClosed += (s, args) =>
                    {
                        //loadform(new frmDashboard()); // Cargar el formulario predeterminado
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void cobrar(string id)
        {

            loadform(new frmRegistrarPago(int.Parse(id)));
            lblRuta.Text = "Contrato / Cobrar";
        }

        public void Cobrar2(string nombre)
        {

            loadform(new frmListaCobro(nombre));
            lblRuta.Text = "Contrato / Cobrar";

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            this.Close();
        }





        private void iconButton1_Click(object sender, EventArgs e)
        {
            EventHandler cerrarSesionHandler = (s, ex) =>
            {
                this.Hide();
                frmLogin frmLogin = new frmLogin();
                frmLogin.ShowDialog();
                this.Close();
            };
            EventHandler ayuda = (s, ex) =>
            {
                Process.Start("https://www.google.com");
            };
            MenuUsuarioFlotante.Mostrar(this, (Button)sender, UsuarioModel.Usuario, cerrarSesionHandler, ayuda);



            // Quitar el foco del botón
            this.ActiveControl = null; // Qita el foco de cualquier control

        }


        private void ColorGradient(Panel panel1)
        {

            panel1.Paint += (s, e) =>
            {

                if (this.ClientRectangle.Width > 0 && this.ClientRectangle.Height > 0)
                {
                    Color color1 = ColorTranslator.FromHtml("#f2f2f2");
                    Color color2 = ColorTranslator.FromHtml("#CEE0ED");
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color2, 90f))
                    {
                        e.Graphics.FillRectangle(brush, this.ClientRectangle);
                    }
                }
            };
        }

        private void btnDropCliente_Click(object sender, EventArgs e)
        {
            if (pnlDrop2.Height == 40)
            {
                pnlDrop2.Height = 120;
                btnDropCliente.IconChar = IconChar.AngleUp;
            }
            else
            {
                pnlDrop2.Height = 40;
                btnDropCliente.IconChar = IconChar.AngleDown;
            }

        }

        private void btnDropContrato_Click(object sender, EventArgs e)
        {
            if (pnlDrop3.Height == 40)
            {
                pnlDrop3.Height = 160;
                btnDropContrato.IconChar = IconChar.AngleUp;
            }
            else
            {
                pnlDrop3.Height = 40;
                btnDropContrato.IconChar = IconChar.AngleDown;
            }
        }

        private void btnDropLote_Click(object sender, EventArgs e)
        {
            if (pnlDrop4.Height == 40)
            {
                pnlDrop4.Height = 120;
                btnDropLote.IconChar = IconChar.AngleUp;
            }
            else
            {
                pnlDrop4.Height = 40;
                btnDropLote.IconChar = IconChar.AngleDown;
            }
        }

        private void btnDropUsuario_Click(object sender, EventArgs e)
        {
            if (pnlDrop5.Height == 40)
            {
                pnlDrop5.Height = 120;
                btnDropUsuario.IconChar = IconChar.AngleUp;
            }
            else
            {
                pnlDrop5.Height = 40;
                btnDropUsuario.IconChar = IconChar.AngleDown;
            }
        }

        private void btnDropOtros_Click(object sender, EventArgs e)
        {
            if (pnlDrop6.Height == 160)
            {
                pnlDrop6.Height = 40;
                btnDropOtros.IconChar = IconChar.AngleDown;
            }
            else
            {
                pnlDrop6.Height = 160;
                btnDropOtros.IconChar = IconChar.AngleUp;
            }
        }

        private void btnVerContrato_Click(object sender, EventArgs e)
        {
            frmVerListaContrato frm = new frmVerListaContrato(this);
            frm.ShowDialog();
        }

        private void btnRegistrarContrato_Click(object sender, EventArgs e)
        {
            loadform(new frmListaContrato());
            lblRuta.Text = "Contratos / Registrar Contrato";
        }

        private void btnTramites_Click(object sender, EventArgs e)
        {
            loadform(new frmListaCobro());
            lblRuta.Text = "Contratos / Tramites";
        }

        private void btnVerLotes_Click(object sender, EventArgs e)
        {
            frmListaLote frm = new frmListaLote();
            frm.ShowDialog();
        }

        private void btnRegisLote_Click(object sender, EventArgs e)
        {
            loadform(new frmLote());
            lblRuta.Text = "Lotes / Registrar Lote";
        }

        private void btnCalculadora_Click(object sender, EventArgs e)
        {
            loadform(new frmCalculadora());
            lblRuta.Text = "Calculadora";
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmReporteGeneral frmReporte = new frmReporteGeneral();
            frmReporte.ShowDialog();
        }

        private void btnRegisUsuario_Click(object sender, EventArgs e)
        {
            loadform(new frmUsuario());
            lblRuta.Text = "Usuarios / Registrar Usuario";
        }

        private void btnRegisCorreo_Click(object sender, EventArgs e)
        {
            loadform(new frmCorreo());
            lblRuta.Text = "Usuarios / Registrar Correo";
        }

        private void btnVerCliente_Click(object sender, EventArgs e)
        {
            frmListaCliente frm = new frmListaCliente(this);
            frm.ShowDialog();
        }

        private void btnRegisCliente_Click(object sender, EventArgs e)
        {
            loadform(new frmCliente());
            lblRuta.Text = "Clientes / Registrar Cliente";
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {


            if (this.pnlSidebar.Width == 250)
            {
                // Oculta la barra lateral
                this.pnlSidebar.Width = 0;
                //this.Main.Location = new Point(this.Main.Location.X - 100, this.Main.Location.Y);
                //int locationx = btnToggle.Location.X;
                //int location2x = lblRuta.Location.X;
                //this.btnToggle.Location = new Point(locationx - 100, 0);
                //lblRuta.Location = new Point(lblRuta.Location.X - 100, lblRuta.Location.Y);
            }
            else
            {
                // Restaura la barra lateral
                this.pnlSidebar.Width = 250;
                //this.Main.Location = new Point(this.Main.Location.X + 100, this.Main.Location.Y);
                //this.btnToggle.Location = new Point(263, 0);
                //lblRuta.Location = new Point(lblRuta.Location.X + 100, lblRuta.Location.Y);
            }



        }
        // Método para crear el buscador dropdown y filtrar botones
        void CrearBuscadorBotones(TextBox txtBuscar, List<Button> botones)
        {
            ListBox lstOpciones = txtBuscar.Parent.Controls
                .OfType<ListBox>()
                .FirstOrDefault(l => l.Name == "lstOpcionesDropdown");

            if (lstOpciones == null)
            {
                lstOpciones = new ListBox
                {
                    Name = "lstOpcionesDropdown",
                    Visible = false,
                    Width = txtBuscar.Width,
                    Height = 100,
                    //Top = txtBuscar.Bottom + 1,
                    Left = txtBuscar.Left
                };

                // Al hacer clic en una opción
                lstOpciones.Click += (s, e) =>
                {
                    SeleccionarOpcion();
                };

                // Agregar al formulario
                //txtBuscar.Parent.Controls.Add(lstOpciones);
                Main.Controls.Add(lstOpciones);

                lstOpciones.BringToFront();
            }

            // Evento de texto
            txtBuscar.TextChanged += (s, e) =>
            {
                string filtro = txtBuscar.Text.ToLower();
                lstOpciones.Items.Clear();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    foreach (var btn in botones)
                    {
                        if (btn.Text.ToLower().Contains(filtro))
                            lstOpciones.Items.Add(btn.Text);
                    }
                    lstOpciones.Visible = lstOpciones.Items.Count > 0;
                }
                else
                {
                    lstOpciones.Visible = false;
                }
            };

            // Evento de teclas: ↑ ↓ Enter
            txtBuscar.KeyDown += (s, e) =>
            {
                if (lstOpciones.Visible)
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        if (lstOpciones.SelectedIndex < lstOpciones.Items.Count - 1)
                            lstOpciones.SelectedIndex++;
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        if (lstOpciones.SelectedIndex > 0)
                            lstOpciones.SelectedIndex--;
                        e.Handled = true;
                    }
                    else if (e.KeyCode == Keys.Enter)
                    {
                        SeleccionarOpcion();
                        e.Handled = true;
                    }
                }
            };

            // Opcional: ocultar si pierde foco
            txtBuscar.LostFocus += (s, e) =>
            {
                Task.Delay(200).ContinueWith(_ =>
                {
                    txtBuscar.Invoke(new Action(() =>
                    {
                        if (!lstOpciones.Focused)
                            lstOpciones.Visible = false;
                    }));
                });
            };

            // Método interno para seleccionar y ejecutar botón
            void SeleccionarOpcion()
            {
                if (lstOpciones.SelectedItem != null)
                {
                    string seleccionado = lstOpciones.SelectedItem.ToString();
                    var boton = botones.FirstOrDefault(b => b.Text == seleccionado);
                    if (boton != null)
                    {
                        boton.PerformClick();
                    }
                    lstOpciones.Visible = false;
                    txtBuscar.Clear();
                    txtBuscar.Focus();
                }
            }
        }


        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Button> botones = new List<Button> { btnReportes, btnCalculadora, btnRegisCliente, btnVerCliente, btnRegisCorreo, btnVerLotes, btnVerContrato, btnRegistrarContrato, btnTramites, btnRegisLote, btnRegisUsuario };
            CrearBuscadorBotones(txtFiltrar, botones);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            loadform(new frmDashboard());
            lblRuta.Text = "Inicio";
        }

        private void btnReporteFecha_Click(object sender, EventArgs e)
        {
            loadform(new frmReporteFecha());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            this.Close();
        }

        private void btnProgramador_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Ingrese la contraseña";
            frm.Size = new Size(303, 160);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;

            // Crear un TextBox para la contraseña
            TextBox txtPassword = new TextBox();
            txtPassword.Location = new Point(10, 20);
            txtPassword.Width = 265;
            txtPassword.PasswordChar = '\u25CF';
            frm.Controls.Add(txtPassword);

            // Crear un botón Aceptar
            Button btnAceptar = new Button();
            btnAceptar.Text = "Aceptar";
            btnAceptar.Location = new Point(10, 70);
            btnAceptar.Size = new Size(265, 40);

            frm.Controls.Add(btnAceptar);
            BootstrapStyler.ApplyBootstrapStyle(txtPassword);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnAceptar);
            PlaceholderController.SetPlaceholder(txtPassword, "Contraseña", 10, 0);
            // Configurar el formulario para aceptar botón Enter
            frm.AcceptButton = btnAceptar;

            // Evento Click del botón
            btnAceptar.Click += (s, ex) =>
            {
                UsuarioController usuarioC = new UsuarioController();
                string datos = usuarioC.ClaveMaster(txtPassword.Text.Trim());

                if (datos == null || datos == "null")
                {
                    MessageBox.Show("Datos incorrectos");
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
                else
                {
                    // Cerrar el formulario de contraseña inmediatamente
                    frm.DialogResult = DialogResult.OK;
                }
            };

            // Mostrar formulario como diálogo
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Esto se ejecutará después de que se cierre frm
                var frmsqlAbierto = Application.OpenForms.OfType<frmsql>().FirstOrDefault();

                if (frmsqlAbierto == null)
                {
                    frmsqlAbierto = new frmsql();
                }

                frmsqlAbierto.ShowDialog();
            }



        }
    }
}
