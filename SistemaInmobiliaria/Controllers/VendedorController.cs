using Microsoft.ReportingServices.Diagnostics.Internal;
using SistemaInmobiliaria.Connection;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Controllers
{
    internal class VendedorController
    {
        Conexion conexion = new Conexion();
        public DataTable CargarVendedores()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
                    Vendedor.IdVendedor,Nombre,telefono
                  
                FROM Vendedor ORDER BY Vendedor.IdVendedor;";
                using (SqlCommand cmd = new SqlCommand(query, conexion.Open()))
                {
                    cmd.CommandTimeout = 300;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        data.Load(reader);
                    }
                }
                return data;
            }


        }
        public DataTable Reporte1()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    v.NoLote AS 'Lote',
    vend.nombre AS 'Vendedor',
    v.FechaVenta AS 'Fecha Venta',
    v.MontoComision AS 'Comisión'

FROM Venta v
INNER JOIN Vendedor vend ON v.IdVendedor = vend.IdVendedor
ORDER BY v.FechaVenta DESC;";
                using (SqlCommand cmd = new SqlCommand(query, conexion.Open()))
                {
                    cmd.CommandTimeout = 300;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        data.Load(reader);
                    }
                }
                return data;
            }


        }
        public DataTable Reporte2()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    vend.nombre AS 'Vendedor',
    COUNT(v.IdVenta) AS 'Total Lotes Vendidos',
    SUM(v.MontoComision) AS 'Comisión Total Generada',
    MIN(v.FechaVenta) AS 'Primera Venta',
    MAX(v.FechaVenta) AS 'Última Venta'
FROM Vendedor vend
LEFT JOIN Venta v ON vend.IdVendedor = v.IdVendedor

GROUP BY vend.IdVendedor, vend.nombre
ORDER BY SUM(v.MontoComision) DESC;";
                using (SqlCommand cmd = new SqlCommand(query, conexion.Open()))
                {
                    cmd.CommandTimeout = 300;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        data.Load(reader);
                    }
                }
                return data;
            }


        }

        public DataTable Reporte3()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    vend.nombre AS 'Vendedor',
    COUNT(v.IdVenta) AS 'Total Lotes Vendidos',
    COALESCE(SUM(p.MontoPagado), 0) AS 'Monto Pagado',
    COALESCE(SUM(v.MontoComision), 0) - COALESCE(SUM(p.MontoPagado), 0) AS 'Total Pendiente'
FROM Vendedor vend
LEFT JOIN Venta v ON vend.IdVendedor = v.IdVendedor
LEFT JOIN PagoComision p ON vend.IdVendedor = p.IdVendedor

GROUP BY vend.IdVendedor, vend.nombre
ORDER BY (COALESCE(SUM(v.MontoComision), 0) - COALESCE(SUM(p.MontoPagado), 0)) DESC;";
                using (SqlCommand cmd = new SqlCommand(query, conexion.Open()))
                {
                    cmd.CommandTimeout = 300;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        data.Load(reader);
                    }
                }
                return data;
            }


        }

        public List<string> CargarPago(string buscar)
        {
            List<string> dato = new List<string>();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    vend.nombre AS 'Vendedor',
    COUNT(v.IdVenta) AS 'Total Lotes Vendidos',
    COALESCE(SUM(p.MontoPagado), 0) AS 'Monto Pagado',
    COALESCE(SUM(v.MontoComision), 0) - COALESCE(SUM(p.MontoPagado), 0) AS 'Total Pendiente'
FROM Vendedor vend
LEFT JOIN Venta v ON vend.IdVendedor = v.IdVendedor
LEFT JOIN PagoComision p ON vend.IdVendedor = p.IdVendedor
WHERE vend.IdVendedor = @IdVendedor
GROUP BY vend.IdVendedor, vend.nombre
ORDER BY (COALESCE(SUM(v.MontoComision), 0) - COALESCE(SUM(p.MontoPagado), 0)) DESC;";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdVendedor", buscar);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read()) // Solo si hay resultados
                        {
                            dato.Add(sqlDataReader["Vendedor"].ToString());
                            dato.Add(sqlDataReader["Total Pendiente"].ToString());
                        }
                        return dato;
                    }
                }
            }
        }
        //guardar
        public bool GuardarVendedor(string Nombre, string Telefono)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"INSERT INTO Vendedor VALUES(@Nombre,@Telefono);";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //actualizar
        public bool ActualizarVendedor(int IdVendedor, string Nombre, string Telefono)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"UPDATE Vendedor SET Nombre=@Nombre,Telefono=@Telefono WHERE IdVendedor=@IdVendedor;";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", IdVendedor);
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@Telefono", Telefono);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        //eliminar
        public bool EliminarVendedor(int IdVendedor)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"DELETE FROM Vendedor WHERE IdVendedor=@IdVendedor;";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", IdVendedor);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable CargaVentas()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT        dbo.Venta.IdVenta,Vendedor.IdVendedor ,dbo.Vendedor.Nombre, dbo.Vendedor.Telefono, dbo.Venta.NoLote, dbo.Venta.FechaVenta, Venta.MontoComision
