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
    public partial class frmListaLote : Form
    {
        LoteController loteC = new LoteController();
        SettingController settingC = new SettingController();
        FloatingController floatingC = new FloatingController();
        frmContrato _frmContrato;
        public frmListaLote()
        {

            InitializeComponent();
            label1.Visible = false;
            floatingC.FloatingLabelInput(txtFiltrar, "Buscar dato");
            CargarLotes();
            settingC.AjustarColumnas(listView1);
            this.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            listView1.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            //altura del form
            this.Height = 800;
        }
        public frmListaLote(frmContrato frmContrato)
        {

            InitializeComponent();
            floatingC.FloatingLabelInput(txtFiltrar, "Buscar dato");
            CargarLotes();
            settingC.AjustarColumnas(listView1);
            this.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            listView1.Resize += (s, e) => settingC.AjustarColumnas(listView1);
            //altura del form
            this.Height = 800;
            _frmContrato = frmContrato;
            //evitar salto de linea al presionar enter
            txtFiltrar.KeyPress += (s, e) => e.Handled = e.KeyChar == (char)Keys.Enter;
        }
        public void CargarLotes()
        {
            // Configurar ListView
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            // Obtener datos
            DataTable lotes = loteC.ListarLotes();

            // Agregar columnas automáticamente
            foreach (DataColumn column in lotes.Columns)
            {
                listView1.Columns.Add(column.ColumnName);


            }

            // Agregar filas con formato en la columna Precio (índice 3)
            foreach (DataRow row in lotes.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                //negrito
                for (int i = 1; i < lotes.Columns.Count; i++)
                {
                    if (i == 4 && decimal.TryParse(row[i].ToString(), out decimal precio))
                    {
                        // Formato moneda con cultura de Honduras
                        string precioFormateado = string.Format(new System.Globalization.CultureInfo("es-HN"), "{0:C2}", precio);
                        item.SubItems.Add(precioFormateado);
                    }
                    else
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                }

                listView1.Items.Add(item);
            }
        }


        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {

        }


        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (_frmContrato == null) return;
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int id = int.Parse(selectedItem.SubItems[0].Text);
                string numero = selectedItem.SubItems[1].Text;
                string metros = selectedItem.SubItems[2].Text;
                string varas = selectedItem.SubItems[3].Text;
                string precio = selectedItem.SubItems[4].Text;
                string Estado = selectedItem.SubItems[5].Text;
                string descripcion = selectedItem.SubItems[6].Text;
                _frmContrato.CargarLote(id, numero, precio, Estado, metros, varas, descripcion);

                this.Close();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún ítem.");
            }


        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //si se presiona enter se hace el filtrado
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    loteC.LiveSearch(listView1, txtFiltrar);
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
