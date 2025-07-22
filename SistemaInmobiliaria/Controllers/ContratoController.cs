using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaInmobiliaria.Connection;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Markup;
using SistemaInmobiliaria.Models;

namespace SistemaInmobiliaria.Controllers
{
    internal class ContratoController
    {
        Conexion conexion = new Conexion();
        public DataTable ListaContratos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = conexion.Open())
            {
                string query = @"SELECT 
    Contrato.IdContrato,
    Cliente.Identificacion,
    Cliente.Nombre,
    Cliente.Apellido,
    Contrato.FechaInicio,
    Contrato.FechaFin,
    Contrato.CantidadCuota,
    Contrato.CuotaFinal,
    Contrato.MontoTotal,
    Contrato.Estado,
    Contrato.IdLote,              -- Id del lote (relacionado)
    Lote.LoteNo AS LoteNo    -- Nombre del lote (o cualquier otro dato relevante)
FROM Cliente
INNER JOIN Contrato ON Cliente.IdCliente = Contrato.IdCliente
INNER JOIN Lote ON Contrato.IdLote = Lote.IdLote ORDER BY Contrato.IdContrato;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {


                    // Configurar para mejor rendimiento
                    cmd.CommandTimeout = 300;

                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        dt.Load(reader);
                    }
                }
                return dt;
            }
        }
        public DataTable CargarContratos()
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
    Contrato.IdContrato,
    Contrato.IdLote,
    Lote.LoteNo AS LoteNo,
    Cliente.Identificacion,
    CONCAT(Cliente.Nombre,' ',Cliente.Apellido) as Nombre,
    Contrato.FechaInicio,
    Contrato.FechaFin,
    Contrato.CantidadCuota,
    Contrato.CuotaFinal,
    Contrato.MontoTotal,
    Contrato.Prima,
    Contrato.Estado
    FROM Cliente
    INNER JOIN Contrato ON Cliente.IdCliente = Contrato.IdCliente
    INNER JOIN Lote ON Contrato.IdLote = Lote.IdLote
    ORDER BY Cliente.Nombre;";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.SelectCommand.CommandType = CommandType.Text;

                sqlDataAdapter.Fill(data);
                return data;
            }
        }


        public bool GuardarContrato(ContratoModel contratoM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {

                using (SqlCommand sqlCommand = new SqlCommand("sp_Contrato_insert", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IdCliente", contratoM.IdCliente);
                    sqlCommand.Parameters.AddWithValue("@IdLote", contratoM.IdLote);
                    sqlCommand.Parameters.AddWithValue("@FechaInicio", contratoM.FechaInicio);
                    sqlCommand.Parameters.AddWithValue("@FechaFin", contratoM.FechaFin);
                    sqlCommand.Parameters.AddWithValue("@MontoTotal", contratoM.MontoTotal);
                    sqlCommand.Parameters.AddWithValue("@CantidadCuota", contratoM.CantidadCuota);
                    sqlCommand.Parameters.AddWithValue("@CuotaFinal", contratoM.CuotaFinal);
                    sqlCommand.Parameters.AddWithValue("@InteresRetraso", contratoM.InteresRetraso);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", contratoM.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Prima", contratoM.Prima);
                    sqlCommand.Parameters.AddWithValue("@Estado", contratoM.Estado);
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
        public List<string> CargarContrato(int IdContrato)
        {
            List<string> list = new List<string>();
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"SELECT 
                    Contrato.IdContrato,
                    Contrato.IdCliente,
                    Concat(Cliente.Nombre,' ',Cliente.Apellido) as Nombre,
                    Contrato.FechaInicio,
                    Contrato.FechaFin,
                    Contrato.MontoTotal,
                    Contrato.CantidadCuota,
                    Contrato.CuotaFinal,
                    Contrato.InteresRetraso,
                    Contrato.Estado,
                    Contrato.Descripcion,
                    Lote.IdLote,
                    Lote.LoteNo,
                    Lote.Precio,
                    Contrato.Prima
                FROM Contrato
                INNER JOIN Cliente ON Contrato.IdCliente = Cliente.IdCliente
                INNER JOIN Lote ON Contrato.IdLote = Lote.IdLote
                 WHERE IdContrato = @IdContrato";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IdContrato", IdContrato);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            list.Add(sqlDataReader["IdContrato"].ToString());
                            list.Add(sqlDataReader["FechaInicio"].ToString());
                            list.Add(sqlDataReader["FechaFin"].ToString());
                            list.Add(sqlDataReader["MontoTotal"].ToString());
                            list.Add(sqlDataReader["CantidadCuota"].ToString());
                            list.Add(sqlDataReader["CuotaFinal"].ToString());
                            list.Add(sqlDataReader["InteresRetraso"].ToString());
                            list.Add(sqlDataReader["Estado"].ToString());
                            list.Add(sqlDataReader["Descripcion"].ToString());
                            list.Add(sqlDataReader["IdCliente"].ToString());
                            list.Add(sqlDataReader["Nombre"].ToString());
                            list.Add(sqlDataReader["IdLote"].ToString());
                            list.Add(sqlDataReader["LoteNo"].ToString());
                            list.Add(sqlDataReader["Precio"].ToString());
                            list.Add(sqlDataReader["Prima"].ToString());
                        }
                        return list;
                    }
                }


            }
        }
        public bool ActualizarContrato(ContratoModel contratoM)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_Contrato_update", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@IdContrato", contratoM.IdContrato);
                    sqlCommand.Parameters.AddWithValue("@IdLote", contratoM.IdLote);
                    sqlCommand.Parameters.AddWithValue("@IdCliente", contratoM.IdCliente);
                    sqlCommand.Parameters.AddWithValue("@FechaInicio", contratoM.FechaInicio);
                    sqlCommand.Parameters.AddWithValue("@FechaFin", contratoM.FechaFin);
                    sqlCommand.Parameters.AddWithValue("@MontoTotal", contratoM.MontoTotal);
                    sqlCommand.Parameters.AddWithValue("@CantidadCuota", contratoM.CantidadCuota);
                    sqlCommand.Parameters.AddWithValue("@CuotaFinal", contratoM.CuotaFinal);
                    sqlCommand.Parameters.AddWithValue("@InteresRetraso", contratoM.InteresRetraso);
                    sqlCommand.Parameters.AddWithValue("@Descripcion", contratoM.Descripcion);
                    sqlCommand.Parameters.AddWithValue("@Estado", contratoM.Estado);
                    sqlCommand.Parameters.AddWithValue("@Prima", contratoM.Prima);
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
        public bool EliminarContrato(int IdContrato)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"DELETE FROM Contrato WHERE IdContrato = @IdContrato
                                    DELETE FROM PAGO WHERE IdContrato = @IdContrato";
                ;
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdContrato", IdContrato);
                    sqlCommand.ExecuteNonQuery();
                    try
                    {
                        return true;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return false;
        }
        public bool EliminarContratoPorIdCliente(int IdCliente)
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = @"DELETE FROM Contrato WHERE IdCliente = @IdCliente";
                ;
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@IdCliente", IdCliente);
                    sqlCommand.ExecuteNonQuery();
                    try
                    {
                        return true;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return false;
        }

        public string UltimoContrato()
        {
            using (SqlConnection sqlConnection = conexion.Open())
            {
                string query = "SELECT TOP 1 IdContrato FROM Contrato ORDER BY IdContrato DESC";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.Text;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            return sqlDataReader["IdContrato"].ToString();
                        }
                    }
                }
            }
            return "";
        }
    }
}

