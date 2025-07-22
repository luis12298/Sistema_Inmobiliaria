using FontAwesome.Sharp;
using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Views
{
    public partial class frmReporteFecha : Form
    {
        public frmReporteFecha()
        {
            InitializeComponent();
            DateTime fecha = DateTime.Now;

            // Fecha inicial (primer día del mes)
            DateTime fechaInicial = new DateTime(fecha.Year, fecha.Month, 1);

            // Fecha final (último día del mes)
            DateTime fechaFinal = fechaInicial.AddMonths(1).AddDays(-1);
            dtpInicio.Value = fechaInicial;
            dtpFinal.Value = fechaFinal;
            lblMes1.Text = $"Mes de: {dtpInicio.Value.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"))}";
            lblMes2.Text = $"Mes de: {dtpInicio.Value.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"))}";
            CargarPagos(fechaInicial.ToString("yyyy-MM-dd"), fechaFinal.ToString("yyyy-MM-dd"));
            new PaginationManager().Setup(dgvDatos, new ReporteGeneralController().FechasPagadas(dtpInicio.Value.ToString("yyyy-MM-dd"), dtpFinal.Value.ToString("yyyy-MM-dd")), panel1, 20);

            this.Resize += (s, e) => (label3).Location = new Point((this.Width - label3.Width) / 2, label3.Location.Y);
            BootstrapStyler.ApplyBootstrapStyle(TotalPagado);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Secondary, btnEjecutar);
            limpiarseleccion();
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {

            lblMes1.Text = $"Mes de: {dtpInicio.Value.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"))}";
        }

        private void dtpFinal_ValueChanged(object sender, EventArgs e)
        {
            lblMes2.Text = $"Mes de: {dtpInicio.Value.ToString("MMMM", new System.Globalization.CultureInfo("es-ES"))}";

        }

        async public void CargarPagos(string fecha1, string fecha2)
        {
            try
            {


                // 2. Habilitar DoubleBuffered mediante reflexión para evitar parpadeos
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, this.dgvDatos, new object[] { true });

                dgvDatos.SuspendLayout();
                dgvDatos.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => new ReporteGeneralController().FechasPagadas(fecha1, fecha2));
                // Asignar DataSource (el DataGridView manejará los datos automáticamente)
                dgvDatos.DataSource = datos;


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
                new SettingController().AjustarColumnas(dgvDatos);
                //sumar la columan MontoPagado
                TotalPagado.Text = "L." + dgvDatos.Rows
    .Cast<DataGridViewRow>()
    .Where(row => row.Cells["MontoPagado"].Value != null)
    .Sum(row => Convert.ToDouble(row.Cells["MontoPagado"].Value))
    .ToString("N2");
            }
            lblTotalRegistros.Text = $"Total de registros: {dgvDatos.Rows.Count}";
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            CargarPagos(dtpInicio.Value.ToString("yyyy-MM-dd"), dtpFinal.Value.ToString("yyyy-MM-dd"));
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                dgvDatos.Rows[index].Selected = true;
            }
        }
        private void limpiarseleccion()
        {
            // Lista de controles donde NO se debe limpiar la selección
            List<Control> excepciones = new List<Control>
    {
        btnEjecutar,dtpInicio,dtpFinal
    };

            bool EsExcepcion(Control c)
            {
                return excepciones.Contains(c);
            }

            this.MouseDown += (s, e) =>
            {
                Control ctrl = this.GetChildAtPoint(e.Location);
                if (!dgvDatos.Bounds.Contains(this.PointToClient(Cursor.Position)) && (ctrl == null || !EsExcepcion(ctrl)))
                {
                    dgvDatos.ClearSelection();
                }
            };

            void AsignarEvento(Control control)
            {
                foreach (Control c in control.Controls)
                {
                    if (c != dgvDatos)
                    {
                        c.MouseDown += (s, e) =>
                        {
                            if (!dgvDatos.Bounds.Contains(this.PointToClient(Cursor.Position)) && !EsExcepcion(c))
                                dgvDatos.ClearSelection();
                        };

                        if (c.HasChildren)
                            AsignarEvento(c);
                    }
                }
            }

            AsignarEvento(this);
        }


    }
}
