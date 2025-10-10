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
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmPagoComision : Form
    {
        public int IdVendedorG, IdPagoC = 0;
        public frmPagoComision()
        {
            InitializeComponent();
            FloatingLabel.FloatingLabelInput(txtVendedor, "");
            FloatingLabel.FloatingLabelInput(txtMontoAnterior, "Total anterior");
            FloatingLabel.FloatingLabelInput(txtMonto, "Monto a pagar");
            FloatingLabel.FloatingLabelInput(txtSaldoNuevo, "Saldo nuevo");
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnCargar, BootstrapButton.ButtonSize.Large);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Success, btnGuardar, BootstrapButton.ButtonSize.Large);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Secondary, btnCancelar, BootstrapButton.ButtonSize.Large);

            dgvDatos.DataSource = CargarDatos();
            dgvDatos.DataBindingComplete += (sender, e) =>
            {
                new SettingController().AjustarColumnas(dgvDatos);
                dgvDatos.Columns["IdVendedor"].Visible = false;
                AgregarBoton(dgvDatos);
                EliminarBoton(dgvDatos);
            };
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
            CargarVendedor(Id);
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            double montoAnterior, monto;

            double.TryParse(txtMontoAnterior.Text, out montoAnterior);
            double.TryParse(txtMonto.Text, out monto);

            double saldo = montoAnterior - monto;

            if (saldo < 0)
            {
                txtSaldoNuevo.Text = "0";
                new Toast().Show(Toast.ToastType.Warning, "El monto no puede ser mayor al total anterior");
            }
            else
            {
                txtSaldoNuevo.Text = saldo.ToString("N2");
            }

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
                datos = Task.Run(() => new VendedorController().CargarComisiones())
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
        public void CargarVendedor(int Id)
        {
            VendedorController vendedorC = new VendedorController();
            List<string> datosCliente = vendedorC.CargarPago(Id.ToString());
            if (datosCliente == null) return;
            txtVendedor.Text = datosCliente[0];
            txtMontoAnterior.Text = datosCliente[1];
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var datos = new PagoComision();
            datos.IdPagoC = IdPagoC;
            datos.IdVendedor = IdVendedorG;
            datos.FechaPago = DateTime.Now.ToString("yyyy-MM-dd");
            datos.SaldoAnterior = double.Parse(txtMontoAnterior.Text);
            datos.MontoPagado = double.Parse(txtMonto.Text);
            datos.SaldoNuevo = double.Parse(txtSaldoNuevo.Text);
            if (string.IsNullOrEmpty(txtSaldoNuevo.Text) || string.IsNullOrEmpty(txtMonto.Text) || string.IsNullOrEmpty(txtVendedor.Text)) return;
            if (IdPagoC > 0)
            {
                new VendedorController().ActualizarPago(datos);
                dgvDatos.DataSource = CargarDatos(); btnCancelar.PerformClick();
                new Toast().Show(Toast.ToastType.Success, "Pago actualizado con éxito");
            }
            else
            {
                new VendedorController().GuardarPago(datos);
                btnCancelar.PerformClick();
                dgvDatos.DataSource = CargarDatos();
                new Toast().Show(Toast.ToastType.Success, "Pago registrado con éxito");
            }
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos.Rows[index].Selected = true;
            if (e.ColumnIndex == dgvDatos.Columns["colMixta"].Index)
            {
                txtMontoAnterior.Text = dgvDatos.Rows[e.RowIndex].Cells["SaldoAnterior"].Value.ToString();
                txtMonto.Text = dgvDatos.Rows[e.RowIndex].Cells["MontoPagado"].Value.ToString();

                txtSaldoNuevo.Text = dgvDatos.Rows[e.RowIndex].Cells["SaldoNuevo"].Value.ToString();
                IdPagoC = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdPagoC"].Value.ToString());
                IdVendedorG = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdVendedor"].Value.ToString());
                txtVendedor.Text = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                btnGuardar.Text = "Actualizar";
            }
            else if (e.ColumnIndex == dgvDatos.Columns["colEliminar"].Index)
            {

                var dialogResult = MessageBox.Show("¿Desea eliminar este pago?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int Id = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdPagoC"].Value.ToString());
                    new VendedorController().EliminarPago(Id);
                    dgvDatos.DataSource = CargarDatos();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtMonto.Clear();
            txtVendedor.Clear();
            txtMontoAnterior.Clear();
            txtSaldoNuevo.Clear();
            btnGuardar.Text = "Guardar";
            IdPagoC = 0;
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
    }
}
