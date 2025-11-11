// --- Archivo: ClienteDAL.cs ---
// --- Proyecto: TechSolutions.DAL ---

using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; // Para usar 'Cliente'
using System.Collections.Generic; // Para usar 'List<>'

namespace TechSolutions.DAL
{
    public class ClienteDAL
    {
        /// <summary>
        /// Obtiene una lista de todos los clientes activos desde la BD.
        /// </summary>
        /// <returns>Una lista de objetos Cliente.</returns>
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
            } // La conexión se cierra aquí

            return listaClientes;
        }

        /// <summary>
        /// Registra un nuevo cliente en la base de datos.
        /// </summary>
        /// <param name="cliente">El objeto Cliente con los datos a insertar.</param>
        /// <returns>True si fue exitoso, False si el documento ya existía.</returns>
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

                        // Ejecutamos el SP y leemos el resultado (1 o 0)
                        int resultado = (int)comando.ExecuteScalar();

                        if (resultado == 1)
                        {
                            exito = true;
                        }
                        // Si es 0, 'exito' permanece false
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al registrar el cliente: " + ex.Message);
                    }
                }
            } // La conexión se cierra aquí

            return exito;
        }
        // --- Archivo: ClienteDAL.cs ---
        // (Pega esto dentro de la 'public class ClienteDAL')

        /// <summary>
        /// Actualiza un cliente existente en la base de datos.
        /// </summary>
        /// <param name="cliente">El objeto Cliente con los datos a actualizar (Debe incluir IdCliente).</param>
        /// <returns>True si fue exitoso, False si el documento está duplicado.</returns>
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

                        // Ejecutamos el SP y leemos el resultado (1 o 0)
                        int resultado = (int)comando.ExecuteScalar();

                        if (resultado == 1)
                        {
                            exito = true;
                        }
                        // Si es 0, 'exito' permanece false (documento duplicado)
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al actualizar el cliente: " + ex.Message);
                    }
                }
            } // La conexión se cierra aquí

            return exito;
        }
        // --- Archivo: ClienteDAL.cs ---
        // (Pega esto dentro de la 'public class ClienteDAL')

        /// <summary>
        /// Realiza una eliminación lógica (Estado = 0) de un cliente.
        /// </summary>
        /// <param name="idCliente">El ID del cliente a eliminar.</param>
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

                        // Solo ejecutamos el comando, no devuelve nada
                        comando.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Manejar el error
                        throw new Exception("Error en la base de datos al eliminar el cliente: " + ex.Message);
                    }
                }
            } // La conexión se cierra aquí
        }
    }
}