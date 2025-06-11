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
            floatingC.FloatingLabelInput(txtCorreo, "Correo");
            new FloatingController().FloatingLabelInput(txtCorreo, "Ingrese correo");
            PlaceholderController.SetPlaceholder(txtVerificar, "Verficar codigo");

            BootstrapStyler.ApplyBootstrapStyle(txtCorreo);
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
    }
}