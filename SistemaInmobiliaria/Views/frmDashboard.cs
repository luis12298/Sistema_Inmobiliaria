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
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaInmobiliaria.Views
{
    public partial class frmDashboard : Form
    {
        ReporteController reporteC = new ReporteController();
        SettingController settingC = new SettingController();
        public frmDashboard()
        {
            InitializeComponent();
            CargarDatos(dgvDatos);
            this.Resize += (s, e) =>
            {

                label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
                label2.Location = new Point((this.Width - label2.Width) / 2, label2.Location.Y);
            };

            CargarCobros(dgvDatos2);

        }


        private async void CargarDatos(DataGridView dataGridView)
        {
            try
            {

                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dataGridView, new object[] { true });

                dataGridView.SuspendLayout();
                dataGridView.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => reporteC.CargarClientesAtrasados());

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

                lblTotal.Text = $"Total: {dataGridView.Rows.Count.ToString()}";
                GraficarClientesAtrasadosPorMes(dataGridView, chart1);
            }
            AgregarBoton(dgvDatos);
        }
        public string SumaTotalCuota()
        {
            return dgvDatos2.Rows
                .Cast<DataGridViewRow>()
                .Sum(row => Convert.ToDouble(row.Cells["MontoCuotaOriginal"].Value ?? 0))
                .ToString("N2");
        }
        private async void CargarCobros(DataGridView dataGridView)
        {
            try
            {

                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, dataGridView, new object[] { true });

                dataGridView.SuspendLayout();
                dataGridView.DataSource = null; // Limpiar datos anteriores

                // Cargar datos asíncronamente
                DataTable datos = await Task.Run(() => reporteC.CargarCobrosMes());

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

                SumaTotalCuota();
                string text = label2.Text;
                label2.Text = $"{text} (L.{SumaTotalCuota()})";
            }
            AgregarBoton(dgvDatos2);
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

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos.Rows[index].Selected = true;
            int Id = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdContrato"].Value.ToString());
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmRegistrarPago frm = new frmRegistrarPago(Id);
            //si exsite el boton
            if (e.ColumnIndex == dgvDatos.Columns["colMixta"].Index)
            {
                frmPrincipal.loadform(frm);
            }

        }
        public void GraficarClientesAtrasadosPorMes(DataGridView dataGridView1, Chart chart1)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());

            var ordenMeses = new Dictionary<string, int>
    {
        {"Enero", 1}, {"Febrero", 2}, {"Marzo", 3}, {"Abril", 4}, {"Mayo", 5}, {"Junio", 6},
        {"Julio", 7}, {"Agosto", 8}, {"Septiembre", 9}, {"Octubre", 10}, {"Noviembre", 11}, {"Diciembre", 12}
    };

            var colores = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown,
                               Color.Pink, Color.Gray, Color.Cyan, Color.Magenta, Color.Yellow, Color.Lime };

            var resultado = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["MesAtrasado"].Value != null && !row.IsNewRow)
                .GroupBy(row => row.Cells["MesAtrasado"].Value.ToString())
                .Select(g => new { Mes = g.Key, Cantidad = g.Count(), Orden = ordenMeses.ContainsKey(g.Key) ? ordenMeses[g.Key] : 99 })
                .OrderBy(x => x.Orden)
                .ToList();

            if (resultado.Any())
            {
                Series serie = new Series("Clientes Atrasados") { ChartType = SeriesChartType.Column };
                serie["PointWidth"] = "0.1";

                for (int i = 0; i < resultado.Count; i++)
                {
                    var item = resultado[i];
                    int index = serie.Points.AddXY(item.Mes, item.Cantidad);

                    serie.Points[index].Color = colores[i % colores.Length];
                    serie.Points[index].Label = item.Cantidad.ToString();
                    serie.Points[index].LabelForeColor = Color.White;
                    serie.Points[index].Font = new Font("Arial", 18, FontStyle.Bold);
                    serie["LabelStyle"] = "Bottom"; // Posición del texto (encima de la barra)
                }

                chart1.Series.Add(serie);
            }
        }

        private void dgvDatos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) return;
            dgvDatos2.Rows[index].Selected = true;
            int Id = int.Parse(dgvDatos2.Rows[e.RowIndex].Cells["IdContrato"].Value.ToString());
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmRegistrarPago frm = new frmRegistrarPago(Id);
            //si exsite el boton
            if (e.ColumnIndex == dgvDatos2.Columns["colMixta"].Index)
            {
                frmPrincipal.loadform(frm);
            }
        }
    }
}
