using Polly.Caching;
using SistemaInmobiliaria.Connection;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SistemaInmobiliaria.Controllers
{
    internal class FactPrimaController
    {
        Conexion conexion = new Conexion();
        public List<FactPrimaModel> GenerarFactura(string nofactura, string identidad, string nombre, string direccion, string nolote, string total, string numtexto)
        {
            List<FactPrimaModel> factura = new List<FactPrimaModel>();


            factura.Add(new FactPrimaModel
            {
                NoLote = nolote,
                Identidad = identidad,
                Nombre = nombre,
                Direccion = direccion,
                NoFactura = nofactura,
                Total = total,
                NumTexto = numtexto
            });
            if (factura.Count > 0)
            {
                return factura;

            }
            else
            {
                return null;
            }


        }
        public List<FactCuotaModel> FacturaPago(int IdPago)
        {
            List<FactCuotaModel> fact = new List<FactCuotaModel>();
            using (SqlConnection con = conexion.Open())
            {
                string query = @"SELECT IdPago, CONCAT(CAST(CRYPT_GEN_RANDOM(3) AS bigint),IdPago) AS Referencia, 
                                Identificacion, CONCAT(Nombre,' ',Apellido) AS Nombre, 
                                NoCuota, FechaCuota, LoteNo, CuotaFinal, MontoPagado
                         FROM Pago
                         INNER JOIN Contrato ON Pago.IdContrato = Contrato.IdContrato
                         INNER JOIN Cliente ON Contrato.IdCliente = Cliente.IdCliente
                         INNER JOIN Lote ON Contrato.IdLote = Lote.IdLote
                         WHERE IdPago = @IdPago;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdPago", IdPago);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fact.Add(new FactCuotaModel
                            {
                                Referencia = reader["Referencia"].ToString(),
                                Identificacion = reader["Identificacion"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                NoCuota = reader["NoCuota"].ToString(),
                                Fecha = reader["FechaCuota"].ToString(),
                                Mes = DateTime.Parse(reader["FechaCuota"].ToString()).ToString("MMMM"),
                                LoteNo = reader["LoteNo"].ToString(),
                                CuotaFinal = reader["CuotaFinal"].ToString(),
                                Total = reader["MontoPagado"].ToString()
                            });
                            return fact;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

    }
}
