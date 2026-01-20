using SistemaInmobiliaria.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaInmobiliaria.Models;
using System.Windows.Forms;
using System.Drawing;

namespace SistemaInmobiliaria.Controllers
{
    internal class ClienteController
    {
        Conexion conexion = new Conexion();
        ClienteModel clienteM = new ClienteModel();
        public DataTable ListarClientes()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT IdCliente,Identificacion, CONCAT(Nombre,' ',Apellido) AS Nombre, Telefono, Direccion FROM Cliente ORDER BY IdCliente", sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable CargarClientes()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
                        Cliente.IdCliente,
                        Cliente.Identificacion,
                      CONCAT(Cliente.Nombre,' ',Cliente.Apellido) as Nombre,
                        Cliente.Telefono,
                        Cliente.Direccion
                    FROM Cliente ORDER BY Cliente.IdCliente;";
                using (SqlCommand cmd = new SqlCommand(query, conexion.Open()))
                {


                    // Configurar para mejor rendimiento
                    cmd.CommandTimeout = 300;

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        data.Load(reader);
                    }
                }
                return data;
            }
        }
        public bool GuardarCliente(ClienteModel clienteM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {

                using (SqlCommand sqlCommand = new SqlCommand("sp_Cliente_insert", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Identificacion", clienteM.Identificacion);
                    sqlCommand.Parameters.AddWithValue("@Nombre", clienteM.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Apellido", clienteM.Apellido);
                    sqlCommand.Parameters.AddWithValue("@Telefono", clienteM.Telefono);
                    sqlCommand.Parameters.AddWithValue("@Direccion", clienteM.Direccion);
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
        public List<string> CargarCliente(string buscar)
        {
            List<string> cliente = new List<string>();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
                Cliente.IdCliente,
                Cliente.Identificacion,
                Cliente.Nombre,
                Cliente.Apellido,
                Cliente.Telefono,
                Cliente.Direccion
            FROM Cliente WHERE IdCliente = @IdCliente;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdCliente", buscar);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Solo si hay resultados
                        {
                            cliente.Add(sqlDataReader["IdCliente"].ToString());
                            cliente.Add(sqlDataReader["Identificacion"].ToString());
                            cliente.Add(sqlDataReader["Nombre"].ToString());
                            cliente.Add(sqlDataReader["Apellido"].ToString());
                            cliente.Add(sqlDataReader["Telefono"].ToString());
                            cliente.Add(sqlDataReader["Direccion"].ToString());
                        }
                        return cliente;
                    }
                }
            }
        }
        public bool ActualizarCliente(ClienteModel clienteM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_Cliente_update", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IdCliente", clienteM.IdCliente);
                    sqlCommand.Parameters.AddWithValue("@Identificacion", clienteM.Identificacion);
                    sqlCommand.Parameters.AddWithValue("@Nombre", clienteM.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Apellido", clienteM.Apellido);
                    sqlCommand.Parameters.AddWithValue("@Telefono", clienteM.Telefono);
                    sqlCommand.Parameters.AddWithValue("@Direccion", clienteM.Direccion);
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
        public bool EliminarCliente(int IdCliente)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Cliente WHERE IdCliente = @IdCliente", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdCliente", IdCliente);
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
