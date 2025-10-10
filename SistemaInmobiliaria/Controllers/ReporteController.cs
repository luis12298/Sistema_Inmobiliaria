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
    internal class ReporteController
    {
        Conexion conexion = new Conexion();

        public DataTable CargarClientesAtrasados()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"WITH Numeros AS (
    SELECT TOP 100 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS Numero
    FROM sys.all_objects
),
Pagos AS (
    SELECT IdContrato, NoCuota, SUM(MontoPagado) AS MontoPagado
    FROM Pago
    GROUP BY IdContrato, NoCuota
),
PlanCuotas AS (
    SELECT 
        co.IdContrato,
        co.IdCliente,
        co.IdLote, -- ✅ Incluimos IdLote
        n.Numero + 1 AS NoCuota,
        DATEADD(MONTH, n.Numero, co.FechaInicio) AS FechaCuota,
        CAST(co.MontoTotal / co.CantidadCuota AS DECIMAL(18,2)) AS MontoCuota
    FROM Contrato co
    JOIN Numeros n ON n.Numero < co.CantidadCuota
),
CuotasConPagos AS (
    SELECT 
        pc.*,
        ISNULL(p.MontoPagado, 0) AS MontoPagado,
        DATEDIFF(DAY, pc.FechaCuota, GETDATE()) AS DiasAtraso
    FROM PlanCuotas pc
    LEFT JOIN Pagos p ON p.IdContrato = pc.IdContrato AND p.NoCuota = pc.NoCuota
),
CuotasAtrasadas AS (
    SELECT 
        c.Identificacion AS Identidad,
        c.Nombre + ' ' + c.Apellido AS Cliente,
        c.Telefono AS Telefono,
        cp.IdContrato,
        cp.IdLote, -- ✅ Propagamos IdLote aquí también
        cp.NoCuota AS NumeroCuota,
        cp.FechaCuota,
        cp.MontoCuota AS Cuota,
        CAST(
            CASE 
                WHEN cp.MontoPagado = 0 AND cp.DiasAtraso >= 90 THEN cp.MontoCuota * 1.05
                ELSE cp.MontoCuota
            END AS DECIMAL(18,2)
        ) AS MontoAtrasado,
        cp.DiasAtraso,
        FORMAT(cp.FechaCuota, 'MMMM', 'es-ES') AS MesAtrasado,
        'Atrasado' AS Estado
    FROM CuotasConPagos cp
    JOIN Cliente c ON c.IdCliente = cp.IdCliente
    WHERE cp.MontoPagado < cp.MontoCuota AND cp.FechaCuota < GETDATE()
)
SELECT 
    ca.IdContrato,
    ca.Identidad,
    ca.Telefono,
    ca.Cliente,
    ca.NumeroCuota AS NoCuota,
    ca.FechaCuota,
    ca.Cuota,
    ca.MontoAtrasado,
    ca.MesAtrasado,
    l.LoteNo,
    ca.Estado
    
