// --- Archivo: ReporteDAL.cs ---
// --- Proyecto: TechSolutions.DAL ---

using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; // Para 'ReporteVenta'
using System;
using System.Collections.Generic; // Para 'List<>'

namespace TechSolutions.DAL
{
    public class ReporteDAL
    {
        /// <summary>
        /// Obtiene el reporte de ventas entre dos fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del reporte.</param>
        /// <param name="fechaFin">Fecha de fin del reporte.</param>
        /// <returns>Una lista de objetos ReporteVenta.</returns>
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
                                // 3. Mapeamos los datos del reader al objeto ReporteVenta
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
            } // La conexión se cierra aquí

            return listaReporte;
        }

        /// <summary>
        /// Obtiene el historial detallado de compras para un cliente.
        /// </summary>
        /// <param name="idCliente">El ID del cliente.</param>
        /// <param name="fechaInicio">Fecha de inicio del reporte.</param>
        /// <param name="fechaFin">Fecha de fin del reporte.</param>
        /// <returns>Una lista de objetos ReporteHistorialCliente.</returns>
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