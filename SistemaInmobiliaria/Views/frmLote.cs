using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmLote : Form
    {
        LoteController loteC = new LoteController();
        FloatingController floatingC = new FloatingController();
        SettingController settingC = new SettingController();
        Toast toast = new Toast();

        public int idLoteG = 0;
        public frmLote()
        {
            InitializeComponent();
            ListarLotes();
            CargarEstados();
            settingC.AjustarColumnas(lsvDatos);
            this.Resize += (s, e) => settingC.AjustarColumnas(lsvDatos);
            lsvDatos.Resize += (s, e) => settingC.AjustarColumnas(lsvDatos);

            floatingC.FloatingLabelInput(txtNo, "No Lote");
            floatingC.FloatingLabelInput(txtMetros, "Metros cuadrados");
            floatingC.FloatingLabelInput(txtVaras, "Varas cuadrados");
            floatingC.FloatingLabelInput(txtPrecio, "Precio");
            floatingC.FloatingLabelInput(txtDescripcion, "Descripcion");
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Primary, btnNuevo);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Success, btnActualizar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Danger, btnEliminar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Dark, btnCancelar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Secondary, btnMostrar);
            Formatear(txtPrecio);
            CrearMenuContextual(lsvDatos);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos((txtNo, "Ingrese #Lote"), (txtMetros, "Ingrese los mts2"), (txtPrecio, "Ingrese precio"), (txtDescripcion, "Ingrese Descripcion")))
            {
                return;
            }
            var validar = loteC.VerificarLote(txtNo.Text);
            if (validar == true)
            {
                toast.Show(Toast.ToastType.Error, "El lote ya se encuentra registrado");
                return;
            }
            GuardarLote();

        }
        public void GuardarLote()
        {
            var toast = new Toast();

            LoteModel loteM = new LoteModel();
            loteM.LoteNo = txtNo.Text;
            loteM.Metros = double.Parse(txtMetros.Text);
            loteM.Varas = double.Parse(txtVaras.Text);
            loteM.Precio = double.Parse(txtPrecio.Text);
            loteM.Estado = cmbEstado.Text;
            loteM.Descripcion = txtDescripcion.Text;
            if (loteC.GuardarLote(loteM))
            {
                //toast.Show(Toast.ToastType.Success, "Lote guardado con éxito");
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Lote guardado con éxito");

                ListarLotes();
                LimpiarCampos(txtNo, txtMetros, txtVaras, txtPrecio, txtDescripcion);

                settingC.AjustarColumnas(lsvDatos);
            }
            else
            {
                //toast.Show(Toast.ToastType.Error, "Error al guardar el lote");
            }

        }
        public void ActualizarLote()
        {
            var toast = new Toast();

            LoteModel loteM = new LoteModel();
            loteM.IdLote = idLoteG;
            loteM.LoteNo = txtNo.Text;
            loteM.Metros = double.Parse(txtMetros.Text);
            loteM.Varas = double.Parse(txtVaras.Text);
            loteM.Precio = double.Parse(txtPrecio.Text);
            loteM.Estado = cmbEstado.Text;
            loteM.Descripcion = txtDescripcion.Text;
            if (loteC.ActualizarLote(loteM))
            {
                //toast.Show(Toast.ToastType.Info, "Lote actualizado con éxito");
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Lote actualizado con éxito");
                ListarLotes();
                LimpiarCampos(txtNo, txtMetros, txtVaras, txtPrecio, txtDescripcion);
                settingC.AjustarColumnas(lsvDatos);
            }
            else
            {
                //toast.Show(Toast.ToastType.Error, "Error al actualizar el lote");
            }
        }
        public void ListarLotes()
        {
            lsvDatos.Columns.Clear();
            lsvDatos.Items.Clear();

            // Obtener datos
            DataTable lotes = loteC.CargarLotes();

            // Agregar columnas automáticamente
            foreach (DataColumn column in lotes.Columns)
            {
                lsvDatos.Columns.Add(column.ColumnName);
                //negrito

            }

            // Agregar filas
            foreach (DataRow row in lotes.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < lotes.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                lsvDatos.Items.Add(item);
                //listView1.FullRowSelect = true;
                lblTotalRegistros.Text = lsvDatos.Items.Count.ToString();
            }
        }
        public bool ValidarCampos(params (TextBox caja, string mensaje)[] campos)
        {
            foreach (var campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.caja.Text))
                {
                    string mensaje = campo.mensaje;

                    // Si el mensaje no termina en punto, lo agregamos por estética
                    if (!mensaje.Trim().EndsWith("."))
                    {
                        mensaje = mensaje.Trim() + ".";
                    }

                    toast.Show(Toast.ToastType.Warning, $"{mensaje} Debe completar todos los campos");
                    campo.caja.Focus();
                    return false;
                }
            }
            return true;
        }
        private void calcularvaras()
        {
            if (string.IsNullOrEmpty(txtMetros.Text))
            {
                txtVaras.Text = string.Empty;
                return;
            };
            double mts2 = double.Parse(txtMetros.Text);
            double varas = mts2 * 1.43426;
            txtVaras.Text = varas.ToString("N2");
        }

        private void txtMetros_TextChanged(object sender, EventArgs e)
        {
            calcularvaras();
        }

        private void lsvDatos_DoubleClick(object sender, EventArgs e)
        {
            string IdLote = lsvDatos.SelectedItems[0].SubItems[0].Text;
            CargarLote(IdLote);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            frmListaLote frm = new frmListaLote();
            frm.ShowDialog();
        }
        public void CargarLote(string idLote)
        {
            List<string> datos = loteC.CargarLote(idLote.ToString());
            if (datos == null) return;
            idLoteG = int.Parse(datos[0]);
            txtNo.Text = datos[1];
            txtMetros.Text = datos[2];
            txtVaras.Text = datos[3];
            txtPrecio.Text = datos[4];
            cmbEstado.Text = datos[5];
            txtDescripcion.Text = datos[6];

        }
        private void CargarEstados()
        {

            var estados = loteC.Estado();
            foreach (var estado in estados)
            {
                cmbEstado.Items.Add(estado);
            }
            cmbEstado.SelectedIndex = 0;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos((txtNo, "Ingrese #Lote"), (txtMetros, "Ingrese los mts2"), (txtPrecio, "Ingrese precio"), (txtDescripcion, "Ingrese Descripcion")))
            {
                return;
            }

            ActualizarLote();

        }
        private void Formatear(TextBox txt)
        {
            void AplicarFormato(object sender, EventArgs e)
            {
                TextBox box = (TextBox)sender;

                if (string.IsNullOrWhiteSpace(box.Text))
                    return;

                int cursorPos = box.SelectionStart;
                string textoLimpio = box.Text.Replace(",", "");

                if (decimal.TryParse(textoLimpio, out decimal valorDecimal))
                {
                    string nuevoTexto;

                    if (textoLimpio.Contains('.'))
                    {
                        string[] partes = textoLimpio.Split('.');
                        string parteEntera = partes[0];
                        string parteDecimal = partes.Length > 1 ? partes[1] : "";

                        if (long.TryParse(parteEntera, out long entero))
                            nuevoTexto = $"{entero:N0}.{parteDecimal}";
                        else
                            nuevoTexto = textoLimpio;
                    }
                    else
                    {
                        nuevoTexto = valorDecimal.ToString("N0");
                    }

                    // Calcular nueva posición del cursor
                    if (cursorPos > 0)
                    {
                        int digitosAntesDelCursor = box.Text
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

                    box.Text = nuevoTexto;
                    box.SelectionStart = cursorPos;
                }
            }

            // Asignar evento y aplicar una vez al iniciar
            txt.TextChanged -= AplicarFormato;
            txt.TextChanged += AplicarFormato;
            AplicarFormato(txt, EventArgs.Empty); // Ejecuta formateo inicial
        }

        private void txtNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }

        private void txtMetros_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
        }
        void CrearMenuContextual(ListView listView)
        {
            // Crear el menú contextual
            ContextMenuStrip menuContextual = new ContextMenuStrip();

            // Agregar la opción "Seleccionar"
            ToolStripMenuItem itemSeleccionar = new ToolStripMenuItem("Seleccionar registro");
            menuContextual.Items.Add(itemSeleccionar);

            // Manejar el evento Click de la opción "Seleccionar"
            itemSeleccionar.Click += (sender, e) =>
            {
                if (listView.SelectedItems.Count > 0)
                {
                    // Obtener el ID del lote seleccionado
                    string idLote = listView.SelectedItems[0].SubItems[0].Text;
                    CargarLote(idLote);
                }
            };

            // Asignar el menú contextual al ListView
            listView.ContextMenuStrip = menuContextual;

            // Opcional: Manejar el evento para mostrar el menú solo cuando se hace clic derecho en un elemento
            listView.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Determinar en qué elemento se hizo clic
                    ListViewItem item = listView.GetItemAt(e.X, e.Y);
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            };
        }
        private void LimpiarCampos(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
            idLoteG = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(txtNo, txtMetros, txtVaras, txtPrecio, txtDescripcion);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (idLoteG == 0)
            {
                MessageBox.Show("Seleccione un lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = CustomAlert.ShowConfirm(AlertType.Warning, "Mensaje", "¿Estas seguro de eliminar el lote?");

            if (result == DialogResult.OK)
            {
                loteC.EliminarLote(idLoteG);
                ListarLotes();
                settingC.AjustarColumnas(lsvDatos);
                LimpiarCampos();
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
    }
}
