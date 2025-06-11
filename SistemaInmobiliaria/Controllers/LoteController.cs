using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaInmobiliaria.Connection;
using SistemaInmobiliaria.Models;

namespace SistemaInmobiliaria.Controllers
{
    internal class LoteController
    {
        Conexion conexion = new Conexion();
        public List<String> Estado()
        {
            List<String> list = new List<String>();
            list.Add("Disponible");
            list.Add("Vendido");
            list.Add("Apartado");
            list.Add("No Disponible");
            return list;
        }
        public DataTable ListarLotes()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Lote", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable CargarLotes()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
                       IdLote,
                       LoteNo,
                        Metros,
                        Varas,
                        Precio,
                        Estado,
                       Descripcion
                       
                    FROM Lote;";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                sqlDataAdapter.Fill(data);
                return data;
            }
        }
        public bool VerificarLote(string NoLote)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT LoteNo FROM Lote WHERE LoteNo = @NoLote", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@NoLote", NoLote);
                    if (sqlCommand.ExecuteScalar() != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public List<string> CargarLote(string buscar)
        {
            List<string> lote = new List<string>();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @" SELECT 
            Lote.IdLote,
            Lote.LoteNo,
            Lote.Metros,
            Lote.Varas,
            Lote.Precio,
            Lote.Estado,
            Lote.Descripcion
            FROM Lote WHERE IdLote = @IdLote;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdLote", buscar);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Solo si hay resultados
                        {
                            lote.Add(sqlDataReader["IdLote"].ToString());
                            lote.Add(sqlDataReader["LoteNo"].ToString());
                            lote.Add(sqlDataReader["Metros"].ToString());
                            lote.Add(sqlDataReader["Varas"].ToString());
                            lote.Add(sqlDataReader["Precio"].ToString());
                            lote.Add(sqlDataReader["Estado"].ToString());
                            lote.Add(sqlDataReader["Descripcion"].ToString());
                        }
                        return lote;
                    }
                }
            }
        }


        public bool GuardarLote(LoteModel loteM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {

                using (SqlCommand sqlCommand = new SqlCommand("sp_Lote_insert", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@LoteNo", loteM.LoteNo);
                    sqlCommand.Parameters.AddWithValue("@Metros", loteM.Metros);
                    sqlCommand.Parameters.AddWithValue("@Varas", loteM.Varas);
                    sqlCommand.Parameters.AddWithValue("@Precio", loteM.Precio);
                    sqlCommand.Parameters.AddWithValue("@Estado", loteM.Estado);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", loteM.Descripcion);
                    sqlCommand.ExecuteNonQuery();
                    try
                    {
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }

                }
            }
        }
        public bool ActualizarLote(LoteModel loteM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_Lote_update", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IdLote", loteM.IdLote);
                    sqlCommand.Parameters.AddWithValue("@LoteNo", loteM.LoteNo);
                    sqlCommand.Parameters.AddWithValue("@Metros", loteM.Metros);
                    sqlCommand.Parameters.AddWithValue("@Varas", loteM.Varas);
                    sqlCommand.Parameters.AddWithValue("@Precio", loteM.Precio);
                    sqlCommand.Parameters.AddWithValue("@Estado", loteM.Estado);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", loteM.Descripcion);
                    sqlCommand.ExecuteNonQuery();
                    try
                    {
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        public bool ActualizarLote2(int IdLote, string Monto, string Estado)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Lote SET Precio = @Monto , Estado = @Estado WHERE IdLote = @IdLote", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdLote", IdLote);
                    sqlCommand.Parameters.AddWithValue("@Monto", double.Parse(Monto));
                    sqlCommand.Parameters.AddWithValue("@Estado", Estado);
                    if (sqlCommand.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool EliminarLote(int IdLote)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Lote WHERE IdLote = @IdLote", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdLote", IdLote);
                    if (sqlCommand.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool LoteVendido(int IdLote)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("UPDATE Lote SET Estado = 'Vendido' WHERE IdLote = @IdLote", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdLote", IdLote);
                    if (sqlCommand.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
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
