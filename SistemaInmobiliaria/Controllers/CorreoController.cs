using SistemaInmobiliaria.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaInmobiliaria.Models;

namespace SistemaInmobiliaria.Controllers
{
    internal class CorreoController
    {
        Conexion conexion = new Conexion();
        public bool Usuario(string usuario)
        {

            using (SqlConnection con = conexion.Open())
            {
                string query = "SELECT Correo FROM Correo WHERE Correo = @usuario";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteScalar() != null)
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
        public string usuario(string usuario)
        {

            using (SqlConnection con = conexion.Open())
            {
                string query = "SELECT Correo FROM Correo WHERE Correo = @usuario";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteScalar() != null)
                    {
                        return cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        return null;
                    }
                }

            }
        }
        public List<string> Correo(string usuario)
        {
            List<string> user = new List<string>();
            using (SqlConnection con = conexion.Open())
            {
                string query = "SELECT IdUsuario, Usuario, Contrasena FROM Usuario WHERE Usuario = @usuario;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            user.Add(dr["IdUsuario"].ToString());
                            user.Add(dr["Usuario"].ToString());
                            user.Add(dr["Contrasena"].ToString());

                        }
                        return user;
                    }
                }
            }
        }
        public DataTable CargarCorreos()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT IdCorreo,Correo,Descripcion FROM Correo;";
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
        public bool GuardarCorreo(CorreoModel correoM)
        {
            using (SqlConnection con = conexion.Open())
            {
                string query = "INSERT INTO Correo (Correo,Descripcion) VALUES(@Correo,@Descripcion)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Correo", correoM.Correo);
                    cmd.Parameters.AddWithValue("@Descripcion", correoM.Descripcion);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteNonQuery() > 0)
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
        public bool ActualizarCorreo(CorreoModel correoM)
        {
            using (SqlConnection con = conexion.Open())
            {
                string query = "UPDATE Correo SET Correo=@Correo,Descripcion=@Descripcion WHERE IdCorreo=@IdCorreo";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Correo", correoM.Correo);
                    cmd.Parameters.AddWithValue("@Descripcion", correoM.Descripcion);
                    cmd.Parameters.AddWithValue("@IdCorreo", correoM.IdCorreo);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteNonQuery() > 0)
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
        public bool EliminarCorreo(int IdCorreo)
        {
            using (SqlConnection con = conexion.Open())
            {
                string query = "DELETE FROM Correo WHERE IdCorreo=@IdCorreo";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdCorreo", IdCorreo);
                    cmd.CommandType = CommandType.Text;
                    if (cmd.ExecuteNonQuery() > 0)
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
    }
}
