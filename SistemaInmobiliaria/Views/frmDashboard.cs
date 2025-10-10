using FontAwesome.Sharp;
using Handy.DotNETCoreCompatibility.ColourTranslations;
using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmDashboard : Form
    {

        public DataGridView _DataGridView { get; set; }
        public frmDashboard()
        {
            InitializeComponent();
            var dt = new ReporteController().CargarCobrosMes();
            int totalPagados = dt.AsEnumerable()
                               .Count(row => row.Field<string>("Estado") == "Pagado");
            lblTotalDeudas.Text = new ReporteController().CargarClientesAtrasados().Rows.Count.ToString();
            lblTotalCob.Text = new ReporteController().CargarCobrosMes().Rows.Count - totalPagados + " de " + dt.Rows.Count.ToString();



            lblPorcentaje.Text = totalPagados.ToString() + " de " + dt.Rows.Count.ToString();
            lblPorcentaj.Text = (totalPagados / (double)dt.Rows.Count * 100)
                     .ToString("F2") + "%";   // 2 decimales fijos

            lblTotalCon.Text = new ContratoController().CargarContratos().Rows.Count.ToString();
            lblTotalLote.Text = new LoteController().CargarLotes().Rows.Count.ToString();
            DataTable clientes = new ReporteController().CargarClientesAtrasados();
            GraficarClientesAtrasadosPorMes(clientes, chart1);
            GraficarPorcentajePagos(totalPagados, dt.Rows.Count, chart2);
            GraficarCobradosVsEsperados(totalPagados, dt.Rows.Count, chart3);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Danger, btnMostrarAtra, BootstrapButton.ButtonSize.Normal);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Secondary, btnMostrarCob);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Success, btnMostrarSus);
            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Primary, btnMostrarLote);

            this.Resize += (s, e) =>
            {
                container.Location = new Point(
                   (this.ClientSize.Width - container.Width) / 2,
                   (container.Location.Y)
               );
            };
        }





        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void GraficarClientesAtrasadosPorMes(DataTable dt, Chart chart1)
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

            var resultado = dt.AsEnumerable()
                .Where(row => row["MesAtrasado"] != DBNull.Value)
                .GroupBy(row => row["MesAtrasado"].ToString())
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
                    serie.Points[index].LabelForeColor = Color.Black;
                    serie.Points[index].Font = new Font("Arial", 18, FontStyle.Bold);
                    serie["LabelStyle"] = "Top"; // Posición del texto encima de la barra
                }

                chart1.Series.Add(serie);
            }
        }

        public void GraficarPorcentajePagos(int totalPagados, int totalEsperados, Chart chart2)
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.ChartAreas.Add(new ChartArea());

            Series serie = new Series("PorcentajePagos") { ChartType = SeriesChartType.Pie };
            serie.Points.AddXY("", totalPagados);
            serie.Points.AddXY("", totalEsperados - totalPagados);

            foreach (var point in serie.Points)
            {
                point.Label = $" {point.YValues[0]} ({point.YValues[0] / (double)totalEsperados * 100:F2}%)";
                point.LabelForeColor = Color.Black;
                point.Font = new Font("Arial", 12, FontStyle.Bold);
            }

            chart2.Series.Add(serie);
        }
        public void GraficarCobradosVsEsperados(int totalPagados, int totalEsperados, Chart chart3)
        {
            chart3.Series.Clear();
            chart3.ChartAreas.Clear();
            chart3.ChartAreas.Add(new ChartArea());

            Series serie = new Series("Cobros") { ChartType = SeriesChartType.FastLine };
            serie.Points.AddXY("Esperados", totalEsperados);
            serie.Points.AddXY("Cobrados", totalPagados);

            foreach (var point in serie.Points)
            {
                point.Label = point.YValues[0].ToString();
                point.LabelForeColor = Color.Black;
                point.Font = new Font("Arial", 14, FontStyle.Bold);
            }

            chart3.Series.Add(serie);
        }
        private void dgvDatos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgvDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvDatos2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnRecordatorio_Click(object sender, EventArgs e)
        {



        }




        private void btnWhatsApp_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrarAtra_Click(object sender, EventArgs e)
        {
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmPrincipal.loadform(new frmAtrasados());
        }

        private void btnMostrarCob_Click(object sender, EventArgs e)
        {
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmPrincipal.loadform(new frmCobros());
        }

        private void btnMostrarLote_Click(object sender, EventArgs e)
        {
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmPrincipal.loadform(new frmLote());
        }

        private void btnMostrarSus_Click(object sender, EventArgs e)
        {
            frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
            frmPrincipal.loadform(new frmListaContrato());
        }
    }
}