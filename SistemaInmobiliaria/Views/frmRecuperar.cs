using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaInmobiliaria.Controllers;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmRecuperar : Form
    {
        FloatingController floatingC = new FloatingController();
        CorreoController correoC = new CorreoController();
        Toast toas = new Toast();
        string codigoEnviado;
        public frmRecuperar()
        {
            InitializeComponent();
            BootstrapStyler.ApplyBootstrapStyle(txtCorreo);
            new FloatingController().FloatingLabelInput(txtCorreo, "Ingrese correo");
            BootstrapStyler.ApplyBootstrapStyle(txtVerificar);
            txtCorreo.KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    txtCorreo.Focus();
                }
            };


        }
        private ProgressBar progressBar;
        private Label labelStatus;
        private Panel panelProgress; // Panel contenedor para mayor control
        private Timer progressTimer;
        private int puntoCount = 0;
        private bool isWorking = false;

        // MÉTODO ÚNICO - Solo llamas este método: MostrarTrabajando()
        public async void MostrarTrabajando()
        {
            try
            {
                if (isWorking) return;
                isWorking = true;

                // Crear panel contenedor si no existe
                if (panelProgress == null)
                {
                    panelProgress = new Panel();
                    panelProgress.Size = new System.Drawing.Size(this.Width, 60);
                    panelProgress.Location = new System.Drawing.Point(0, this.Height - 100);
                    panelProgress.BackColor = Color.FromArgb(200, Color.White); // Semitransparente si deseas
                    panelProgress.BorderStyle = BorderStyle.None;
                    panelProgress.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    this.Controls.Add(panelProgress);
                }

                // Crear ProgressBar si no existe
                if (progressBar == null)
                {
                    progressBar = new ProgressBar();
                    progressBar.Style = ProgressBarStyle.Marquee;
                    progressBar.MarqueeAnimationSpeed = 30;
                    progressBar.Size = new System.Drawing.Size(panelProgress.Width - 40, 25);
                    progressBar.Location = new System.Drawing.Point(20, 30);
                    progressBar.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    panelProgress.Controls.Add(progressBar);
                }

                // Crear Label si no existe
                if (labelStatus == null)
                {
                    labelStatus = new Label();
                    labelStatus.Size = new System.Drawing.Size(panelProgress.Width - 40, 25);
                    labelStatus.Location = new System.Drawing.Point(20, 5);
                    labelStatus.TextAlign = ContentAlignment.MiddleCenter;
                    labelStatus.Font = new System.Drawing.Font("Arial", 10);
                    labelStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    panelProgress.Controls.Add(labelStatus);
                }

                // Crear Timer si no existe
                if (progressTimer == null)
                {
                    progressTimer = new Timer();
                    progressTimer.Interval = 500;
                    progressTimer.Tick += (s, e) =>
                    {
                        puntoCount = (puntoCount + 1) % 4;
                        string puntos = new string('.', puntoCount);
                        labelStatus.Text = $"Trabajando{puntos}";
                    };
                }

                // Mostrar elementos y traer al frente
                panelProgress.Visible = true;
                panelProgress.BringToFront();
                progressTimer.Start();

                // Deshabilitar todos los controles excepto el panel
                foreach (Control control in this.Controls)
                {
                    if (control != panelProgress)
                        control.Enabled = false;
                }

                // Simular tarea
                Random random = new Random();
                int tiempoTrabajo = random.Next(1000, 10000);
                await Task.Delay(tiempoTrabajo);

                // Aquí tu lógica real

            }
            finally
            {
                // Limpiar al final
                progressTimer?.Stop();
                panelProgress?.SendToBack(); // Opcional, si quieres ocultar visualmente
                panelProgress.Visible = false;

                foreach (Control control in this.Controls)
                {
                    control.Enabled = true;
                }

                isWorking = false;
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese un correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (!correoC.Usuario(txtCorreo.Text))
            {
                MessageBox.Show("El correo no esta registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new SettingController().MostrarTrabajando(this);

            validaCorreo();
            label3.Visible = true;
            txtVerificar.Visible = true;
        }
        private void EnviarCorreo()
        {
            Random random = new Random();
            codigoEnviado = random.Next(100000, 999999).ToString();


            string destinatario = txtCorreo.Text;
            string remitente = "noreply.sistemait@gmail.com";
            string contraseña = "lvib qlxq utpd bpop";
            string asunto = "Restablecer contraseña";
            string cuerpo = "Hemos recibido una solicitud para restablecer su contraseña \n Su codigo es: <b>" + codigoEnviado + "</b>";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remitente);
            mail.To.Add(destinatario);
            mail.Subject = asunto;
            mail.Body = cuerpo;
            mail.IsBodyHtml = true; // Indica que el contenido es HTML

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(remitente, contraseña);
            smtp.EnableSsl = true;
            try
            {


                smtp.Send(mail);
                toas.Show(Toast.ToastType.Success, "Correo enviado");
                Task.Run(() =>
                {
                    Task.Delay(7000).Wait();
                    codigoEnviado = null;
                });
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void validaCorreo()
        {
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo))
            {
                toas.Show(Toast.ToastType.Error, "Correo vacio");
                return;
            }
            if (correo.Contains("@") && correo.Contains("."))
            {
                EnviarCorreo();

            }
            else
            {
                MessageBox.Show("Correo no válido. Debe contener '@' y un dominio.");
            }
        }

        private void txtVerificar_TextChanged(object sender, EventArgs e)
        {
            if (txtVerificar.Text.Length >= 6)
            {
                if (txtVerificar.Text == codigoEnviado)
                {
                    CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Codigo correcto");
                    frmInicio frm = new frmInicio();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El codigo es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRecuperar_Load(object sender, EventArgs e)
        {

        }
    }
}