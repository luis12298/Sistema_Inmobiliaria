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
    internal class PagoController
    {
        Conexion conexion = new Conexion();

        public DataTable CargarPagos(int IdCliente)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"WITH Numeros AS (
    SELECT 0 AS Numero UNION ALL SELECT Numero + 1 FROM Numeros WHERE Numero < 150
),
CuotasBase AS (
    SELECT 
        co.IdContrato, co.IdCliente,
        CHOOSE(MONTH(DATEADD(MONTH, n.Numero, co.FechaInicio)), 
               'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
               'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre') AS Mes,
        n.Numero + 1 AS NoCuota,
        DATEADD(MONTH, n.Numero, co.FechaInicio) AS FechaPago,
        CAST(co.MontoTotal / co.CantidadCuota AS DECIMAL(18,2)) AS MontoCuota,
        co.CantidadCuota AS TotalCuotas,
        ISNULL((SELECT SUM(MontoPagado) FROM Pago WHERE IdContrato = co.IdContrato AND NoCuota = n.Numero + 1), 0) AS PagoDirecto,
        co.MontoTotal AS MontoTotal
    FROM Contrato co
    JOIN Numeros n ON n.Numero < co.CantidadCuota
    WHERE co.IdContrato = @IdContrato
),
Excedentes AS (
    SELECT 
        cb.*,
        CASE WHEN PagoDirecto > MontoCuota THEN PagoDirecto - MontoCuota ELSE 0 END AS ExcedenteCuota,
        (SELECT SUM(CASE WHEN p.MontoPagado > cb2.MontoCuota 
                         THEN p.MontoPagado - cb2.MontoCuota ELSE 0 END)
         FROM Pago p JOIN CuotasBase cb2 
         ON p.IdContrato = cb2.IdContrato AND p.NoCuota = cb2.NoCuota) AS ExcedenteTotal
    FROM CuotasBase cb
)
SELECT 
    e.IdContrato,
    e.IdCliente,
    e.NoCuota,
    e.Mes AS Frecuencia,
    e.FechaPago,
    CASE 
        WHEN e.PagoDirecto > 0 OR (TotalCuotas - NoCuota) < FLOOR(ExcedenteTotal / MontoCuota) THEN e.MontoCuota
        WHEN (TotalCuotas - NoCuota) = FLOOR(ExcedenteTotal / MontoCuota) AND 
             (ExcedenteTotal - FLOOR(ExcedenteTotal / MontoCuota) * MontoCuota) > 0 
             THEN e.MontoCuota - (ExcedenteTotal - FLOOR(ExcedenteTotal / MontoCuota) * MontoCuota)
        ELSE e.MontoCuota
    END AS MontoCuota,
    CASE 
        WHEN e.PagoDirecto > 0 THEN e.PagoDirecto
        WHEN (TotalCuotas - NoCuota) < FLOOR(ExcedenteTotal / MontoCuota) THEN e.MontoCuota
        WHEN (TotalCuotas - NoCuota) = FLOOR(ExcedenteTotal / MontoCuota) 
             THEN ExcedenteTotal - FLOOR(ExcedenteTotal / MontoCuota) * MontoCuota
        ELSE 0
    END AS MontoPagado,
    CASE 
        WHEN e.PagoDirecto > 0 OR (TotalCuotas - NoCuota) < FLOOR(ExcedenteTotal / MontoCuota) THEN 'Pagada'
        ELSE 'Pendiente'
    END AS Estado
FROM Excedentes e
ORDER BY e.IdContrato, e.NoCuota
OPTION (MAXRECURSION 150);";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdContrato", IdCliente); // Parametrizar

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

        public List<string> Encabezado(int IdCliente)
        {
            string query = "SELECT Contrato.IdContrato, Cliente.IdCliente, Cliente.Nombre, Cliente.Apellido\r\nFROM Contrato\r\nINNER JOIN Cliente ON Contrato.IdCliente = Cliente.IdCliente" +
                " WHERE Contrato.IdContrato = @IdContrato;";
            List<string> encabezado = new List<string>();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdContrato", IdCliente); // Parametrizar
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        while (reader.Read())
                        {
                            encabezado.Add(reader["Nombre"].ToString());
                            encabezado.Add(reader["Apellido"].ToString());
                        }
                    }
                }
            }
            return encabezado;
        }
        public bool GuardarPago(PagoModel pago)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {

                using (SqlCommand sqlCommand = new SqlCommand("sp_Pago_insert", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IdContrato", pago.IdContrato);
                    sqlCommand.Parameters.AddWithValue("@NoCuota", pago.NoCuota);
                    sqlCommand.Parameters.AddWithValue("@FechaCuota", pago.FechaCuota);
                    sqlCommand.Parameters.AddWithValue("@MontoPagado", pago.MontoPagado);
                    sqlCommand.Parameters.AddWithValue("@Estado", pago.Estado);
                    sqlCommand.Parameters.AddWithValue("@FechaPago", pago.FechaPago);
                    sqlCommand.Parameters.AddWithValue("@UsuarioCreo", pago.UsuarioCreo);
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
        public bool EliminarPago(int IdPago)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM Pago WHERE IdPago = @IdPago", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdPago", IdPago);
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
    }
}
