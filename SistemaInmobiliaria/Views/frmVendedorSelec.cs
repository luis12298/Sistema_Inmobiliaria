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
    public partial class frmVendedorSelec : Form
    {
        frmVenta _frmVenta;
        frmPagoComision _frmPagoComision;
        public frmVendedorSelec(frmVenta frmVenta)
        {
            InitializeComponent();
            _frmVenta = frmVenta;
            dgvDatos.DataSource = CargarDatos();
            dgvDatos.DataBindingComplete += (s, e) =>
            {

                new SettingController().AjustarColumnas(dgvDatos);
                AgregarBoton(dgvDatos);
            };
        }
        public frmVendedorSelec(frmPagoComision frmpago)
        {
            InitializeComponent();
            _frmPagoComision = frmpago;
            dgvDatos.DataSource = CargarDatos();
            dgvDatos.DataBindingComplete += (s, e) =>
            {

                new SettingController().AjustarColumnas(dgvDatos);
                AgregarBoton(dgvDatos);
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
        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos.Rows[index].Selected = true;
            if (e.ColumnIndex == dgvDatos.Columns["colMixta"].Index)
            {
                if (_frmVenta != null)
                {
                    int Id = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdVendedor"].Value.ToString());
                    string Nombre = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    _frmVenta.Selecionar(Id, Nombre);
                    this.Close();
                }
                if (_frmPagoComision != null)
                {
                    int Id = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdVendedor"].Value.ToString());
                    string Nombre = dgvDatos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    _frmPagoComision.Selecionar(Id, Nombre);
                    this.Close();
                }
            }
        }
    }
}
