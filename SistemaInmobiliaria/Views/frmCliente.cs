using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SistemaInmobiliaria.Controllers.Alert.SweetAlert;

namespace SistemaInmobiliaria.Views
{
    public partial class frmCliente : Form
    {
        SettingController settingC = new SettingController();
        FloatingController floatingC = new FloatingController();
        ClienteController clienteC = new ClienteController();
        Toast toas = new Toast();
        Alert alert = new Alert();
        public int IdClienteG = 0;
        public frmCliente()
        {
            InitializeComponent();
            floatingC.FloatingLabelInput(txtIdentidad, "Identidad");
            floatingC.FloatingLabelInput(txtNombre, "Nombres");
            floatingC.FloatingLabelInput(txtApellido, "Apellidos");
            floatingC.FloatingLabelInput(txtTelefono, "Telefono");
            floatingC.FloatingLabelInput(txtDireccion, "Direccion");
            floatingC.FloatingLabelInput(txtFiltrar, "Buscar dato");
            ListarClientes();
            settingC.AjustarColumnas(lvDatos);
            this.Resize += (s, e) => settingC.AjustarColumnas(lvDatos);
            lvDatos.Resize += (s, e) => settingC.AjustarColumnas(lvDatos);
            FormatearIdentidad(txtIdentidad);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Success, btnActualizar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Danger, btnEliminar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Primary, btnRegistrar);
            SettingController.AplicarEstiloBootstrap(SettingController.ButtonType.Dark, btnCancelar);
            CrearMenuContextual(lvDatos);
            ApplyBootstrapToAllTextBoxes(this);
            CargarCombo();
            labelResultado.Text = "";
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.ItemHeight = 30;

            comboBox1.DrawItem += (s, e) =>
            {
                if (e.Index < 0) return;

                Font f = comboBox1.Font;
                int itemHeight = comboBox1.ItemHeight;
                string text = comboBox1.Items[e.Index].ToString();

                e.DrawBackground();
                // Cambia color de texto y fondo según selección
                Brush textBrush = (e.State & DrawItemState.Selected) != 0 ? Brushes.White : Brushes.Black;
                Brush backgroundBrush = (e.State & DrawItemState.Selected) != 0 ? Brushes.Blue : Brushes.White;

                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

                // Centrar texto verticalmente
                SizeF textSize = e.Graphics.MeasureString(text, f);
                float yOffset = (itemHeight - textSize.Height) / 2;

                e.Graphics.DrawString(text, f, textBrush, new PointF(e.Bounds.X + 5, e.Bounds.Y + yOffset));

                e.DrawFocusRectangle();
            };

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
        public void ListarClientes()
        {
            lvDatos.View = View.Details;
            lvDatos.Columns.Clear();
            lvDatos.Items.Clear();

            // Obtener datos
            DataTable lotes = clienteC.CargarClientes();

            // Agregar columnas automáticamente
            foreach (DataColumn column in lotes.Columns)
            {
                lvDatos.Columns.Add(column.ColumnName);
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
                lvDatos.Items.Add(item);
                //listView1.FullRowSelect = true;
            }
        }
        private void FormatearIdentidad(TextBox txt)
        {
            void AplicarFormato(object sender, EventArgs e)
            {
                TextBox box = (TextBox)sender;

                // Eliminar todo menos números
                string textoLimpio = new string(box.Text.Where(char.IsDigit).ToArray());

                if (textoLimpio.Length > 13)
                    textoLimpio = textoLimpio.Substring(0, 13); // Limitar a 13 dígitos

                string nuevoTexto = textoLimpio;

                // Insertar guiones según la longitud
                if (nuevoTexto.Length > 4)
                    nuevoTexto = nuevoTexto.Insert(4, "-");
                if (nuevoTexto.Length > 9)
                    nuevoTexto = nuevoTexto.Insert(9, "-");

                int cursorPos = box.SelectionStart;
                int digitosAntesDelCursor = box.Text.Take(cursorPos).Count(char.IsDigit);

                // Calcular nueva posición del cursor
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

                box.TextChanged -= AplicarFormato;
                box.Text = nuevoTexto;
                box.SelectionStart = nuevaPosicion;
                box.TextChanged += AplicarFormato;
            }

            txt.TextChanged -= AplicarFormato;
            txt.TextChanged += AplicarFormato;
            AplicarFormato(txt, EventArgs.Empty);
        }

