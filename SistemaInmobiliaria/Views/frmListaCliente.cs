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
    }
}
