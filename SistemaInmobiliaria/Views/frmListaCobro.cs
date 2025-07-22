using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Properties;
using System;
using System.Collections;
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
    public partial class frmListaCobro : Form
    {
        SettingController settingC = new SettingController();
        ContratoController contratoC = new ContratoController();
        PaginationManager paginationManager = new PaginationManager();
        Toast toast = new Toast();
        private string _textoInicial;

        public int IdContratoG = 0;

        public frmListaCobro()
        {
            InitializeComponent();

            BootstrapStyler.ApplyBootstrapStyle(txtFiltrar);
            TextBoxIndent.AplicarIndentacionVisual(txtFiltrar, 35);
            PlaceholderController.SetPlaceholder(txtFiltrar, "Filtrar");

            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Warning, btnRegistrarPago);
            CargarDatos();

        }
        public frmListaCobro(string nombre)
        {
            InitializeComponent();

            BootstrapStyler.ApplyBootstrapStyle(txtFiltrar);
            TextBoxIndent.AplicarIndentacionVisual(txtFiltrar, 35);
            PlaceholderController.SetPlaceholder(txtFiltrar, "Filtrar");

            BootstrapButton.AplicarEstiloBootstrap(BootstrapButton.ButtonType.Warning, btnRegistrarPago);
            CargarDatos();
            this.Shown += (s, e) =>
            {
                txtFiltrar.Text = nombre;

            };
        }


        private async void CargarDatos()
        {

            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, dgvDatos, new object[] { true });

            // 2. Suspende el layout durante la actualización
            dgvDatos.SuspendLayout();

            try
            {
                // 3. Carga los datos en segundo plano
                var datos = await Task.Run(() => contratoC.CargarContratos());

                // 4. Actualiza el DataGridView de una sola vez
                dgvDatos.DataSource = datos;
                originalDataTable = datos.Copy();
                paginationManager.Setup(dgvDatos, datos, panel3, 20);
                settingC.AjustarColumnas(dgvDatos);
            }
            finally
            {
                // 5. Reanuda el layout
                dgvDatos.ResumeLayout();
                settingC.AjustarColumnas(dgvDatos);
                dgvDatos.Columns["IdLote"].Visible = false;
                //sumar total de registros
                lblTotalRegistros.Text = dgvDatos.Rows.Count.ToString();
                dgvDatos.CellFormatting += (sender, e) =>
                {
                    var columnasFormateadas = new List<string> { "CuotaFinal", "MontoTotal" };

                    string nombreColumna = dgvDatos.Columns[e.ColumnIndex].Name;

                    if (columnasFormateadas.Contains(nombreColumna) && e.Value != null && e.Value is decimal)
                    {
                        decimal valor = (decimal)e.Value;
                        e.Value = string.Format(new System.Globalization.CultureInfo("es-Hn"), "{0:C2}", valor);
                        e.FormattingApplied = true;
                    }
                };
            }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (IdContratoG == 0)
            {
                toast.Show(Toast.ToastType.Warning, "Seleccione un contrato");
                return;
            }
            else
            {
                frmInicio frmPrincipal = (frmInicio)this.Parent.FindForm();
                frmRegistrarPago frm = new frmRegistrarPago(IdContratoG);

                frmPrincipal.loadform(frm);
            }
            frmInicio formPrincipal = Application.OpenForms.OfType<frmInicio>().FirstOrDefault();

            if (formPrincipal != null) // Verificar que el formulario exista
            {


                // O mejor, si tienes un método público en frmInicio:
                formPrincipal.SetRutaText("Contratos / Tramites / Cobrar");
            }


        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            dgvDatos.Rows[index].Selected = true;
            IdContratoG = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdContrato"].Value.ToString());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frmInicio formPrincipal = Application.OpenForms.OfType<frmInicio>().FirstOrDefault();

            // Si existe el formulario principal, mostrar su panel de inicio
            if (formPrincipal != null)
            {
                formPrincipal.SetRutaText("Inicio");
                formPrincipal.loadform(new frmDashboard());
            }

            // Cerrar este formulario
            this.Close();
        }
        private DataTable originalDataTable;

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            var dt = dgvDatos.DataSource as DataTable;
            if (dt == null) return;

            string filtro = txtFiltrar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                var condiciones = new List<string>();

                foreach (DataColumn columna in dt.Columns)
                {
                    // Puedes quitar el chequeo de tipo si quieres filtrar todo
                    condiciones.Add($"CONVERT([{columna.ColumnName}], 'System.String') LIKE '%{filtro}%'");
                }

                dt.DefaultView.RowFilter = string.Join(" OR ", condiciones);
            }

            lblTotalRegistros.Text = dt.DefaultView.Count.ToString();

        }
    }
}