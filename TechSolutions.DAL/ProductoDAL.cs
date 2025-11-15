

using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; 
using System.Collections.Generic;

namespace TechSolutions.DAL
{
    public class ProductoDAL
    {
        public List<Producto> ObtenerProductos()
        {
            List<Producto> listaProductos = new List<Producto>();

            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ObtenerProductos", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaProductos.Add(new Producto
                                {
                                    IdProducto = reader.GetInt32("IdProducto"),
                                    Nombre = reader.GetString("Nombre"),
                                    Descripcion = reader.GetString("Descripcion"),
                                    Precio = reader.GetDecimal("Precio"),
                                    Stock = reader.GetInt32("Stock"),
                                    IdCategoria = reader.GetInt32("IdCategoria"),
                                    NombreCategoria = reader.GetString("NombreCategoria"), // Del JOIN
                                    Estado = reader.GetBoolean("Estado")
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al obtener productos: " + ex.Message);
                    }
                }
            }
            return listaProductos;
        }

        public bool RegistrarProducto(Producto producto)
        {
            bool exito = false;
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarProducto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);

                    try
                    {
                        conexion.Open();
                        int resultado = (int)comando.ExecuteScalar();
                        if (resultado == 1) exito = true;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al registrar el producto: " + ex.Message);
                    }
                }
            }
            return exito;
        }

        public bool ActualizarProducto(Producto producto)
        {
            bool exito = false;
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ActualizarProducto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    comando.Parameters.AddWithValue("@Precio", producto.Precio);
                    comando.Parameters.AddWithValue("@Stock", producto.Stock);
                    comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);

                    try
                    {
                        conexion.Open();
                        int resultado = (int)comando.ExecuteScalar();
                        if (resultado == 1) exito = true;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al actualizar el producto: " + ex.Message);
                    }
                }
            }
            return exito;
        }

        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_EliminarProducto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdProducto", idProducto);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al eliminar el producto: " + ex.Message);
                    }
                }
            }
        }
    }
}