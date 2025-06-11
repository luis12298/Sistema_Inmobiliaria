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
    public partial class frmReporteGeneral : Form
    {
        ReporteGeneralController reporteC = new ReporteGeneralController();
        SettingController settingC = new SettingController();
        public frmReporteGeneral()
        {
            InitializeComponent();
            Mes();
            Semanal();
            Hoy();
            Dias();
        }
        private void Mes()
        {
            List<string> datos = reporteC.ReporteMes();
            if (datos == null) return;
            lblTotalMes.Text = $"Total pagos: {datos[0]}";
            lblMontoMes.Text = $"Monto recibido: {datos[1].ToString()}";

        }
        private void Semanal()
        {
            List<string> datos = reporteC.ReporteSemanal();
            if (datos == null) return;
            lblTotalSemanal.Text = $"Total pagos: {datos[0]}";
            lblMontoSemanal.Text = $"Monto recibido: {datos[1].ToString()}";
        }
        private void Hoy()
        {
            List<string> datos = reporteC.ReporteHoy();
            if (datos == null) return;
            lblTotalHoy.Text = $"Total pagos: {datos[0]}";
            lblMontoHoy.Text = $"Monto recibido: {datos[1].ToString()}";
        }
        async private void Dias()
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
                DataTable datos = await Task.Run(() => reporteC.CargarPagos());

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

                dgvDatos.ResumeLayout();
                settingC.AjustarColumnas(dgvDatos);


            }
        }
    }
}
