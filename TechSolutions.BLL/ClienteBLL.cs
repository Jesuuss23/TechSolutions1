

using TechSolutions.DAL;
using TechSolutions.Entidades;
using System.Collections.Generic; 
using System; 

namespace TechSolutions.BLL
{
    public class ClienteBLL
    {

        private readonly ClienteDAL _clienteDAL = new ClienteDAL();

        public List<Cliente> ObtenerClientes()
        {
            try
            {

                return _clienteDAL.ObtenerClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al obtener clientes: " + ex.Message);
            }
        }

        public bool RegistrarCliente(Cliente cliente)
        {

            if (string.IsNullOrEmpty(cliente.Nombre) ||
                string.IsNullOrEmpty(cliente.Apellido) ||
                string.IsNullOrEmpty(cliente.Documento))
            {
                return false;
            }

            cliente.Nombre = cliente.Nombre.Trim();
            cliente.Apellido = cliente.Apellido.Trim();
            cliente.Documento = cliente.Documento.Trim();


            try
            {
                return _clienteDAL.RegistrarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al registrar el cliente: " + ex.Message);
            }
        }
        public bool ActualizarCliente(Cliente cliente)
        {
            if (cliente.IdCliente <= 0 ||
                string.IsNullOrEmpty(cliente.Nombre) ||
                string.IsNullOrEmpty(cliente.Apellido) ||
                string.IsNullOrEmpty(cliente.Documento))
            {
                return false;
            }

            cliente.Nombre = cliente.Nombre.Trim();
            cliente.Apellido = cliente.Apellido.Trim();
            cliente.Documento = cliente.Documento.Trim();


            try
            {
                return _clienteDAL.ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al actualizar el cliente: " + ex.Message);
            }
        }
        public bool EliminarCliente(int idCliente)
        {

            if (idCliente <= 0)
            {
                return false;
            }


            try
            {
                _clienteDAL.EliminarCliente(idCliente);
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al eliminar el cliente: " + ex.Message);
            }
        }
    }
}