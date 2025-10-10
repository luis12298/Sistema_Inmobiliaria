using SistemaInmobiliaria.Components;
using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Views
{
    public partial class frmVendedor : Form
    {
        SettingController settingC = new SettingController();
        public int IdVendedorG = 0;
        public frmVendedor()
        {
            InitializeComponent();

            FloatingLabel.FloatingLabelInput(txtVendedor, "Ingrese vendedor");
            FloatingLabel.FloatingLabelInput(txtTelefono, "Ingrese teléfono");
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnGuardar);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Secondary, btnCancelar);
            dgvDatos.DataSource = CargarDatos();
            //reportes
            dgvReporte1.DataSource = Reporte1();
            dgvReporte2.DataSource = Reporte2();
            dgvReporte3.DataSource = Reporte3();
            dgvDatos.DataBindingComplete += (s, ex) =>
            {
                settingC.AjustarColumnas(dgvDatos);
                settingC.AjustarColumnas(dgvReporte1);
                settingC.AjustarColumnas(dgvReporte2);
                settingC.AjustarColumnas(dgvReporte3);
                AgregarBoton(dgvDatos);
                EliminarBoton(dgvDatos);
            };
        }
        public DataTable CargarDatos()
        {
            DataTable datos = null;
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
              null, dgvDatos, new object[] { true });

                // 2. Suspende el layout durante la actualización
                dgvDatos.SuspendLayout();
                datos = Task.Run(() => new VendedorController().CargarVendedores())
                           .ConfigureAwait(false)
                           .GetAwaiter()
                           .GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 10. Reanudar el layout una vez terminada la carga
                dgvDatos.ResumeLayout();

            }
            return datos;
        }


        public DataTable Reporte1()
        {
            DataTable datos = null;
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
              null, dgvReporte1, new object[] { true });

                // 2. Suspende el layout durante la actualización
                dgvReporte1.SuspendLayout();
                datos = Task.Run(() => new VendedorController().Reporte1())
                           .ConfigureAwait(false)
                           .GetAwaiter()
                           .GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 10. Reanudar el layout una vez terminada la carga
                dgvReporte1.ResumeLayout();

            }
            return datos;
        }
        public DataTable Reporte2()
        {
            DataTable datos = null;
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
              null, dgvReporte2, new object[] { true });

                // 2. Suspende el layout durante la actualización
                dgvReporte2.SuspendLayout();
                datos = Task.Run(() => new VendedorController().Reporte2())
                           .ConfigureAwait(false)
                           .GetAwaiter()
                           .GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 10. Reanudar el layout una vez terminada la carga
                dgvReporte2.ResumeLayout();

            }
            return datos;
        }
        public DataTable Reporte3()
        {
            DataTable datos = null;
            try
            {
                typeof(DataGridView).InvokeMember("DoubleBuffered",
              BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
              null, dgvReporte2, new object[] { true });

                // 2. Suspende el layout durante la actualización
                dgvReporte2.SuspendLayout();
                datos = Task.Run(() => new VendedorController().Reporte3())
                           .ConfigureAwait(false)
                           .GetAwaiter()
                           .GetResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 10. Reanudar el layout una vez terminada la carga
                dgvReporte2.ResumeLayout();

            }
            return datos;
        }
        void AgregarBoton(DataGridView dgvDatos)
        {
            // Verifica si la columna ya existe y la elimina
            if (dgvDatos.Columns.Contains("colMixta"))
            {
                dgvDatos.Columns.Remove("colMixta");
            }

            // Crea una columna de tipo botón
            DataGridViewButtonColumn colMixta = new DataGridViewButtonColumn();
            colMixta.HeaderText = "Acción";
            colMixta.Name = "colMixta";
            colMixta.Text = "Seleccionar";
            colMixta.ToolTipText = "Seleccionar";
            colMixta.UseColumnTextForButtonValue = true; // Para que muestre el texto en cada botón

            // Agrega la columna al final
            dgvDatos.Columns.Add(colMixta);
            colMixta.DisplayIndex = dgvDatos.Columns.Count - 1;
        }
        void EliminarBoton(DataGridView dgvDatos)
        {
            // Verifica si la columna ya existe y la elimina
            if (dgvDatos.Columns.Contains("colEliminar"))
            {
                dgvDatos.Columns.Remove("colEliminar");
            }
            DataGridViewButtonColumn colMixta = new DataGridViewButtonColumn();
            colMixta.HeaderText = "Eliminar";
            colMixta.Name = "colEliminar";
            colMixta.Text = "Eliminar";
            colMixta.ToolTipText = "Eliminar";
            colMixta.UseColumnTextForButtonValue = true; // Para que muestre el texto en cada botón
            dgvDatos.Columns.Add(colMixta);
            colMixta.DisplayIndex = dgvDatos.Columns.Count - 1;
        }
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //extraer datos Id,Nombre,Telefono con boton seleccionar
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos.Rows[index].Selected = true;
            if (e.ColumnIndex == dgvDatos.Columns["colMixta"].Index)
            {
                IdVendedorG = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdVendedor"].Value.ToString());
                txtVendedor.Text = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvDatos.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                btnGuardar.Text = "Actualizar";
            }
            else if (e.ColumnIndex == dgvDatos.Columns["colEliminar"].Index)
            {

                var dialogResult = MessageBox.Show("¿Desea eliminar el vendedor?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int Id = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdVendedor"].Value.ToString());
                    new VendedorController().EliminarVendedor(Id);
                    dgvDatos.DataSource = CargarDatos();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (IdVendedorG > 0) // Si hay un ID, es edición
            {
                if (string.IsNullOrEmpty(txtVendedor.Text) || string.IsNullOrEmpty(txtTelefono.Text)) return;
                new VendedorController().ActualizarVendedor(IdVendedorG, txtVendedor.Text, txtTelefono.Text);
                MessageBox.Show("Vendedor actualizado correctamente.");
                btnGuardar.Text = "Guardar";
            }
            else
            {
                if (string.IsNullOrEmpty(txtVendedor.Text) || string.IsNullOrEmpty(txtTelefono.Text)) return;
                new VendedorController().GuardarVendedor(txtVendedor.Text, txtTelefono.Text);
                MessageBox.Show("Vendedor guardado correctamente.");
            }

            dgvDatos.DataSource = CargarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvDatos.DataSource = CargarDatos();
            btnGuardar.Text = "Guardar";
            txtVendedor.Clear();
            txtTelefono.Clear();
            IdVendedorG = 0;
        }
    }
}