        //private void FormatearTelefono(TextBox txt)
        //{
        //    void AplicarFormato(object sender, EventArgs e)
        //    {
        //        TextBox box = (TextBox)sender;

        //        // Eliminar todo menos números
        //        string textoLimpio = new string(box.Text.Where(char.IsDigit).ToArray());

        //        if (textoLimpio.Length > 8)
        //            textoLimpio = textoLimpio.Substring(0, 8); // Limitar a 8 dígitos

        //        string nuevoTexto = textoLimpio;

        //        // Insertar guión después del 4º dígito
        //        if (nuevoTexto.Length > 4)
        //            nuevoTexto = nuevoTexto.Insert(4, "-");

        //        int cursorPos = box.SelectionStart;
        //        int digitosAntesDelCursor = box.Text.Take(cursorPos).Count(char.IsDigit);

        //        // Calcular nueva posición del cursor
        //        int nuevaPosicion = 0;
        //        int digitosEncontrados = 0;

        //        foreach (char c in nuevoTexto)
        //        {
        //            if (digitosEncontrados >= digitosAntesDelCursor)
        //                break;

        //            if (char.IsDigit(c))
        //                digitosEncontrados++;

        //            nuevaPosicion++;
        //        }

        //        box.TextChanged -= AplicarFormato;
        //        box.Text = nuevoTexto;
        //        box.SelectionStart = nuevaPosicion;
        //        box.TextChanged += AplicarFormato;
        //    }

