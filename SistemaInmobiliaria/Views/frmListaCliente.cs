using SistemaInmobiliaria.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Views
{
    public partial class frmListaCliente : Form
    {
        SettingController settingC = new SettingController();
        FloatingController floatingC = new FloatingController();
        ClienteController clienteC = new ClienteController();
        frmContrato _frmContrato;
        frmInicio _frmInicio;

        public frmListaCliente()
        {
            InitializeComponent();
            label1.Visible = false;
            floatingC.FloatingLabelInput(txtFiltrar, "Buscar dato");
            CargarClientes();
            settingC.AjustarColumnas(listView1);
            this.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            listView1.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            //altura del form
            this.Height = 800;
            txtFiltrar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (listView1.Items.Count > 0)
                    {
                        listView1.Focus();
                        listView1.Items[0].Selected = true;
                    }

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
        }
        public frmListaCliente(frmInicio frmInicio)
        {
            InitializeComponent();
            _frmInicio = frmInicio;
            label1.Visible = false;
            floatingC.FloatingLabelInput(txtFiltrar, "Buscar dato");
            CargarClientes();
            settingC.AjustarColumnas(listView1);
            this.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            listView1.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            //altura del form
            this.Height = 800;
            CrearMenuContextual(listView1);
            listView1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && listView1.SelectedItems.Count > 0)
                {
                    string idLote = listView1.SelectedItems[0].SubItems[0].Text;
                    if (_frmInicio != null)
                    {
                        _frmInicio.Cobrar2(listView1.SelectedItems[0].SubItems[2].Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }

                    // Prevenir que suene el "ding"
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
            txtFiltrar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (listView1.Items.Count > 0)
                    {
                        listView1.Focus();
                        listView1.Items[0].Selected = true;
                    }

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
        }
        public frmListaCliente(frmContrato frmContrato)
        {
            InitializeComponent();
            floatingC.FloatingLabelInput(txtFiltrar, "Buscar dato");
            CargarClientes();
            settingC.AjustarColumnas(listView1);
            this.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            listView1.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            //altura del form
            this.Height = 800;
            _frmContrato = frmContrato;
            listView1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && listView1.SelectedItems.Count > 0)
                {
                    //definir por cual constructo vengo
                    if (_frmContrato != null)
                    {
                        _frmContrato.CargarCliente(listView1.SelectedItems[0].SubItems[0].Text);
                        this.Close();
                    }

                    // Prevenir que suene el "ding"
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
        }


        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            clienteC.LiveSearch(listView1, txtFiltrar);
        }

        public void CargarClientes()
        {
            // Configurar ListView
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            // Obtener datos
            DataTable lotes = clienteC.ListarClientes();

            // Agregar columnas automáticamente
            foreach (DataColumn column in lotes.Columns)
            {
                listView1.Columns.Add(column.ColumnName);
            }

            // Agregar filas
            foreach (DataRow row in lotes.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < lotes.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                listView1.Items.Add(item);
                //listView1.FullRowSelect = true;
            }

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //definir por cual constructo vengo
            if (_frmContrato != null)
            {
                _frmContrato.CargarCliente(listView1.SelectedItems[0].SubItems[0].Text);
                this.Close();
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
                    string idLote = listView.SelectedItems[0].SubItems[0].Text;
                    if (_frmInicio != null)
                    {
                        _frmInicio.Cobrar2(listView1.SelectedItems[0].SubItems[2].Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("error");
                    }
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
    }
}
