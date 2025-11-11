using TechSolutions.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace TechSolutions.DAL
{
    public class CategoriaDAL
    {
        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            using (SqlConnection con = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerCategorias", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lista.Add(new Categoria
                                {
                                    IdCategoria = reader.GetInt32("IdCategoria"),
                                    NombreCategoria = reader.GetString("NombreCategoria")
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al obtener categorías: " + ex.Message);
                    }
                }
            }
            return lista;
        }
    }
}