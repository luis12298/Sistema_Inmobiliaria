using SistemaInmobiliaria.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{
    internal class CasaController
    {
        Conexion conexion = new Conexion();
        public DataTable ListarCasas()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Casa", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void LiveSearch(ListView listView1, TextBox searchBox)
        {
            string filter = searchBox.Text.ToLower();

            // Guardamos una copia de los elementos originales (solo la primera vez)
            if (listView1.Tag == null)
            {
                listView1.Tag = new List<ListViewItem>();
                foreach (ListViewItem item in listView1.Items)
                {
                    // Clonamos el item para evitar problemas de referencia
                    ListViewItem clonedItem = (ListViewItem)item.Clone();
                    ((List<ListViewItem>)listView1.Tag).Add(clonedItem);
                }
            }

            // Limpiamos la lista actual
            listView1.Items.Clear();

            // Si el filtro está vacío, restauramos todos los elementos
            if (string.IsNullOrEmpty(filter))
            {
                foreach (ListViewItem originalItem in (List<ListViewItem>)listView1.Tag)
                {
                    listView1.Items.Add((ListViewItem)originalItem.Clone());
                }
                return;
            }

            // Filtramos y agregamos solo los elementos que coincidan
            bool anyMatch = false;
            foreach (ListViewItem originalItem in (List<ListViewItem>)listView1.Tag)
            {
                bool matchesFilter = false;
                foreach (ListViewItem.ListViewSubItem subItem in originalItem.SubItems)
                {
                    if (subItem.Text.ToLower().Contains(filter))
                    {
                        matchesFilter = true;
                        anyMatch = true;
                        break;
                    }
                }

                if (matchesFilter)
                {
                    listView1.Items.Add((ListViewItem)originalItem.Clone());
                }
            }

            // Opcional: Mostrar un mensaje si no hay coincidencias
            if (!anyMatch)
            {
                //listView1.Items.BackColor = Color.LightYellow;
                //noResultsItem.ForeColor = Color.DarkRed;

            }
        }
    }
}
