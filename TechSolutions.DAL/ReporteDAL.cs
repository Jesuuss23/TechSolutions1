

using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; 
using System;
using System.Collections.Generic; 

namespace TechSolutions.DAL
{
    public class ReporteDAL
    {
        public List<ReporteVenta> ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<ReporteVenta> listaReporte = new List<ReporteVenta>();

            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ReporteVentasPorFecha", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // 2. Añadir los parámetros que espera el SP
                    comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    comando.Parameters.AddWithValue("@FechaFin", fechaFin);

                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ReporteVenta fila = new ReporteVenta
                                {
                                    IdVenta = reader.GetInt32("IdVenta"),
                                    Cliente = reader.GetString("Cliente"),
                                    Vendedor = reader.GetString("Vendedor"),
                                    FechaVenta = reader.GetDateTime("FechaVenta"),
                                    Total = reader.GetDecimal("Total"),
                                    Estado = reader.GetString("Estado")
                                };
                                listaReporte.Add(fila);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al generar el reporte: " + ex.Message);
                    }
                }
            } 

            return listaReporte;
        }

        public List<ReporteHistorialCliente> ObtenerHistorialCliente(int idCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            List<ReporteHistorialCliente> listaHistorial = new List<ReporteHistorialCliente>();

            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ReporteHistorialCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Añadir los parámetros
                    comando.Parameters.AddWithValue("@IdCliente", idCliente);
                    comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    comando.Parameters.AddWithValue("@FechaFin", fechaFin);

                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Mapeamos los datos al nuevo objeto
                                listaHistorial.Add(new ReporteHistorialCliente
                                {
                                    FechaVenta = reader.GetDateTime("FechaVenta"),
                                    Producto = reader.GetString("Producto"),
                                    Cantidad = reader.GetInt32("Cantidad"),
                                    PrecioUnitario = reader.GetDecimal("PrecioUnitario"),
                                    Subtotal = reader.GetDecimal("Subtotal")
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al obtener historial de cliente: " + ex.Message);
                    }
                }
            }
            return listaHistorial;
        }
    }
}