
using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; 

namespace TechSolutions.DAL
{
    public class UsuarioDAL
    {
        public Usuario Login(string nombreUsuario, byte[] passwordHash)
        {
            Usuario usuarioLogueado = null;

            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_LoginUsuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    try
                    {
                        conexion.Open();

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuarioLogueado = new Usuario
                                {
                                    IdUsuario = reader.GetInt32("IdUsuario"),
                                    NombreUsuario = reader.GetString("NombreUsuario"),
                                    NombreRol = reader.GetString("NombreRol")
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al intentar loguear: " + ex.Message);
                    }
                }
            } 

            return usuarioLogueado;
        }

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
                        comando.ExecuteNonQuery(); 
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