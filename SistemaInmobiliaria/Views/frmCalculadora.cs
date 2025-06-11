using Microsoft.Reporting.WinForms;
using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Views
{
    public partial class frmCalculadora : Form
    {
        FloatingController floatingC = new FloatingController();
        SettingController settingC = new SettingController();
        public frmCalculadora()
        {
            InitializeComponent();
            agregarColumnas();
            //tab1
            floatingC.FloatingLabelInput(txtMonto, "Monto");
            floatingC.FloatingLabelInput(txtPrima, "Prima");
            floatingC.FloatingLabelInput(txtInteres, "Interes");
            floatingC.FloatingLabelInput(txtAnios, "Años");
            //tab2
            floatingC.FloatingLabelInput(txtCuota2, "Cuota definida");
            floatingC.FloatingLabelInput(txtMonto2, "Monto");
            floatingC.FloatingLabelInput(txtPrima2, "Prima");
            floatingC.FloatingLabelInput(txtInteres2, "Interes");
            txtCuota2.TextChanged += (sender, e) => formatear(txtCuota2, txtCuota2_TextChanged);
            txtMonto2.TextChanged += (sender, e) => formatear(txtMonto2, txtMonto2_TextChanged);
            txtPrima.TextChanged += (sender, e) => formatear(txtPrima, txtPrima_TextChanged);
            txtPrima2.TextChanged += (sender, e) => formatear(txtPrima2, txtPrima2_TextChanged);
            txtMonto.TextChanged += (sender, e) => formatear(txtMonto, txtMonto_TextChanged);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Success, btnEjecutar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Success, btnEjecutar2);
            ApplyBootstrapToAllTextBoxes(this);
            txtDia.Font = new Font("Segoe UI", 11.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtDia2.Font = new Font("Segoe UI", 11.75F, FontStyle.Regular, GraphicsUnit.Point);
        }
        private void formatear(TextBox txt, EventHandler handler)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
                return;

            int cursorPos = txt.SelectionStart;
            string textoLimpio = txt.Text.Replace(",", "");
            txt.TextChanged -= handler;

            if (decimal.TryParse(textoLimpio, out decimal valorDecimal))
            {
                string nuevoTexto;

                if (textoLimpio.Contains('.'))
                {
                    string[] partes = textoLimpio.Split('.');
                    string parteEntera = partes[0];
                    string parteDecimal = partes.Length > 1 ? partes[1] : "";

                    if (long.TryParse(parteEntera, out long entero))
                    {
                        nuevoTexto = $"{entero:N0}.{parteDecimal}";
                    }
                    else
                    {
                        nuevoTexto = textoLimpio;
                    }
                }
                else
                {
                    nuevoTexto = valorDecimal.ToString("N0");
                }

                if (cursorPos > 0)
                {
                    int digitosAntesDelCursor = txt.Text
                        .Substring(0, cursorPos)
                        .Replace(",", "")
                        .Length;

                    int nuevaPosicion = 0;
                    int digitosEncontrados = 0;

                    foreach (char c in nuevoTexto)
                    {
                        if (digitosEncontrados >= digitosAntesDelCursor)
                            break;

                        if (char.IsDigit(c))
                            digitosEncontrados++;

                        nuevaPosicion++;
                    }

                    cursorPos = nuevaPosicion;
                }

                txt.Text = nuevoTexto;
                txt.SelectionStart = cursorPos;
            }

            txt.TextChanged += handler;
        }

        private void txtCuota2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMonto2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCuota2.Text) || string.IsNullOrEmpty(txtMonto2.Text))
            {
                MessageBox.Show("Ingrese todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double total;
            double anios;
            total = double.Parse(txtMonto2.Text) / double.Parse(txtCuota2.Text);
            anios = total / 12;
            txtAnios2.Text = anios.ToString("N2");
            txtMeses2.Text = total.ToString();
            if (string.IsNullOrEmpty(txtInteres2.Text))
            {
                txtInteres2.Text = "0";
            }
            double prima = 0;
            double montoOriginal = double.Parse(txtMonto2.Text);
            if (!string.IsNullOrWhiteSpace(txtPrima2.Text))
                double.TryParse(txtPrima2.Text, out prima);

            double montoCalculado = montoOriginal - prima;
            GenerarPlanDeAmortizacion2(montoCalculado);
        }
        private void agregarColumnas()
        {
            dgvAmortizacion.Columns.Add("Periodo", "Periodo");
            dgvAmortizacion.Columns.Add("fecha", "Fecha");
            dgvAmortizacion.Columns.Add("principal", "Cuota principal");
            dgvAmortizacion.Columns.Add("cuota", "Cuota interes");
            dgvAmortizacion.Columns.Add("interes", "Interes");
            dgvAmortizacion.Columns.Add("saldo", "Saldo");
            settingC.AjustarColumnas(dgvAmortizacion);
        }
        public void CalcularFechaProximoMes(int diaDelMes)
        {
            DateTime fechaActual = DateTime.Now;

            // Sumar un mes a la fecha actual
            DateTime siguienteMes = fechaActual.AddMonths(1);

            // Obtener el último día válido del siguiente mes
            int ultimoDiaDelMes = DateTime.DaysInMonth(siguienteMes.Year, siguienteMes.Month);

            // Asegurarse de que el día proporcionado no exceda el último día del mes
            int diaValido = Math.Min(diaDelMes, ultimoDiaDelMes);

            // Crear la nueva fecha con el día deseado (ajustado si es necesario)
            DateTime fechaPersonalizada = new DateTime(siguienteMes.Year, siguienteMes.Month, diaValido);

            // Asignar el valor al control DateTimePicker
            dtpInicio.Value = fechaPersonalizada;
            dtpInicio2.Value = fechaPersonalizada;
        }
        private void ApplyBootstrapToAllTextBoxes(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    BootstrapStyler.ApplyBootstrapStyle(textBox);
                }
                else if (control.HasChildren)
                {
                    ApplyBootstrapToAllTextBoxes(control);
                }
            }
        }
        private void txtDia_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaProximoMes((int)txtDia.Value);
        }
        private void GenerarPlanDeAmortizacion2(double principal)
        {
            double tasaInteresAnual = double.Parse(txtInteres2.Text); // Porcentaje anual, ej: 12
            double tasaInteresMensual = tasaInteresAnual / 100 / 12; // Convertimos a tasa mensual (ej. 0.01)
            double periodos = double.Parse(txtMeses2.Text); // Número de meses

            // Obtener la fecha inicial (día 30 del mes siguiente)
            int diaPago = (int)txtDia.Value;

            // Calcular fecha inicial con día personalizado en el mes siguiente
            DateTime fechaActual = DateTime.Now;
            DateTime siguienteMes = fechaActual;

            // Asegurar que el día no supere el último día del mes siguiente
            int ultimoDiaMes = DateTime.DaysInMonth(siguienteMes.Year, siguienteMes.Month);
            int diaValido = Math.Min(diaPago, ultimoDiaMes);

            DateTime fechaInicial = new DateTime(siguienteMes.Year, siguienteMes.Month, diaValido);

            // Calcular la cuota fija mensual
            double cuota;
            bool interesCero = tasaInteresMensual == 0;

            //if (interesCero)
            //    cuota = principal / periodos;
            //else
            //    cuota = (principal * tasaInteresMensual) / (1 - Math.Pow(1 + tasaInteresMensual, -periodos));
            cuota = double.Parse(txtCuota2.Text);
            // Limpiar DataGridView
            dgvAmortizacion.Rows.Clear();

            double saldo = principal;
            double totalIntereses = 0;
            double totalAmortizacion = 0;

            // Agregar la primera fila con el saldo inicial (sin fecha)
            dgvAmortizacion.Rows.Add("0", "", "", "", "", saldo.ToString("C2"));

            // Generar tabla de amortización
            for (int i = 1; i <= periodos; i++)
            {
                DateTime fechaPago = fechaInicial.AddMonths(i);

                double interes = interesCero ? 0 : Math.Round(saldo * tasaInteresMensual, 2);
                double amortizacion = Math.Round(cuota - interes, 2);
                saldo = Math.Round(saldo - amortizacion, 2);

                // Corregir redondeo final del último saldo
                if (i == periodos)
                {
                    amortizacion += saldo;
                    saldo = 0;
                }

                totalIntereses += interes;
                totalAmortizacion += amortizacion;
                txtCuotaFinal2.Text = cuota.ToString("C2");
                dgvAmortizacion.Rows.Add(
                    i,
                    fechaPago.ToShortDateString(),
                    cuota.ToString("C2"),
                    amortizacion.ToString("C2"),
                    interes.ToString("C2"),
                    saldo.ToString("C2")
                );
            }

            // Opcional: mostrar totales al final
            //dgvAmortizacion.Rows.Add("Total", "", "", totalAmortizacion.ToString("C2"), totalIntereses.ToString("C2"), "");
        }

        private void btnEjecutar2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnios.Text) ||

        string.IsNullOrWhiteSpace(txtMonto.Text) ||
        !double.TryParse(txtMonto.Text, out double montoOriginal))
            {
                MessageBox.Show("Ingrese todos los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtInteres.Text))
            {
                txtInteres.Text = "0";
            }

            double prima = 0;
            if (!string.IsNullOrWhiteSpace(txtPrima.Text))
                double.TryParse(txtPrima.Text, out prima);

            double montoCalculado = montoOriginal - prima;
            CalcularFechaProximoMes((int)txtDia2.Value);
            GenerarPlanDeAmortizacion(montoCalculado);


        }
        private double sumaCuotas()
        {
            double sumaCuotas = 0;

            foreach (DataGridViewRow row in dgvAmortizacion.Rows)
            {
                // Evita la fila nueva que aparece al final si AllowUserToAddRows está activado
                if (row.IsNewRow) continue;

                var cellValue = row.Cells["principal"].Value;

                if (cellValue != null)
                {
                    string valorTexto = cellValue.ToString().Replace("L", "").Trim();

                    if (double.TryParse(valorTexto, System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out double cuota))
                    {
                        sumaCuotas += cuota;
                    }
                }
            }

            return sumaCuotas;
        }

        private void GenerarPlanDeAmortizacion(double principal)
        {
            double tasaInteresAnual = double.Parse(txtInteres.Text); // Porcentaje anual, ej: 12
            double tasaInteresMensual = tasaInteresAnual / 100 / 12; // Convertimos a tasa mensual (ej. 0.01)
            double periodos = double.Parse(txtMeses.Text); // Número de meses

            // Obtener la fecha inicial (día 30 del mes siguiente)
            int diaPago = (int)txtDia2.Value;

            // Calcular fecha inicial con día personalizado en el mes siguiente
            DateTime fechaActual = DateTime.Now;
            DateTime siguienteMes = fechaActual;

            // Asegurar que el día no supere el último día del mes siguiente
            int ultimoDiaMes = DateTime.DaysInMonth(siguienteMes.Year, siguienteMes.Month);
            int diaValido = Math.Min(diaPago, ultimoDiaMes);

            DateTime fechaInicial = new DateTime(siguienteMes.Year, siguienteMes.Month, diaValido);

            // Calcular la cuota fija mensual
            double cuota;
            bool interesCero = tasaInteresMensual == 0;

            if (interesCero)
                cuota = principal / periodos;
            else
                cuota = (principal * tasaInteresMensual) / (1 - Math.Pow(1 + tasaInteresMensual, -periodos));

            // Limpiar DataGridView
            dgvAmortizacion.Rows.Clear();

            double saldo = principal;
            double totalIntereses = 0;
            double totalAmortizacion = 0;

            // Agregar la primera fila con el saldo inicial (sin fecha)
            dgvAmortizacion.Rows.Add("0", "", "", "", "", saldo.ToString("C2"));

            // Generar tabla de amortización
            for (int i = 1; i <= periodos; i++)
            {
                DateTime fechaPago = fechaInicial.AddMonths(i);

                double interes = interesCero ? 0 : Math.Round(saldo * tasaInteresMensual, 2);
                double amortizacion = Math.Round(cuota - interes, 2);
                saldo = Math.Round(saldo - amortizacion, 2);

                // Corregir redondeo final del último saldo
                if (i == periodos)
                {
                    amortizacion += saldo;
                    saldo = 0;
                }

                totalIntereses += interes;
                totalAmortizacion += amortizacion;
                dgvAmortizacion.Rows.Add(
                    i,
                    fechaPago.ToShortDateString(),
                    cuota.ToString("C2"),
                    amortizacion.ToString("C2"),
                    interes.ToString("C2"),
                    saldo.ToString("C2")
                );
                txtCuota.Text = cuota.ToString("C2");

            }

            // Opcional: mostrar totales al final
            //dgvAmortizacion.Rows.Add("Total", "", "", totalAmortizacion.ToString("C2"), totalIntereses.ToString("C2"), "");
        }
        public void Calcularmeses()
        {
            decimal cantidad;
            if (decimal.TryParse(txtAnios.Text, out cantidad))
            {
                txtMeses.Text = (cantidad * 12).ToString("0.##"); // Muestra sin decimales si es exacto, o con hasta 2 si es decimal
            }
            else
            {
                txtMeses.Text = "0";
            }

        }


        private void txtMonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrima_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnios_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnios.Text))
            {
                txtMeses.Clear();
                dtpInicio.Value = DateTime.Now;
                return; // Opcional: evitar seguir con Calcularmeses si no hay años
            }
            Calcularmeses();
        }

        private void txtPrima2_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirDataGridView(dgvAmortizacion);
        }

        private int currentRow = 0;

        private void ImprimirDataGridView(DataGridView dgv)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                int cellHeight = 22;
                int maxHeight = e.MarginBounds.Bottom;
                int availableWidth = e.MarginBounds.Width;

                // Calcular ancho dinámico de columnas
                int numColumns = dgv.Columns.Count;
                int cellWidth = availableWidth / numColumns; // Ajuste automático

                // Encabezados
                for (int j = 0; j < numColumns; j++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, x, y, cellWidth, 30);
                    e.Graphics.DrawString(dgv.Columns[j].HeaderText,
                                          new Font("Arial", 10, FontStyle.Bold),
                                          Brushes.Black,
                                          new RectangleF(x, y, cellWidth, 30));
                    x += cellWidth;
                }

                y += 30;
                x = e.MarginBounds.Left;

                // Filas
                while (currentRow < dgv.Rows.Count)
                {
                    if (y + cellHeight > maxHeight)
                    {
                        e.HasMorePages = true;
                        return; // Salta a la siguiente página
                    }

                    for (int j = 0; j < numColumns; j++)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x, y, cellWidth, cellHeight);
                        object value = dgv.Rows[currentRow].Cells[j].Value;
                        e.Graphics.DrawString(value != null ? value.ToString() : "",
                                              new Font("Arial", 10),
                                              Brushes.Black,
                                              new RectangleF(x, y, cellWidth, cellHeight));
                        x += cellWidth;
                    }

                    x = e.MarginBounds.Left;
                    y += cellHeight;
                    currentRow++;
                }

                currentRow = 0;
                e.HasMorePages = false;
            };

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument;
            previewDialog.WindowState = FormWindowState.Maximized;
            previewDialog.ShowDialog();
        }

        private void btnImprimir2_Click(object sender, EventArgs e)
        {
            ImprimirDataGridView(dgvAmortizacion);
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            ImprimirDataGridView(dgvAmortizacion);
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
    }
}

