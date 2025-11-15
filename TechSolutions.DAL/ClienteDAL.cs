
using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; 
using System.Collections.Generic; 

namespace TechSolutions.DAL
{
    public class ClienteDAL
    {
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ObtenerClientes", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Mapeamos los datos del reader al objeto Cliente
                                Cliente cliente = new Cliente
                                {
                                    IdCliente = reader.GetInt32("IdCliente"),
                                    Nombre = reader.GetString("Nombre"),
                                    Apellido = reader.GetString("Apellido"),
                                    Documento = reader.GetString("Documento"),
                                    Correo = reader.GetString("Correo"),
                                    Telefono = reader.GetString("Telefono"),
                                    Direccion = reader.GetString("Direccion"),
                                    Estado = reader.GetBoolean("Estado")
                                };
                                listaClientes.Add(cliente);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al obtener clientes: " + ex.Message);
                    }
                }
            } 

            return listaClientes;
        }

        public bool RegistrarCliente(Cliente cliente)
        {
            bool exito = false;

            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Añadir los parámetros del SP
                    comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@Documento", cliente.Documento);
                    comando.Parameters.AddWithValue("@Correo", cliente.Correo);
                    comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                    try
                    {
                        conexion.Open();

                        int resultado = (int)comando.ExecuteScalar();

                        if (resultado == 1)
                        {
                            exito = true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al registrar el cliente: " + ex.Message);
                    }
                }
            } 

            return exito;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            bool exito = false;

            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ActualizarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Añadir los parámetros del SP
                    comando.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@Documento", cliente.Documento);
                    comando.Parameters.AddWithValue("@Correo", cliente.Correo);
                    comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);

                    try
                    {
                        conexion.Open();

                        int resultado = (int)comando.ExecuteScalar();

                        if (resultado == 1)
                        {
                            exito = true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al actualizar el cliente: " + ex.Message);
                    }
                }
            }

            return exito;
        }


        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_EliminarCliente", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Añadir el parámetro del SP
                    comando.Parameters.AddWithValue("@IdCliente", idCliente);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al eliminar el cliente: " + ex.Message);
                    }
                }
            }
        }
    }
}