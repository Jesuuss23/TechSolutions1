// --- Archivo: ProductoDAL.cs ---
// --- Proyecto: TechSolutions.DAL ---

using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; // Para 'Producto'
using System.Collections.Generic; // Para 'List<>'

namespace TechSolutions.DAL
{
    public class ProductoDAL
    {
        /// <summary>
        /// Obtiene una lista de todos los productos activos.
        /// </summary>
        /// <returns>Una lista de objetos Producto.</returns>
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

        /// <summary>
        /// Registra un nuevo producto en la base de datos.
        /// </summary>
        /// <param name="producto">El objeto Producto a insertar.</param>
        /// <returns>True si fue exitoso, False si el nombre ya existía.</returns>
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

        /// <summary>
        /// Actualiza un producto existente en la base de datos.
        /// </summary>
        /// <param name="producto">El objeto Producto con los datos a actualizar.</param>
        /// <returns>True si fue exitoso, False si el nombre está duplicado.</returns>
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

        /// <summary>
        /// Realiza una eliminación lógica (Estado = 0) de un producto.
        /// </summary>
        /// <param name="idProducto">El ID del producto a eliminar.</param>
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