FROM            dbo.Venta INNER JOIN
                         dbo.Vendedor ON dbo.Venta.IdVendedor = dbo.Vendedor.IdVendedor";
                using (SqlCommand cmd = new SqlCommand(query, conexion.Open()))
                {
                    cmd.CommandTimeout = 300;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        data.Load(reader);
                    }
                }
                return data;
            }

            //guardar

        }
        public bool GuardarVenta(VentaModel venta)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"INSERT INTO Venta VALUES(@IdVendedor,@NoLote,@FechaVenta,@MontoComision);";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", venta.IdVendedor);
                    cmd.Parameters.AddWithValue("@NoLote", venta.NoLote);
                    cmd.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    cmd.Parameters.AddWithValue("@MontoComision", venta.Comision);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool ActualizarVenta(VentaModel venta)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"UPDATE Venta SET IdVendedor=@IdVendedor,NoLote=@NoLote,FechaVenta=@FechaVenta,MontoComision=@MontoComision WHERE IdVenta=@IdVenta;";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", venta.IdVenta);
                    cmd.Parameters.AddWithValue("@IdVendedor", venta.IdVendedor);
                    cmd.Parameters.AddWithValue("@NoLote", venta.NoLote);
                    cmd.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    cmd.Parameters.AddWithValue("@MontoComision", venta.Comision);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool EliminarVenta(int IdVenta)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"DELETE FROM Venta WHERE IdVenta=@IdVenta;";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdVenta", IdVenta);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        //comisiones
        public DataTable CargarComisiones()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    PagoComision.IdPagoC,
    Vendedor.IdVendedor,
    Vendedor.Nombre,
    Vendedor.Telefono,
    PagoComision.MontoPagado,
    PagoComision.SaldoAnterior,
    PagoComision.SaldoNuevo,
    PagoComision.FechaPago
FROM PagoComision
INNER JOIN Vendedor ON PagoComision.IdVendedor = Vendedor.IdVendedor;;";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.CommandTimeout = 300;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        data.Load(reader);
                    }
                }
                return data;
            }
        }
        public bool GuardarPago(PagoComision pagoM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"INSERT INTO PagoComision VALUES(@IdVendedor,@FechaPago,@MontoPagado,@SaldoAnterior,@SaldoNuevo);";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", pagoM.IdVendedor);
                    cmd.Parameters.AddWithValue("@FechaPago", pagoM.FechaPago);
                    cmd.Parameters.AddWithValue("@MontoPagado", pagoM.MontoPagado);
                    cmd.Parameters.AddWithValue("@SaldoAnterior", pagoM.SaldoAnterior);
                    cmd.Parameters.AddWithValue("@SaldoNuevo", pagoM.SaldoNuevo);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool ActualizarPago(PagoComision pagoM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"UPDATE PagoComision SET IdPagoC=@IdPagoC,IdVendedor=@IdVendedor,FechaPago=@FechaPago,MontoPagado=@MontoPagado,SaldoAnterior=@SaldoAnterior,SaldoNuevo=@SaldoNuevo WHERE IdPagoC=@IdPagoC;";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdPagoC", pagoM.IdPagoC);
                    cmd.Parameters.AddWithValue("@IdVendedor", pagoM.IdVendedor);
                    cmd.Parameters.AddWithValue("@FechaPago", pagoM.FechaPago);
                    cmd.Parameters.AddWithValue("@MontoPagado", pagoM.MontoPagado);
                    cmd.Parameters.AddWithValue("@SaldoAnterior", pagoM.SaldoAnterior);
                    cmd.Parameters.AddWithValue("@SaldoNuevo", pagoM.SaldoNuevo);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarPago(int IdPagoC)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"DELETE FROM PagoComision WHERE IdPagoC=@IdPagoC;";
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@IdPagoC", IdPagoC);
                    cmd.CommandTimeout = 300;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
