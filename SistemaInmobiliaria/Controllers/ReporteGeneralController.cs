using SistemaInmobiliaria.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Controllers
{
    internal class ReporteGeneralController
    {
        Conexion conexion = new Conexion();
        public List<string> ReporteMes()
        {
            List<string> data = new List<string>();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    'Mes' AS Tipo,
    COUNT(*) AS TotalPagos,
    SUM(MontoPagado) AS TotalMontoPagado
FROM Pago
GROUP BY FORMAT(FechaPago, 'yyyy-MM')
ORDER BY Tipo DESC;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Solo si hay resultados
                        {
                            data.Add(sqlDataReader["TotalPagos"].ToString());
                            data.Add(sqlDataReader["TotalMontoPagado"].ToString());
                            ;
                        }
                        return data;
                    }
                }
            }
        }

        public List<string> ReporteSemanal()
        {
            List<string> data = new List<string>();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    CONCAT('Semana ', DATEPART(WEEK, FechaPago), ' - ', DATEPART(YEAR, FechaPago)) AS Tipo,
    COUNT(*) AS TotalPagos,
    SUM(MontoPagado) AS TotalMontoPagado
FROM Pago
GROUP BY DATEPART(YEAR, FechaPago), DATEPART(WEEK, FechaPago)
ORDER BY MIN(FechaPago) DESC;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Solo si hay resultados
                        {
                            data.Add(sqlDataReader["TotalPagos"].ToString());
                            data.Add(sqlDataReader["TotalMontoPagado"].ToString());
                            ;
                        }
                        return data;
                    }
                }
            }
        }
        public List<string> ReporteHoy()
        {
            List<string> data = new List<string>();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    'Hoy' AS Tipo,
    ISNULL(COUNT(*), 0) AS TotalPagos,
    ISNULL(SUM(MontoPagado), 0) AS TotalMontoPagado
FROM Pago
WHERE CAST(FechaPago AS DATE) = CAST(GETDATE() AS DATE);";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Solo si hay resultados
                        {
                            data.Add(sqlDataReader["TotalPagos"].ToString());
                            data.Add(sqlDataReader["TotalMontoPagado"].ToString());
                            ;
                        }
                        return data;
                    }
                }
            }
        }
        public DataTable CargarPagos()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    FORMAT(FechaPago, 'yyyy-MM-dd') AS Tipo,
    COUNT(*) AS TotalPagos,
    SUM(MontoPagado) AS TotalMontoPagado
FROM Pago
GROUP BY CAST(FechaPago AS DATE)
ORDER BY Tipo DESC;";
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
    }
}
