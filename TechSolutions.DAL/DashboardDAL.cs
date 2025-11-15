using TechSolutions.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace TechSolutions.DAL
{
    public class DashboardDAL
    {
        public decimal ObtenerVentasHoy()
        {
            using (SqlConnection con = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Dashboard_VentasHoy", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        return (decimal)cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al obtener ventas de hoy: " + ex.Message);
                    }
                }
            }
        }

        public List<DashboardBajoStock> ObtenerBajoStock()
        {
            List<DashboardBajoStock> lista = new List<DashboardBajoStock>();
            using (SqlConnection con = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Dashboard_BajoStock", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new DashboardBajoStock
                                {
                                    Nombre = reader.GetString("Nombre"),
                                    Stock = reader.GetInt32("Stock")
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al obtener bajo stock: " + ex.Message);
                    }
                }
            }
            return lista;
        }

        public List<DashboardUltimaVenta> ObtenerUltimasVentas()
        {
            List<DashboardUltimaVenta> lista = new List<DashboardUltimaVenta>();
            using (SqlConnection con = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Dashboard_UltimasVentas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new DashboardUltimaVenta
                                {
                                    FechaVenta = reader.GetDateTime("FechaVenta"),
                                    Cliente = reader.IsDBNull("Cliente") ? "Cliente Eliminado" : reader.GetString("Cliente"),
                                    Total = reader.GetDecimal("Total")
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al obtener últimas ventas: " + ex.Message);
                    }
                }
            }
            return lista;
        }
    }
}