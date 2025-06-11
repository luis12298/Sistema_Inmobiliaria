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
            if (txtCodigo.Text.Length >= 6)
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
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Correo eliminado con éxito");
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
