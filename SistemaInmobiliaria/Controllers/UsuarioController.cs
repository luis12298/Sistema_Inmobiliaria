using SistemaInmobiliaria.Connection;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Controllers
{

    internal class UsuarioController
    {
        Conexion conexion = new Conexion();
        public static int intentos = 0;
        public static int maxIntentos = 3;
        public List<string> Login(string usuario, string contrasena)
        {
            List<string> user = new List<string>();
            using (SqlConnection con = conexion.Open())
            {
                string query = "SELECT IdUsuario, Usuario, Contrasena FROM Usuario WHERE Usuario = @usuario AND Contrasena = @contrasena;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
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
        public static void Intentos()
        {
            intentos++;
            if (intentos < maxIntentos)
            {
                MessageBox.Show("Contraseña incorrecta. Intentos restantes: " + (maxIntentos - intentos));
            }
            else
            {
                MessageBox.Show("Acceso denegado. Se han agotado los intentos. Espera 1 minuto");
                Task.Run(() =>
                {
                    Task.Delay(10000).Wait();
                    intentos = 0;
                    maxIntentos = 5;
                });
            }
        }
        public DataTable CargarUsuarios()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT IdUsuario,Usuario,Contrasena,UsuarioCreo,FechaCreo FROM Usuario
ORDER BY IdUsuario;";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
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
        public bool GuardarUsuario(UsuarioModel usuarioM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"INSERT INTO Usuario(Usuario,Contrasena,UsuarioCreo,FechaCreo)
                VALUES(
                 @Usuario,
                 @Contrasena,
                 @UsuarioCreo,
                 @FechaCreo
)
                ";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@Usuario", usuarioM._Usuario);
                    sqlCommand.Parameters.AddWithValue("@Contrasena", usuarioM.Contrasena);
                    sqlCommand.Parameters.AddWithValue("@UsuarioCreo", UsuarioModel.Usuario);
                    sqlCommand.Parameters.AddWithValue("@FechaCreo", usuarioM.FechaCreo);

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
        public bool ActualizarUsuario(UsuarioModel usuarioM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"UPDATE Usuario SET 
                Usuario = @Usuario,
                Contrasena = @Contrasena,
                UsuarioCreo = @UsuarioCreo,
                FechaCreo = @FechaCreo 
                WHERE IdUsuario = @IdUsuario;";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdUsuario", usuarioM.IdUsuario);
                    sqlCommand.Parameters.AddWithValue("@Usuario", usuarioM._Usuario);
                    sqlCommand.Parameters.AddWithValue("@Contrasena", usuarioM.Contrasena);
                    sqlCommand.Parameters.AddWithValue("@UsuarioCreo", UsuarioModel.Usuario);
                    sqlCommand.Parameters.AddWithValue("@FechaCreo", usuarioM.FechaCreo);

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

        public bool EliminarUsuario(int IdUsuario)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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
    }
}