        //    txt.TextChanged -= AplicarFormato;
        //    txt.TextChanged += AplicarFormato;
        //    AplicarFormato(txt, EventArgs.Empty);
        //}

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos((txtIdentidad, "Identidad"), (txtNombre, "Nombre"), (txtApellido, "Apellido"), (txtTelefono, "Telefono"), (txtDireccion, "Direccion")))
            {
                GuardarCliente();
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

                    toas.Show(Toast.ToastType.Warning, $"{mensaje} Debe completar todos los campos");
                    campo.caja.Focus();
                    return false;
                }
            }
            return true;
        }


        void LimpiarCampos(params TextBox[] cajas)
        {
            foreach (TextBox caja in cajas)
            {
                caja.Clear();
            }
            labelResultado.Text = string.Empty;
        }
        public void GuardarCliente()
        {
            ClienteModel clienteM = new ClienteModel();
            clienteM.Identificacion = txtIdentidad.Text;
            clienteM.Nombre = txtNombre.Text;
            clienteM.Apellido = txtApellido.Text;
            string prefijo = paises[comboBox1.SelectedItem.ToString()];
            string numero = txtTelefono.Text.Trim().Replace(" ", "").Replace("-", "");
            clienteM.Telefono = prefijo + numero;
            clienteM.Direccion = txtDireccion.Text;
            if (clienteC.GuardarCliente(clienteM))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Cliente registrado con éxito");
                LimpiarCampos(txtIdentidad, txtNombre, txtApellido, txtTelefono, txtDireccion);
                ListarClientes();
                settingC.AjustarColumnas(lvDatos);
            }
            else
            {
                MessageBox.Show("Error al registrar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EditarCliente()
        {
            ClienteModel clienteM = new ClienteModel();
            clienteM.IdCliente = IdClienteG;
            clienteM.Identificacion = txtIdentidad.Text;
            clienteM.Nombre = txtNombre.Text;
            clienteM.Apellido = txtApellido.Text;
            string prefijo = paises[comboBox1.SelectedItem.ToString()];
            string numero = txtTelefono.Text.Trim().Replace(" ", "").Replace("-", "");
            clienteM.Telefono = prefijo + numero;
            clienteM.Direccion = txtDireccion.Text;
            if (clienteC.ActualizarCliente(clienteM))
            {
                CustomAlert.ShowAlert(AlertType.Success, "Mensaje", "Cliente editado con éxito");
                LimpiarCampos(txtIdentidad, txtNombre, txtApellido, txtTelefono, txtDireccion);
                ListarClientes();
                settingC.AjustarColumnas(lvDatos);
            }
            else
            {
                MessageBox.Show("Error al editar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CargarCliente()
        {
            List<string> datosCliente = clienteC.CargarCliente(IdClienteG.ToString());
            if (datosCliente == null) return;
            txtIdentidad.Text = datosCliente[1];
            txtNombre.Text = datosCliente[2];
            txtApellido.Text = datosCliente[3];
            comboBox1.Items.Clear();
            foreach (var item in paises)
            {
                comboBox1.Items.Add(item.Key);
            }

            // Simulamos que el número está en datosCliente[3]
            string telefonoCompleto = datosCliente[4]; // Ej: "+50498765432"

            // Buscar el prefijo correcto
            string prefijoSeleccionado = "";
            string nombreSeleccionado = "";

            foreach (var item in paises)
            {
                if (telefonoCompleto.StartsWith(item.Value))
                {
                    prefijoSeleccionado = item.Value;
                    nombreSeleccionado = item.Key;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(prefijoSeleccionado))
            {
                comboBox1.SelectedItem = nombreSeleccionado;
                txtTelefono.Text = telefonoCompleto.Substring(prefijoSeleccionado.Length);
            }
            else
            {
                // Prefijo no reconocido, dejar en blanco o dar un mensaje
                txtTelefono.Text = telefonoCompleto;
            }
            txtDireccion.Text = datosCliente[5];

        }

        private void lvDatos_Click(object sender, EventArgs e)
        {
            //obtenemos el id
            IdClienteG = Convert.ToInt32(lvDatos.SelectedItems[0].SubItems[0].Text);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdClienteG == 0)
            {
                toas.Show(Toast.ToastType.Warning, "Seleccione un cliente");
                return;
            }
            DialogResult result = CustomAlert.ShowConfirm(AlertType.Warning, "Mensaje", "¿Estas seguro de eliminar el cliente?");

            if (result == DialogResult.OK)
            {
                clienteC.EliminarCliente(IdClienteG);
                new ContratoController().EliminarContratoPorIdCliente(IdClienteG);
                ListarClientes();
                settingC.AjustarColumnas(lvDatos);
            }


        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (IdClienteG == 0)
            {
                MessageBox.Show("Seleccione un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CargarCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(txtIdentidad, txtNombre, txtApellido, txtTelefono, txtDireccion);
            //limpiar seleccion de listview
            IdClienteG = 0;
            lvDatos.SelectedItems.Clear();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            clienteC.LiveSearch(lvDatos, txtFiltrar);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos((txtIdentidad, "Identidad"), (txtNombre, "Nombre"), (txtApellido, "Apellido"), (txtTelefono, "Telefono"), (txtDireccion, "Direccion")))
            {
                EditarCliente();
            }
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
                    string IdCliente = listView.SelectedItems[0].SubItems[0].Text;
                    IdClienteG = int.Parse(IdCliente);
                    CargarCliente();
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
        //paises
        Dictionary<string, string> paises = new Dictionary<string, string>()
        {
            { "Honduras (+504)", "+504" },
            { "EE.UU. (+1)", "+1" },
            { "México (+52)", "+52" },
            { "España (+34)", "+34" },
            { "Canadá (+1)", "+1" },
            { "Reino Unido (+44)", "+44" },
            { "Argentina (+54)", "+54" },
            { "Colombia (+57)", "+57" },
            { "Brasil (+55)", "+55" },
            { "Japón (+81)", "+81" },
            {"Costa Rica (+506)", "+506" },
            {"El Salvador (+503)", "+503" },
            {"Guatemala (+502)", "+502" },
            {"Nicaragua (+505)", "+505" },
            {"Panamá (+507)", "+507" },
            {"Paraguay (+595)", "+595" },
            {"Perú (+51)", "+51" },
            {"Uruguay (+598)", "+598" },
            {"Venezuela (+58)", "+58" }
        };

        private void CargarCombo()
        {
            // Carga los países en el ComboBox
            foreach (var pais in paises)
            {
                comboBox1.Items.Add(pais.Key);
            }

            comboBox1.SelectedIndex = 0; // Seleccionar el primero
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string prefijo = paises[comboBox1.SelectedItem.ToString()];
                string numero = txtTelefono.Text.Trim().Replace(" ", "").Replace("-", "");

                string numeroCompleto = prefijo + numero;

                // Validar: mínimo 10 dígitos luego del prefijo
                if (Regex.IsMatch(numeroCompleto, @"^\+\d{10,15}$"))
                {
                    labelResultado.Text = "✅ Número válido: " + numeroCompleto;
                    labelResultado.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    labelResultado.Text = "❌ Número inválido";
                    labelResultado.ForeColor = System.Drawing.Color.Red;

                }
            }
        }
    }
}
