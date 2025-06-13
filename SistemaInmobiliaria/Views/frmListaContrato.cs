using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmListaContrato : Form
    {
        ContratoController contratoC = new ContratoController();
        SettingController settingC = new SettingController();
        FloatingController floatingC = new FloatingController();
        private DataTable originalDataTable;
        public int idContratoG;


        public frmListaContrato()
        {
            InitializeComponent();
            ListarContratos();
            new PaginationManager().Setup(dgvDatos, contratoC.CargarContratos(), panel3, 20);

            BootstrapStyler.ApplyBootstrapStyle(txtFiltrar);
            TextBoxIndent.AplicarIndentacionVisual(txtFiltrar, 35);
            PlaceholderController.SetPlaceholder(txtFiltrar, "Filtrar");

            new FloatingController().FloatingLabelInput(txtProyeccion, "Proyeccion total");
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Primary, btnNuevoContrato);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Success, btnEditarContrato);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Danger, btnEliminarContrato);

        }
        public string total()
        {
            return dgvDatos.Rows.Count.ToString();
        }

        async public void ListarContratos()
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
                txtProyeccion.Text = $"L. {SumaTotalCuota()}";
            }
        }
        public string SumaTotalCuota()
        {
            return dgvDatos.Rows
                .Cast<DataGridViewRow>()
                .Sum(row => Convert.ToDouble(row.Cells["CuotaFinal"].Value ?? 0))
                .ToString("N2");
        }
        private void btnNuevoContrato_Click(object sender, EventArgs e)
        {
            frmContrato frm = new frmContrato(this);
            frm.ShowDialog();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltrar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                dgvDatos.DataSource = originalDataTable;
                return;
            }

            // Creamos una copia filtrada
            DataTable filtrada = originalDataTable.Clone();

            foreach (DataRow fila in originalDataTable.Rows)
            {
                if (fila.ItemArray.Any(valor =>
                    valor != null && valor.ToString().ToLower().Contains(filtro)))
                {
                    filtrada.ImportRow(fila);
                }
            }
            lblTotalRegistros.Text = filtrada.Rows.Count.ToString();
            dgvDatos.DataSource = filtrada;
        }





        private void btnEditarContrato_Click(object sender, EventArgs e)
        {
            if (idContratoG == 0)
            {
                var toast = new Toast();
                toast.Show(Toast.ToastType.Warning, "Seleccione un contrato");
                return;
            }
            frmContrato frm = new frmContrato(this, idContratoG);
            frm.ShowDialog();
        }

        private void btnEliminarContrato_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomAlert.ShowConfirm(AlertType.Warning, "Mensaje", "¿Estas seguro de eliminar el contrato?");
            if (result == DialogResult.OK)
            {
                contratoC.EliminarContrato(idContratoG);
                ListarContratos();

            }
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
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            dgvDatos.Rows[index].Selected = true;
            idContratoG = int.Parse(dgvDatos.Rows[e.RowIndex].Cells["IdContrato"].Value.ToString());

        }

        private void dgvDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var columnasFormateadas = new List<string> { "CuotaFinal", "MontoTotal" };

            string nombreColumna = dgvDatos.Columns[e.ColumnIndex].Name;

            if (columnasFormateadas.Contains(nombreColumna) && e.Value != null && e.Value is decimal)
            {
                decimal valor = (decimal)e.Value;
                e.Value = string.Format(new System.Globalization.CultureInfo("es-Hn"), "{0:C2}", valor);
                e.FormattingApplied = true;
            }
        }

        private void dgvDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el DataGridView que generó el evento
                DataGridView dgv = sender as DataGridView;

                // Seleccionar la celda en la que se hizo clic derecho
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // Crear el menú contextual
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                // Opción "Copiar"
                var copyCell = new ToolStripMenuItem("Copiar");
                copyCell.Click += (s, ev) =>
                {
                    if (dgv.SelectedCells.Count > 1)
                    {
                        // Copiar rango de celdas seleccionadas
                        StringBuilder sb = new StringBuilder();
                        int minRow = dgv.SelectedCells.Cast<DataGridViewCell>().Min(c => c.RowIndex);
                        int maxRow = dgv.SelectedCells.Cast<DataGridViewCell>().Max(c => c.RowIndex);
                        int minCol = dgv.SelectedCells.Cast<DataGridViewCell>().Min(c => c.ColumnIndex);
                        int maxCol = dgv.SelectedCells.Cast<DataGridViewCell>().Max(c => c.ColumnIndex);

                        for (int row = minRow; row <= maxRow; row++)
                        {
                            List<string> rowValues = new List<string>();
                            for (int col = minCol; col <= maxCol; col++)
                            {
                                var cell = dgv.Rows[row].Cells[col];
                                rowValues.Add(cell.Value?.ToString() ?? "");
                            }
                            sb.AppendLine(string.Join("\t", rowValues));
                        }

                        Clipboard.SetText(sb.ToString());
                    }
                    else if (dgv.CurrentCell != null && !dgv.CurrentCell.IsInEditMode)
                    {
                        Clipboard.SetText(dgv.CurrentCell.Value?.ToString());
                    }
                };
                contextMenu.Items.Add(copyCell);

                // Opción "Copiar toda la fila"
                var copyRow = new ToolStripMenuItem("Copiar fila");
                copyRow.Click += (s, ev) =>
                {
                    if (dgv.CurrentRow != null)
                    {
                        var row = dgv.CurrentRow;
                        string rowData = "";

                        // Concatenar los valores de todas las celdas de la fila
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                rowData += cell.Value.ToString() + "\t"; // Separador de tabulación
                            }
                        }

                        // Copiar al portapapeles
                        Clipboard.SetText(rowData.TrimEnd('\t'));
                    }
                };
                contextMenu.Items.Add(copyRow);

                // Opción "Copiar fila con encabezados"
                var copyRowWithHeaders = new ToolStripMenuItem("Copiar fila con encabezado");
                copyRowWithHeaders.Click += (s, ev) =>
                {
                    if (dgv.CurrentRow != null)
                    {
                        var row = dgv.CurrentRow;
                        StringBuilder sb = new StringBuilder();

                        // Agregar encabezados
                        foreach (DataGridViewColumn column in dgv.Columns)
                        {
                            sb.Append(column.HeaderText + "\t");
                        }
                        sb.AppendLine();

                        // Agregar valores de la fila
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            sb.Append((cell.Value?.ToString() ?? "") + "\t");
                        }

                        // Copiar al portapapeles
                        Clipboard.SetText(sb.ToString().TrimEnd('\t'));
                    }
                };
                contextMenu.Items.Add(copyRowWithHeaders);

                // Mostrar el menú contextual en la posición del clic derecho
                contextMenu.Show(dgv, dgv.PointToClient(Cursor.Position));
            }

        }

    }
}

