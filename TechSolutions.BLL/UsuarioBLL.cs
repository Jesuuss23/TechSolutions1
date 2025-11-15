
using TechSolutions.DAL;
using TechSolutions.Entidades;
using System.Security.Cryptography; // Para la clase SHA512

namespace TechSolutions.BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public Usuario Login(string nombreUsuario, string password)
        {

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            byte[] passwordHash = SeguridadHelper.GenerarHashSHA512(password);


            Usuario usuario = _usuarioDAL.Login(nombreUsuario, passwordHash);

            return usuario;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            try
            {
                return _usuarioDAL.ObtenerUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al obtener usuarios: " + ex.Message);
            }
        }

        public bool RegistrarUsuario(Usuario usuario, string password)
        {
            if (string.IsNullOrEmpty(usuario.NombreUsuario) ||
                string.IsNullOrEmpty(usuario.Email) ||
                string.IsNullOrEmpty(password) ||
                usuario.IdRol <= 0)
            {
                return false; 
            }

            byte[] passwordHash = SeguridadHelper.GenerarHashSHA512(password);

            try
            {
                return _usuarioDAL.RegistrarUsuario(usuario, passwordHash);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al registrar el usuario: " + ex.Message);
            }
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            if (usuario.IdUsuario <= 0 ||
                string.IsNullOrEmpty(usuario.NombreUsuario) ||
                string.IsNullOrEmpty(usuario.Email) ||
                usuario.IdRol <= 0)
            {
                return false; 
            }

            try
            {
                return _usuarioDAL.ActualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al actualizar el usuario: " + ex.Message);
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            if (idUsuario <= 0)
            {
                return false; 
            }

            try
            {
                _usuarioDAL.EliminarUsuario(idUsuario);
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al eliminar el usuario: " + ex.Message);
            }
        }
        public bool ResetPassword(int idUsuario, string nuevoPasswordPlano)
        {
            if (idUsuario <= 0 || string.IsNullOrEmpty(nuevoPasswordPlano))
            {
                return false; 
            }

            byte[] passwordHash = SeguridadHelper.GenerarHashSHA512(nuevoPasswordPlano);

            try
            {
                _usuarioDAL.ResetPassword(idUsuario, passwordHash);
                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al restablecer la contraseña: " + ex.Message);
            }
        }
    }
}