using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace SistemaInmobiliaria.Connection
{
    internal class Conexion
    {
        public static string conexion;
        public Conexion()
        {
            conexion = ConfigurationManager.ConnectionStrings["Prod"].ConnectionString;

        }
        public SqlConnection Open()
        {
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                return con;
            }
            catch
            {
                return null;
            }
        }
        public static void Close()
        {
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Close();
            }
            catch
            {
                return;
            }
        }
    }
}
