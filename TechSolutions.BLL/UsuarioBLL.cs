// --- Archivo: UsuarioBLL.cs ---
// --- Proyecto: TechSolutions.BLL ---

// Necesitamos 'usings' para las otras dos capas y para la seguridad
using TechSolutions.DAL;
using TechSolutions.Entidades;
using System.Security.Cryptography; // Para la clase SHA512

namespace TechSolutions.BLL
{
    public class UsuarioBLL
    {
        // Creamos una instancia de nuestra DAL de Usuario.
        // La BLL le dará órdenes a esta instancia.
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        /// <summary>
        /// Lógica de negocio para validar un usuario.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario en texto plano.</param>
        /// <param name="password">La contraseña en texto plano.</param>
        /// <returns>Un objeto Usuario si es exitoso, o null si falla.</returns>
        public Usuario Login(string nombreUsuario, string password)
        {
            // --- INICIO DE LA LÓGICA DE NEGOCIO ---

            // Regla 1: Validar entradas
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
            {
                // No tiene sentido ir a la BD si los campos están vacíos.
                return null;
            }

            // Regla 2: Convertir la contraseña a Hash (SHA-512)
            // Aquí usamos la clase 'SeguridadHelper' que creamos antes.
            byte[] passwordHash = SeguridadHelper.GenerarHashSHA512(password);

            // --- FIN DE LA LÓGICA DE NEGOCIO ---

            // 3. Llamar a la Capa de Datos (DAL)
            // La BLL no sabe CÓMO se loguea, solo le dice a la DAL:
            // "Toma estas credenciales hasheadas y valídalas".
            Usuario usuario = _usuarioDAL.Login(nombreUsuario, passwordHash);

            // 4. Devolver el resultado a la Capa de Presentación
            return usuario;
        }

        // Aquí podrías añadir más lógicas de negocio, como:
        // public void CrearUsuario(Usuario nuevoUsuario) { ... }
        // public void CambiarPassword(int idUsuario, string nuevaPassword) { ... }
        // --- Archivo: UsuarioBLL.cs ---
        // (Pega esto dentro de la 'public class UsuarioBLL')

        /// <summary>
        /// Lógica de negocio para obtener todos los usuarios.
        /// </summary>
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

        /// <summary>
        /// Lógica de negocio para registrar un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El objeto Usuario a registrar.</param>
        /// <param name="password">La contraseña en TEXTO PLANO.</param>
        /// <returns>True si fue exitoso.</returns>
        public bool RegistrarUsuario(Usuario usuario, string password)
        {
            // --- Reglas de Negocio ---
            if (string.IsNullOrEmpty(usuario.NombreUsuario) ||
                string.IsNullOrEmpty(usuario.Email) ||
                string.IsNullOrEmpty(password) ||
                usuario.IdRol <= 0)
            {
                return false; // Datos básicos incompletos
            }

            // --- LÓGICA DE SEGURIDAD CLAVE ---
            // 1. Hasheamos la contraseña antes de enviarla a la DAL
            byte[] passwordHash = SeguridadHelper.GenerarHashSHA512(password);

            try
            {
                // 2. Enviamos el usuario y el HASH a la DAL
                return _usuarioDAL.RegistrarUsuario(usuario, passwordHash);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al registrar el usuario: " + ex.Message);
            }
        }

        /// <summary>
        /// Lógica de negocio para actualizar un usuario.
        /// </summary>
        public bool ActualizarUsuario(Usuario usuario)
        {
            // --- Reglas de Negocio ---
            if (usuario.IdUsuario <= 0 ||
                string.IsNullOrEmpty(usuario.NombreUsuario) ||
                string.IsNullOrEmpty(usuario.Email) ||
                usuario.IdRol <= 0)
            {
                return false; // Datos básicos incompletos
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

        /// <summary>
        /// Lógica de negocio para eliminar (lógicamente) un usuario.
        /// </summary>
        public bool EliminarUsuario(int idUsuario)
        {
            // --- Reglas de Negocio ---
            if (idUsuario <= 0)
            {
                return false; // ID no válido
            }

            try
            {
                _usuarioDAL.EliminarUsuario(idUsuario);
                return true; // Éxito si no hay excepción
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al eliminar el usuario: " + ex.Message);
            }
        }
        // --- Archivo: UsuarioBLL.cs ---
        // (Pega esto dentro de la 'public class UsuarioBLL')

        /// <summary>
        /// Lógica de negocio para restablecer la contraseña de un usuario.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario.</param>
        /// <param name="nuevoPasswordPlano">La nueva contraseña en TEXTO PLANO.</param>
        /// <returns>True si fue exitoso.</returns>
        public bool ResetPassword(int idUsuario, string nuevoPasswordPlano)
        {
            // --- Reglas de Negocio ---
            if (idUsuario <= 0 || string.IsNullOrEmpty(nuevoPasswordPlano))
            {
                return false; // Datos inválidos
            }

            // --- LÓGICA DE SEGURIDAD ---
            // 1. Hasheamos la nueva contraseña
            byte[] passwordHash = SeguridadHelper.GenerarHashSHA512(nuevoPasswordPlano);

            try
            {
                // 2. Enviamos el ID y el HASH a la DAL
                _usuarioDAL.ResetPassword(idUsuario, passwordHash);
                return true; // Éxito si no hay excepción
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al restablecer la contraseña: " + ex.Message);
            }
        }
    }
}