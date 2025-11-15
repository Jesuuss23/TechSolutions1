

using TechSolutions.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace TechSolutions.DAL
{
    public class RolDAL
    {
        public List<Rol> ObtenerRoles()
        {
            List<Rol> lista = new List<Rol>();
            using (SqlConnection con = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerRoles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Rol
                                {
                                    IdRol = reader.GetInt32("IdRol"),
                                    NombreRol = reader.GetString("NombreRol")
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al obtener roles: " + ex.Message);
                    }
                }
            }
            return lista;
        }
    }
}