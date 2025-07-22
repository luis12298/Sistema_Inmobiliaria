using SistemaInmobiliaria.Controllers;
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
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;
using SistemaInmobiliaria.Models;

namespace SistemaInmobiliaria.Views
{
    public partial class frmCorreo : Form
    {
        public int IdCorreoG = 0;
        CorreoController correoController = new CorreoController();
        SettingController settingC = new SettingController();
        public frmCorreo()
        {
            InitializeComponent();

            new FloatingController().FloatingLabelInput(txtCorreo, "Ingrese correo");
            new FloatingController().FloatingLabelInput(txtDescripcion, "Ingrese una descripcion");
            new FloatingController().FloatingLabelInput(txtCodigo, "Ingrese codigo");
            BootstrapStyler.ApplyBootstrapStyle(txtCorreo);
            BootstrapStyler.ApplyBootstrapStyle(txtDescripcion);
            BootstrapStyler.ApplyBootstrapStyle(txtCodigo);



            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnAgregar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Success, btnGuardar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Dark, btnCancelar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Warning, btnActualizar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Danger, btnEliminar);
            ListarCorreos(listView1);
            this.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            listView1.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            CrearMenuContextual(listView1);

        }
        void CrearMenuContextual(ListView listView)
        {
            // Crear el menú contextual
            ContextMenuStrip menuContextual = new ContextMenuStrip();

            // Agregar la opción "Seleccionar"
            ToolStripMenuItem itemSeleccionar = new ToolStripMenuItem("Seleccionar registro");
            menuContextual.Items.Add(itemSeleccionar);

            // Manejar el evento Click de la opción "Seleccionar"
            itemSeleccionar.Click += (sender, e) =>
            {
                if (listView.SelectedItems.Count > 0)
                {
                    // Obtener el ID del lote seleccionado
                    int idCorreo = Convert.ToInt32(listView.SelectedItems[0].SubItems[0].Text);
                    IdCorreoG = idCorreo;
                    txtCorreo.Text = listView.SelectedItems[0].SubItems[1].Text.Trim();
                    txtDescripcion.Text = listView.SelectedItems[0].SubItems[2].Text.Trim();
                    // Realizar acciones con el ID del lote

                }
            };

            // Asignar el menú contextual al ListView
            listView.ContextMenuStrip = menuContextual;

            // Opcional: Manejar el evento para mostrar el menú solo cuando se hace clic derecho en un elemento
            listView.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Determinar en qué elemento se hizo clic
                    ListViewItem item = listView.GetItemAt(e.X, e.Y);
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            };
        }
        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            validaCorreo();
        }
        private void validaCorreo()
        {
            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrEmpty(correo))
            {
                new Toast().Show(Toast.ToastType.Error, "Correo vacio");
                return;
            }
            if (!correo.Contains("@") && !correo.Contains("."))
            {

                new Toast().Show(Toast.ToastType.Warning, "Correo no valido");
                txtCorreo.Clear();
                txtCorreo.Select();
                return;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                new Toast().Show(Toast.ToastType.Error, "Ingrese un correo");
                return;
            }
            EnviarCorreo();
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

        string codigoEnviado;
        private void EnviarCorreo()
        {
            Random random = new Random();
            codigoEnviado = random.Next(100000, 999999).ToString();


            string destinatario = txtCorreo.Text;
            string remitente = "noreply.sistemait@gmail.com";
            string contraseña = "lvib qlxq utpd bpop";
            string asunto = "Solicitud cuenta nueva";
            string cuerpo = "Hemos recibido una solicitud para agregar una cuenta como: <b>" + txtDescripcion.Text + " </b> \n Su codigo es: <b>" + codigoEnviado + "</b> \n Por favor ingrese el codigo en la seccion de verficar codigo, el tiempo limite es de 1 minuto";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remitente);
            mail.To.Add(destinatario);
            mail.Subject = asunto;
            mail.Body = cuerpo;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(remitente, contraseña);
            smtp.EnableSsl = true;
            try
            {
                new SettingController().MostrarTrabajando(this);

                smtp.Send(mail);
                new Toast().Show(Toast.ToastType.Success, "Correo enviado");

                txtCodigo.Visible = true;
                Task.Run(async () =>
                {
                    await Task.Delay(60000);
                    codigoEnviado = null;
                    btnGuardar.Visible = false;
                    //txtCodigo.Visible = false;
                });
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Trim().Length >= 6)
            {
                if (txtCodigo.Text == codigoEnviado)
                {
                    CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Codigo correcto");
                    txtCodigo.Visible = false;
                    btnGuardar.Visible = true;

                }
                else
                {
                    MessageBox.Show("El codigo es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frmInicio formPrincipal = Application.OpenForms.OfType<frmInicio>().FirstOrDefault();

            // Si existe el formulario principal, mostrar su panel de inicio
            if (formPrincipal != null)
            {
                formPrincipal.SetRutaText("Inicio");
                formPrincipal.loadform(new frmDashboard());
            }

            // Cerrar este formulario
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void ListarCorreos(ListView lvDatos)
        {
            lvDatos.View = View.Details;
            lvDatos.Columns.Clear();
            lvDatos.Items.Clear();

            // Obtener datos
            DataTable lotes = correoController.CargarCorreos();

            // Agregar columnas automáticamente
            foreach (DataColumn column in lotes.Columns)
            {
                lvDatos.Columns.Add(column.ColumnName);
                //negrito

            }

            // Agregar filas
            foreach (DataRow row in lotes.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < lotes.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                lvDatos.Items.Add(item);
                listView1.FullRowSelect = true;
            }
        }
        private void limpiar()
        {
            txtCorreo.Clear();
            txtDescripcion.Clear();
            txtCodigo.Clear();
            txtCodigo.Visible = false;
            btnGuardar.Visible = false;
        }
        private void GuardarCorreo()
        {

            CorreoModel correoM = new CorreoModel();
            correoM.Correo = txtCorreo.Text.Trim();
            correoM.Descripcion = txtDescripcion.Text.Trim();

            if (correoController.GuardarCorreo(correoM))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Usuario registrado con éxito");
                limpiar();
                ListarCorreos(listView1);
                settingC.AjustarColumnas(listView1);
            }
            else
            {
                MessageBox.Show("Error al registrar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarCorreo()
        {
            CorreoModel correoM = new CorreoModel();
            correoM.IdCorreo = IdCorreoG;
            correoM.Correo = txtCorreo.Text.Trim();
            correoM.Descripcion = txtDescripcion.Text.Trim();

            if (correoController.ActualizarCorreo(correoM))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Correo actualizado con éxito");
                limpiar();
                ListarCorreos(listView1);
                settingC.AjustarColumnas(listView1);
            }
            else
            {
                MessageBox.Show("Error al actualizar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
            {
                new Toast().Show(Toast.ToastType.Warning, "Ingrese un correo y una descripcion");
                return;
            }
            GuardarCorreo();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdCorreoG == 0)
            {
                new Toast().Show(Toast.ToastType.Warning, "Seleccione un correo");
                return;
            }
            if (correoController.EliminarCorreo(IdCorreoG))
            {
                new MiniToast().Show(MiniToast.ToastType.Success, "Correo Eliminado", this);
                limpiar();
                ListarCorreos(listView1);
                settingC.AjustarColumnas(listView1);
            }
            else
            {
                MessageBox.Show("Error al eliminar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (IdCorreoG == 0)
            {
                new Toast().Show(Toast.ToastType.Warning, "Seleccione un correo");
                return;
            }
            else if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(txtDescripcion.Text))
            {
                new Toast().Show(Toast.ToastType.Warning, "Ingrese un correo y una descripcion");
                return;
            }
            ActualizarCorreo();
        }
    }
}
