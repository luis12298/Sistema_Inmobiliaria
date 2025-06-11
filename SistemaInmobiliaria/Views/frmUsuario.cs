using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmUsuario : Form
    {
        UsuarioController usuarioC = new UsuarioController();
        SettingController settingC = new SettingController();
        public int IdUsuarioG = 0;
        public frmUsuario()
        {
            InitializeComponent();
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnGuardar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Success, btnActualizar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Danger, btnEliminar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Secondary, btnCancelar);
            BootstrapStyler.ApplyBootstrapStyle(txtUsuario);
            BootstrapStyler.ApplyBootstrapStyle(txtContrasena);
            BootstrapStyler.ApplyBootstrapStyle(txtContrasenaC);
            new FloatingController().FloatingLabelInput(txtUsuario, "Ingrese usuario");
            new FloatingController().FloatingLabelInput(txtContrasena, "Ingrese contraseña");
            new FloatingController().FloatingLabelInput(txtContrasenaC, "Confirme contraseña");
            ListarUsuarios(listView1);
            settingC.AjustarColumnas(listView1);
            this.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            listView1.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            CrearMenuContextual(listView1);
        }
        public void ListarUsuarios(ListView lvDatos)
        {
            lvDatos.View = View.Details;
            lvDatos.Columns.Clear();
            lvDatos.Items.Clear();

            // Obtener datos
            DataTable lotes = usuarioC.CargarUsuarios();

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
                    IdUsuarioG = int.Parse(listView.SelectedItems[0].SubItems[0].Text);
                    txtUsuario.Text = listView.SelectedItems[0].SubItems[1].Text;
                    txtContrasena.Text = listView.SelectedItems[0].SubItems[2].Text;
                    txtContrasenaC.Text = listView.SelectedItems[0].SubItems[2].Text;
                    dtpFecha.Value = string.IsNullOrEmpty(listView.SelectedItems[0].SubItems[4].Text)
     ? DateTime.Now
     : Convert.ToDateTime(listView.SelectedItems[0].SubItems[4].Text);

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
        private void Limpiar()
        {
            IdUsuarioG = 0;
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtContrasenaC.Clear();
            dtpFecha.Value = DateTime.Now;
        }
        public void GuardarUsuario()
        {
            UsuarioModel usuarioM = new UsuarioModel();
            usuarioM._Usuario = txtUsuario.Text;
            usuarioM.Contrasena = txtContrasenaC.Text;
            usuarioM.FechaCreo = dtpFecha.Value.ToString("yyyy-MM-dd");

            if (usuarioC.GuardarUsuario(usuarioM))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Usuario registrado con éxito");
                Limpiar();
                ListarUsuarios(listView1);
                settingC.AjustarColumnas(listView1);
            }
            else
            {
                MessageBox.Show("Error al registrar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizarUsuario()
        {
            UsuarioModel usuarioM = new UsuarioModel();
            usuarioM.IdUsuario = IdUsuarioG;
            usuarioM._Usuario = txtUsuario.Text;
            usuarioM.Contrasena = txtContrasenaC.Text;
            usuarioM.FechaCreo = dtpFecha.Value.ToString("yyyy-MM-dd");

            if (usuarioC.ActualizarUsuario(usuarioM))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Usuario actualizado con éxito");
                Limpiar();
                ListarUsuarios(listView1);
                settingC.AjustarColumnas(listView1);
            }
            else
            {
                MessageBox.Show("Error al actualizar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                new Toast().Show(Toast.ToastType.Warning, "Ingrese usuario");
                return;
            }
            else if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                new Toast().Show(Toast.ToastType.Warning, "Ingrese contraseña");
                return;
            }
            else if (string.IsNullOrEmpty(txtContrasenaC.Text))
            {
                new Toast().Show(Toast.ToastType.Warning, "Confirme contraseña");
                return;
            }
            else if (txtContrasena.Text != txtContrasenaC.Text)
            {
                new Toast().Show(Toast.ToastType.Warning, "Contraseñas no coinciden");
                return;
            }
            GuardarUsuario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdUsuarioG > 0)
            {
                if (CustomAlert.ShowConfirm(AlertType.Warning, "Mensaje", "¿Estas seguro de eliminar el usuario?") == DialogResult.OK)
                {
                    if (usuarioC.EliminarUsuario(IdUsuarioG))
                    {
                        CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Usuario eliminado con éxito");
                        Limpiar();
                        ListarUsuarios(listView1);
                        settingC.AjustarColumnas(listView1);
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (IdUsuarioG == 0)
            {
                MessageBox.Show("Seleccione un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    new Toast().Show(Toast.ToastType.Warning, "Ingrese usuario");
                    return;
                }
                else if (string.IsNullOrEmpty(txtContrasena.Text))
                {
                    new Toast().Show(Toast.ToastType.Warning, "Ingrese contraseña");
                    return;
                }
                else if (string.IsNullOrEmpty(txtContrasenaC.Text))
                {
                    new Toast().Show(Toast.ToastType.Warning, "Confirme contraseña");
                    return;
                }
                else if (txtContrasena.Text != txtContrasenaC.Text)
                {
                    new Toast().Show(Toast.ToastType.Warning, "Contraseñas no coinciden");
                    return;
                }
                ActualizarUsuario();
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
    }
}