FROM CuotasAtrasadas ca
JOIN Lote l ON l.IdLote = ca.IdLote
WHERE ca.DiasAtraso > 0
ORDER BY ca.FechaCuota;";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                sqlDataAdapter.Fill(data);
                return data;
            }
        }
        public DataTable CargarCobrosMes()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"WITH Numeros AS (
    SELECT TOP 100 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) - 1 AS Numero 
    FROM sys.all_objects
),
Pagos AS (
    SELECT IdContrato, NoCuota, SUM(MontoPagado) AS MontoPagado 
    FROM Pago 
    GROUP BY IdContrato, NoCuota
),
PlanCuotas AS (
    SELECT 
        co.IdContrato,
        co.IdCliente,
        co.FechaInicio,
        co.IdLote,
        n.Numero + 1 AS NoCuota,
        DATEADD(MONTH, n.Numero, co.FechaInicio) AS FechaCuota,
        CAST(co.MontoTotal / co.CantidadCuota AS DECIMAL(18,2)) AS MontoCuota
    FROM Contrato co
    JOIN Numeros n ON n.Numero < co.CantidadCuota
),
CuotasConPagos AS (
    SELECT 
        pc.*,
        ISNULL(p.MontoPagado, 0) AS MontoPagado,
        DATEDIFF(DAY, pc.FechaCuota, GETDATE()) AS DiasAtraso
    FROM PlanCuotas pc
    LEFT JOIN Pagos p ON p.IdContrato = pc.IdContrato AND p.NoCuota = pc.NoCuota
),
CuotasDelMes AS (
    SELECT 
        c.Identificacion AS Identidad,
        c.Nombre + ' ' + c.Apellido AS Cliente,
        c.Telefono,
        cp.IdContrato,
        cp.IdLote,
        cp.FechaInicio,
        cp.NoCuota AS NumeroCuota,
        cp.FechaCuota,
        cp.MontoCuota AS Cuota,
        cp.MontoPagado,
        cp.DiasAtraso,
        FORMAT(cp.FechaCuota, 'MMMM', 'es-ES') AS Mes,
        CASE 
            WHEN cp.MontoPagado >= cp.MontoCuota THEN 'Pagado'
            WHEN cp.FechaCuota > GETDATE() THEN 'Pendiente'
            WHEN cp.FechaCuota <= GETDATE() AND cp.MontoPagado < cp.MontoCuota THEN 'Atrasado'
            ELSE 'En Proceso'
        END AS Estado
    FROM CuotasConPagos cp
    JOIN Cliente c ON c.IdCliente = cp.IdCliente
    WHERE YEAR(cp.FechaCuota) = YEAR(GETDATE()) 
      AND MONTH(cp.FechaCuota) = MONTH(GETDATE())
      AND cp.FechaCuota >= cp.FechaInicio
)
SELECT 
    cd.IdContrato,
    cd.Identidad,
    cd.Telefono,
    cd.Cliente,
    cd.FechaInicio,
    cd.NumeroCuota AS NoCuota,
    cd.FechaCuota,
    cd.Cuota,
    cd.MontoPagado,
    cd.Mes,
    l.LoteNo,
    cd.Estado
FROM CuotasDelMes cd
JOIN Lote l ON l.IdLote = cd.IdLote
ORDER BY cd.FechaCuota;";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                sqlDataAdapter.Fill(data);
                return data;
            }
        }
        public DataTable verpagos(int idContrato)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
                    Pago.IdPago, 
                    Pago.NoCuota, 
                    Pago.FechaCuota, 
                    Pago.MontoPagado, 
                    Pago.Estado, 
                    Pago.FechaPago,
                    Pago.UsuarioCreo
                FROM Pago
                INNER JOIN Contrato ON Pago.IdContrato = Contrato.IdContrato
                WHERE Contrato.IdContrato = @IdContrato;
