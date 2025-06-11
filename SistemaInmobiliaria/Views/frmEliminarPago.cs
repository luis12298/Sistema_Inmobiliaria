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
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmEliminarPago : Form
    {
        ReporteController reporteC = new ReporteController();
        SettingController settingC = new SettingController();
        frmRegistrarPago _frmRegistrar;
        public int idPago = 0;
        public int IdG = 0;
        public frmEliminarPago(frmRegistrarPago frmRegistrar, int Id)
        {
            InitializeComponent();
            _frmRegistrar = frmRegistrar;
            this.Size = new Size(1024, 600);
            new FloatingController().FloatingLabelInput(txtFiltrar, "Filtrar");
            BootstrapStyler.ApplyBootstrapStyle(txtFiltrar);
            IdG = Id;
            CargarDatos(dgvDatos, Id);
        }
        private void AplicarFiltroBusqueda(DataGridView dataGridView, string textoBusqueda)
        {


            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                dataGridView.DataSource = reporteC.verpagos(IdG);
                return;
            }

            DataTable filteredTable = reporteC.verpagos(IdG).Clone();
            string searchText = textoBusqueda.ToLower();

            foreach (DataRow row in reporteC.verpagos(IdG).Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    if (item?.ToString().ToLower().Contains(searchText) == true)
                    {
                        filteredTable.ImportRow(row);
                        break;
                    }
                }
            }

            dataGridView.DataSource = filteredTable;
        }
        private async void CargarDatos(DataGridView dataGridView, int Id)
        {
            try
            {


                // 2. Habilitar DoubleBuffered mediante reflexión para evitar parpadeos
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dataGridView, new object[] { true });

                dataGridView.SuspendLayout();
                dataGridView.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => reporteC.verpagos(Id));

                // Asignar DataSource (el DataGridView manejará los datos automáticamente)
                dataGridView.DataSource = datos;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 10. Reanudar el layout una vez terminada la carga

                dataGridView.ResumeLayout();
                settingC.AjustarColumnas(dataGridView);
            }
            AgregarBoton();
        }
        void AgregarBoton()
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
            colMixta.Text = "Eliminar pago";
            colMixta.ToolTipText = "Eliminar pago";
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
                idPago = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdPago"].Value.ToString());
                if (CustomAlert.ShowConfirm(AlertType.Info, "¿Mensaje", "Desea eliminar el pago?") == DialogResult.OK)
                {
                    EliminarPago(idPago);
                    CargarDatos(dgvDatos, IdG);
                    _frmRegistrar.CargarDatos(_frmRegistrar.IdG);
                    this.Close();
                }

            }
        }
        private void EliminarPago(int Id)
        {
            PagoController pagoC = new PagoController();
            if (pagoC.EliminarPago(Id))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Pago eliminado con éxito");
                CargarDatos(dgvDatos, idPago);
            }
            else
            {
                CustomAlert.ShowAlert(AlertType.Error, "Error", "Error al eliminar el pago");
            }
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroBusqueda(dgvDatos, txtFiltrar.Text);
        }
    }
}
