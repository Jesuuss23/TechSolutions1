// --- Archivo: ClienteBLL.cs ---
// --- Proyecto: TechSolutions.BLL ---

using TechSolutions.DAL;
using TechSolutions.Entidades;
using System.Collections.Generic; // Para List<>
using System; // Para Exception

namespace TechSolutions.BLL
{
    public class ClienteBLL
    {
        // Creamos una instancia de nuestra DAL de Cliente
        private readonly ClienteDAL _clienteDAL = new ClienteDAL();

        /// <summary>
        /// Lógica de negocio para obtener clientes.
        /// </summary>
        /// <returns>Lista de objetos Cliente.</returns>
        public List<Cliente> ObtenerClientes()
        {
            try
            {
                // Llamamos directamente a la DAL, 
                // ya que no hay reglas de negocio complejas para "leer".
                return _clienteDAL.ObtenerClientes();
            }
            catch (Exception ex)
            {
                // Manejar o relanzar la excepción
                throw new Exception("Error en la BLL al obtener clientes: " + ex.Message);
            }
        }

        /// <summary>
        /// Lógica de negocio para registrar un nuevo cliente.
        /// </summary>
        /// <param name="cliente">El objeto Cliente a registrar.</param>
        /// <returns>True si fue exitoso, False si falla la validación o registro.</returns>
        public bool RegistrarCliente(Cliente cliente)
        {
            // --- INICIO DE LA LÓGICA DE NEGOCIO ---

            // Regla 1: Validar datos obligatorios
            if (string.IsNullOrEmpty(cliente.Nombre) ||
                string.IsNullOrEmpty(cliente.Apellido) ||
                string.IsNullOrEmpty(cliente.Documento))
            {
                // No llamamos a la DAL si los datos básicos no están.
                // Podríamos lanzar una excepción personalizada aquí.
                return false;
            }

            // Regla 2: (Ejemplo) Normalizar datos
            cliente.Nombre = cliente.Nombre.Trim();
            cliente.Apellido = cliente.Apellido.Trim();
            cliente.Documento = cliente.Documento.Trim();

            // --- FIN DE LA LÓGICA DE NEGOCIO ---

            try
            {
                // 3. Llamar a la Capa de Datos (DAL)
                return _clienteDAL.RegistrarCliente(cliente);
            }
            catch (Exception ex)
            {
                // Manejar o relanzar la excepción
                throw new Exception("Error en la BLL al registrar el cliente: " + ex.Message);
            }
        }
        // --- Archivo: ClienteBLL.cs ---
        // (Pega esto dentro de la 'public class ClienteBLL')

        /// <summary>
        /// Lógica de negocio para actualizar un cliente existente.
        /// </summary>
        /// <param name="cliente">El objeto Cliente a actualizar.</param>
        /// <returns>True si fue exitoso, False si falla la validación o actualización.</returns>
        public bool ActualizarCliente(Cliente cliente)
        {
            // --- INICIO DE LA LÓGICA DE NEGOCIO ---

            // Regla 1: Validar datos obligatorios
            // (IdCliente <= 0 significa que no se seleccionó un cliente válido)
            if (cliente.IdCliente <= 0 ||
                string.IsNullOrEmpty(cliente.Nombre) ||
                string.IsNullOrEmpty(cliente.Apellido) ||
                string.IsNullOrEmpty(cliente.Documento))
            {
                // No llamamos a la DAL si los datos básicos no están.
                return false;
            }

            // Regla 2: Normalizar datos
            cliente.Nombre = cliente.Nombre.Trim();
            cliente.Apellido = cliente.Apellido.Trim();
            cliente.Documento = cliente.Documento.Trim();

            // --- FIN DE LA LÓGICA DE NEGOCIO ---

            try
            {
                // 3. Llamar a la Capa de Datos (DAL)
                return _clienteDAL.ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                // Manejar o relanzar la excepción
                throw new Exception("Error en la BLL al actualizar el cliente: " + ex.Message);
            }
        }
        // --- Archivo: ClienteBLL.cs ---
        // (Pega esto dentro de la 'public class ClienteBLL')

        /// <summary>
        /// Lógica de negocio para eliminar (lógicamente) un cliente.
        /// </summary>
        /// <param name="idCliente">El ID del cliente a eliminar.</param>
        /// <returns>True si fue exitoso, False si falla la validación.</returns>
        public bool EliminarCliente(int idCliente)
        {
            // --- INICIO DE LA LÓGICA DE NEGOCIO ---

            // Regla 1: Validar que el ID sea válido
            if (idCliente <= 0)
            {
                // No llamamos a la DAL si el ID no es válido.
                return false;
            }

            // --- FIN DE LA LÓGICA DE NEGOCIO ---

            try
            {
                // 3. Llamar a la Capa de Datos (DAL)
                _clienteDAL.EliminarCliente(idCliente);
                return true; // Asumimos éxito si no hay excepciones
            }
            catch (Exception ex)
            {
                // Manejar o relanzar la excepción
                throw new Exception("Error en la BLL al eliminar el cliente: " + ex.Message);
            }
        }
    }
}