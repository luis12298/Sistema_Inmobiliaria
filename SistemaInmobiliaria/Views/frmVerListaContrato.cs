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
    public partial class frmVerListaContrato : Form
    {
        ContratoController contratoC = new ContratoController();
        SettingController settingC = new SettingController();
        FloatingController floatingC = new FloatingController();
        frmInicio _frmInicio;
        public frmVerListaContrato()
        {
            InitializeComponent();
            ListarContatos(lsvDatos);
            settingC.AjustarColumnas(lsvDatos);
            this.Resize += (s, e) => settingC.AjustarColumnas(lsvDatos);
            lsvDatos.Resize += (s, e) => settingC.AjustarColumnas(lsvDatos);
            txtFiltrar.Select();

            PlaceholderController.SetPlaceholder(txtFiltrar, "Buscar dato");
            TextBoxIndent.AplicarIndentacionVisual(txtFiltrar, 30);
        }
        public frmVerListaContrato(frmInicio frmInicio)
        {
            InitializeComponent();
            _frmInicio = frmInicio;
            ListarContatos(lsvDatos);
            TextBoxIndent.AplicarIndentacionVisual(txtFiltrar, 35);
            settingC.AjustarColumnas(lsvDatos);
            this.Resize += (s, e) => settingC.AjustarColumnas(lsvDatos);
            lsvDatos.Resize += (s, e) => settingC.AjustarColumnas(lsvDatos);
            CrearMenuContextual(lsvDatos);
        }

        public void ListarContatos(ListView listView1)
        {

            // Configurar ListView
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            // Obtener datos
            DataTable lotes = contratoC.ListaContratos();

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

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            contratoC.LiveSearch(lsvDatos, txtFiltrar);
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
                        _frmInicio.cobrar(lsvDatos.SelectedItems[0].SubItems[0].Text);
                        this.Close();
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

