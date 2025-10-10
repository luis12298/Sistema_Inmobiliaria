using SistemaInmobiliaria.Components;
using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
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
    public partial class frmVenta : Form
    {
        public int IdVendedorG, IdVentaG = 0;
        public frmVenta()
        {
            InitializeComponent();
            FloatingLabel.FloatingLabelInput(txtVendedor, "");
            FloatingLabel.FloatingLabelInput(txtNoLote, "No. Lote");
            FloatingLabel.FloatingLabelInput(txtMonto, "Monto comisión");
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnCargar, BootstrapButton.ButtonSize.Large);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Success, btnGuardar, BootstrapButton.ButtonSize.Large);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Secondary, btnCancelar, BootstrapButton.ButtonSize.Large);
            dgvDatos.DataSource = CargarDatos();
            dgvDatos.DataBindingComplete += (s, ex) =>

            {
                new SettingController().AjustarColumnas(dgvDatos);
                dgvDatos.Columns["IdVendedor"].Visible = false;
                AgregarBoton(dgvDatos);
                EliminarBoton(dgvDatos);
            };
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

        private void btnCargar_Click(object sender, EventArgs e)
        {

            frmVendedorSelec frm = new frmVendedorSelec(this);
            frm.ShowDialog();
        }
        public void Selecionar(int Id, string Nombre)
        {
            IdVendedorG = Id;
            txtVendedor.Text = Nombre;
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
                datos = Task.Run(() => new VendedorController().CargaVentas())
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

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos.Rows[index].Selected = true;
            if (e.ColumnIndex == dgvDatos.Columns["colMixta"].Index)
            {
                IdVendedorG = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdVendedor"].Value.ToString());
                IdVentaG = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdVenta"].Value.ToString());
                txtVendedor.Text = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtNoLote.Text = dgvDatos.Rows[e.RowIndex].Cells["NoLote"].Value.ToString();
                txtMonto.Text = dgvDatos.Rows[e.RowIndex].Cells["MontoComision"].Value.ToString();
                dtpFecha.Value = DateTime.Parse(dgvDatos.Rows[e.RowIndex].Cells["FechaVenta"].Value.ToString());
                btnGuardar.Text = "Actualizar";
            }
            else if (e.ColumnIndex == dgvDatos.Columns["colEliminar"].Index)
            {

                var dialogResult = MessageBox.Show("¿Desea eliminar esta venta?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int Id = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdVenta"].Value.ToString());
                    new VendedorController().EliminarVenta(Id);
                    dgvDatos.DataSource = CargarDatos();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtVendedor.Clear();
            txtNoLote.Clear();
            txtMonto.Clear();
            dtpFecha.Value = DateTime.Now;
            btnGuardar.Text = "Guardar";
            dgvDatos.DataSource = CargarDatos();
            IdVendedorG = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVendedor.Text) || string.IsNullOrEmpty(txtNoLote.Text) || string.IsNullOrEmpty(txtMonto.Text))
            {
                new Toast().Show(Toast.ToastType.Warning, "Ingrese todos los campos");
                return;
            }
            if (btnGuardar.Text == "Actualizar")
            {
                var datos = new VentaModel();
                datos.IdVenta = IdVentaG;
                datos.NoLote = txtNoLote.Text;
                datos.Comision = double.Parse(txtMonto.Text);
                datos.FechaVenta = dtpFecha.Value.ToString("yyyy-MM-dd");
                datos.IdVendedor = IdVendedorG;
                new VendedorController().ActualizarVenta(datos);
                dgvDatos.DataSource = CargarDatos();
                btnGuardar.Text = "Guardar";
            }
            else
            {
                var datos = new VentaModel();
                datos.NoLote = txtNoLote.Text;
                datos.Comision = double.Parse(txtMonto.Text);
                datos.FechaVenta = dtpFecha.Value.ToString("yyyy-MM-dd");
                datos.IdVendedor = IdVendedorG;
                new VendedorController().GuardarVenta(datos);
                dgvDatos.DataSource = CargarDatos();
            }
        }
    }
}