";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@IdContrato", idContrato);
                sqlDataAdapter.SelectCommand.CommandTimeout = 300;
                sqlDataAdapter.Fill(data);
                return data;
            }
        }

        public List<PlanAmortizacionModel> PlanAmortizacion(int Id)
        {
            List<PlanAmortizacionModel> fact = new List<PlanAmortizacionModel>();

            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"DECLARE @MaxCuotas INT;

-- Obtener el máximo número de cuotas para limitar el CTE recursivo
SELECT @MaxCuotas = MAX(CantidadCuota) FROM Contrato;

WITH Base AS (
    SELECT 
        co.IdContrato,
		c.Identificacion,
        co.IdCliente, 
        c.Nombre, 
        c.Apellido,
		c.Telefono,
        co.FechaInicio, 
        co.FechaFin, 
        co.MontoTotal, 
        co.CantidadCuota,
        co.CuotaFinal,
        co.InteresRetraso,
        co.Estado,
        CAST(ROUND(co.MontoTotal / co.CantidadCuota, 2) AS DECIMAL(18,2)) AS MontoCuota
    FROM Contrato co
    JOIN Cliente c ON co.IdCliente = c.IdCliente
),
Numeros AS (
    SELECT 1 AS Numero
    UNION ALL
    SELECT Numero + 1 FROM Numeros WHERE Numero + 1 <= @MaxCuotas
),
Amortizacion AS (
    SELECT 
        b.IdContrato,
        b.IdCliente,
		b.Identificacion,
        b.Nombre,
        b.Apellido,
		b.Telefono,
        n.Numero AS NumeroCuota,
        CASE 
            WHEN n.Numero = b.CantidadCuota THEN b.FechaFin
            ELSE DATEADD(MONTH, n.Numero - 1, b.FechaInicio)
        END AS FechaPagoProgramada,
    FORMAT(
    CASE 
        WHEN n.Numero = b.CantidadCuota THEN b.FechaFin
        ELSE DATEADD(MONTH, n.Numero - 1, b.FechaInicio)
    END, 
'MMMM yyyy', 'es-ES') AS NombreMes,

        b.CantidadCuota,
        CASE 
            WHEN n.Numero = b.CantidadCuota THEN b.CuotaFinal
            ELSE b.MontoCuota
        END AS MontoCuota,
        CASE 
            WHEN n.Numero = b.CantidadCuota THEN 
                CAST(ROUND(b.MontoTotal - b.MontoCuota * (b.CantidadCuota - 1), 2) AS DECIMAL(18,2))
            ELSE b.MontoCuota
        END AS MontoCapital,
        CAST(ROUND(b.MontoTotal - b.MontoCuota * (n.Numero - 1), 2) AS DECIMAL(18,2)) AS SaldoInicial,
        b.CuotaFinal,
        b.InteresRetraso,
        b.Estado,
        CAST(
            CASE 
                WHEN n.Numero = b.CantidadCuota THEN 0.00
                ELSE ROUND(b.MontoTotal - b.MontoCuota * n.Numero, 2)
            END AS DECIMAL(18,2)
        ) AS SaldoRestante
    FROM Base b
    JOIN Numeros n ON n.Numero <= b.CantidadCuota
)

SELECT 
    IdContrato, 
    IdCliente,
    Identificacion,
    CONCAT(Nombre,' ',Apellido) as Nombre,
	Telefono,
    NumeroCuota,
    FechaPagoProgramada,
    SaldoInicial,   
    NombreMes,
    CantidadCuota, 
    CuotaFinal,
    InteresRetraso,
    SaldoRestante
FROM Amortizacion
WHERE IdContrato = @IdContrato
ORDER BY IdContrato, NumeroCuota
OPTION (MAXRECURSION 0);";

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdContrato", Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fact.Add(new PlanAmortizacionModel
                            {
                                IdContrato = reader["IdContrato"].ToString(),
                                IdCliente = reader["IdCliente"].ToString(),
                                Identifacion = reader["Identificacion"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                NumeroCuota = reader["NumeroCuota"].ToString(),
                                FechaCuota = reader["FechaPagoProgramada"].ToString(),
                                SaldoInicial = reader["SaldoInicial"].ToString(),
                                NombreMes = reader["NombreMes"].ToString(),
                                CantidadCuota = reader["CantidadCuota"].ToString(),
                                CuotaFinal = reader["CuotaFinal"].ToString(),
                                InteresRetraso = reader["InteresRetraso"].ToString(),
                                SaldoRestante = reader["SaldoRestante"].ToString(),
                            });
                        }
                    }
                }
            }

            return fact;
        }

        public List<PagoContratoModel> ReportePagoContrato(int Id, string Nombre, string MontoP, string MontoR, string CuotaPg, string Cuotar)
        {
            List<PagoContratoModel> fact = new List<PagoContratoModel>();

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

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdContrato", Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            fact.Add(new PagoContratoModel
                            {
                                IdContrato = reader["IdContrato"].ToString(),
                                IdCliente = reader["IdCliente"].ToString(),
                                NoCuota = reader["NoCuota"].ToString(),
                                Frecuencia = reader["Frecuencia"].ToString(),
                                FechaPago = reader["FechaPago"].ToString(),
                                MontoCuota = reader["MontoCuota"].ToString(),
                                MontoPagado = reader["MontoPagado"].ToString(),
                                Estado = reader["Estado"].ToString(),
                                Nombre = Nombre,
                                MontoP = MontoP,
                                MontoR = MontoR,
                                CuotaPg = CuotaPg,
                                Cuotar = Cuotar

                            });
                        }
                    }
                }
            }

            return fact;
        }

    }
}