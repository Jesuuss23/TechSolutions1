// --- Archivo: UsuarioDAL.cs ---
// --- Proyecto: TechSolutions.DAL ---

// Estos son los 'usings' que necesitamos
using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; // ¡Importante! Para usar la clase 'Usuario'

namespace TechSolutions.DAL
{
    public class UsuarioDAL
    {
        /// <summary>
        /// Valida las credenciales de un usuario contra la base de datos
        /// usando el Stored Procedure 'sp_LoginUsuario'.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario.</param>
        /// <param name="passwordHash">El HASH (SHA-512) de la contraseña.</param>
        /// <returns>Un objeto Usuario si es exitoso, o null si falla.</returns>
        public Usuario Login(string nombreUsuario, byte[] passwordHash)
        {
            Usuario usuarioLogueado = null;

            // Obtenemos la conexión desde nuestro Singleton
            // 'using' asegura que la conexión se cierre al final
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                // 1. Crear el comando y especificar que es un SP
                using (SqlCommand comando = new SqlCommand("sp_LoginUsuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // 2. Añadir los parámetros que espera el SP
                    comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    try
                    {
                        // 3. Abrir la conexión
                        conexion.Open();

                        // 4. Ejecutar el comando y obtener un lector
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // 5. ¿El lector encontró un registro?
                            if (reader.Read())
                            {
                                // 6. Sí, creamos el objeto Usuario con los datos
                                usuarioLogueado = new Usuario
                                {
                                    IdUsuario = reader.GetInt32("IdUsuario"),
                                    NombreUsuario = reader.GetString("NombreUsuario"),
                                    NombreRol = reader.GetString("NombreRol")
                                    // Nota: Tu SP 'sp_LoginUsuario' debe devolver estas 3 columnas
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Aquí podrías registrar el error en un log si quisieras
                        // Por ahora, solo lo lanzamos para que la BLL lo vea
                        throw new Exception("Error en la base de datos al intentar loguear: " + ex.Message);
                    }
                }
            } // La conexión se cierra automáticamente aquí

            // 7. Devolver el usuario (o null si el login falló)
            return usuarioLogueado;
        }

        // --- Archivo: UsuarioDAL.cs ---
        // (Pega esto dentro de la 'public class UsuarioDAL')

        /// <summary>
        /// Obtiene una lista de todos los usuarios (sin el hash).
        /// </summary>
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ObtenerUsuarios", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conexion.Open();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listaUsuarios.Add(new Usuario
                                {
                                    IdUsuario = reader.GetInt32("IdUsuario"),
                                    NombreUsuario = reader.GetString("NombreUsuario"),
                                    Email = reader.GetString("Email"),
                                    IdRol = reader.GetInt32("IdRol"),
                                    NombreRol = reader.GetString("NombreRol"),
                                    Estado = reader.GetBoolean("Estado"),
                                    // Manejo de 'UltimoAcceso' nulo
                                    UltimoAcceso = reader.IsDBNull("UltimoAcceso") ? (DateTime?)null : reader.GetDateTime("UltimoAcceso")
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al obtener usuarios: " + ex.Message);
                    }
                }
            }
            return listaUsuarios;
        }

        /// <summary>
        /// Registra un nuevo usuario en la BD.
        /// </summary>
        /// <param name="usuario">El objeto Usuario a registrar (sin ID).</param>
        /// <param name="passwordHash">El hash SHA-512 de la contraseña.</param>
        /// <returns>True si fue exitoso, False si ya existe.</returns>
        public bool RegistrarUsuario(Usuario usuario, byte[] passwordHash)
        {
            bool exito = false;
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarUsuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    comando.Parameters.AddWithValue("@Email", usuario.Email);
                    comando.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    comando.Parameters.AddWithValue("@IdRol", usuario.IdRol);

                    try
                    {
                        conexion.Open();
                        int resultado = (int)comando.ExecuteScalar();
                        if (resultado == 1) exito = true;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al registrar el usuario: " + ex.Message);
                    }
                }
            }
            return exito;
        }

        /// <summary>
        /// Actualiza los datos de un usuario (sin tocar la contraseña).
        /// </summary>
        /// <param name="usuario">El objeto Usuario con los datos a modificar.</param>
        /// <returns>True si fue exitoso, False si hay duplicados.</returns>
        public bool ActualizarUsuario(Usuario usuario)
        {
            bool exito = false;
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_ActualizarUsuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    comando.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    comando.Parameters.AddWithValue("@Email", usuario.Email);
                    comando.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                    comando.Parameters.AddWithValue("@Estado", usuario.Estado);

                    try
                    {
                        conexion.Open();
                        int resultado = (int)comando.ExecuteScalar();
                        if (resultado == 1) exito = true;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al actualizar el usuario: " + ex.Message);
                    }
                }
            }
            return exito;
        }

        /// <summary>
        /// Realiza una eliminación lógica (Estado = 0) de un usuario.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario a eliminar.</param>
        public void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_EliminarUsuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al eliminar el usuario: " + ex.Message);
                    }
                }
            }
        }

        // --- Archivo: UsuarioDAL.cs ---
        // (Pega esto dentro de la 'public class UsuarioDAL')

        /// <summary>
        /// Restablece la contraseña de un usuario en la BD.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario a modificar.</param>
        /// <param name="nuevoPasswordHash">El nuevo hash SHA-512.</param>
        public void ResetPassword(int idUsuario, byte[] nuevoPasswordHash)
        {
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_Admin_ResetPassword", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    comando.Parameters.AddWithValue("@NuevoPasswordHash", nuevoPasswordHash);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery(); // Solo ejecuta, no devuelve nada
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en DAL al restablecer la contraseña: " + ex.Message);
                    }
                }
            }
        }
    }
}