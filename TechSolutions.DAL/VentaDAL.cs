// --- Archivo: VentaDAL.cs ---
// --- Proyecto: TechSolutions.DAL ---

using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades;
using System.Collections.Generic; // Para List<>

namespace TechSolutions.DAL
{
    public class VentaDAL
    {
        /// <summary>
        /// Registra una venta completa (cabecera y detalle) usando una transacción.
        /// </summary>
        /// <param name="venta">El objeto Venta que contiene los detalles.</param>
        /// <returns>True si la transacción fue exitosa.</returns>
        public bool RegistrarVenta(Venta venta)
        {
            // 1. Crear el DataTable para el Tipo Tabla (TVP_DetalleVenta)
            //    Las columnas deben coincidir EXACTAMENTE con tu tipo en SQL Server
            DataTable tvpDetalleVenta = new DataTable();
            tvpDetalleVenta.Columns.Add("IdProducto", typeof(int));
            tvpDetalleVenta.Columns.Add("Cantidad", typeof(int));
            tvpDetalleVenta.Columns.Add("PrecioUnitario", typeof(decimal));

            // 2. Llenar el DataTable con los detalles del "carrito"
            foreach (var detalle in venta.Detalles)
            {
                tvpDetalleVenta.Rows.Add(detalle.IdProducto, detalle.Cantidad, detalle.PrecioUnitario);
            }

            // 3. Configurar y ejecutar el Stored Procedure
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarVenta", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // 4. Añadir los parámetros (Cabecera)
                    comando.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                    comando.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                    // El SP calcula el total, pero lo enviamos por si acaso
                    // (Tu SP sp_RegistrarVenta original lo calculaba, así que quitamos este)
                    // comando.Parameters.AddWithValue("@Total", venta.Total); 

                    // 5. --- AÑADIR EL PARÁMETRO TIPO TABLA ---
                    SqlParameter tvpParam = comando.Parameters.AddWithValue("@DetalleVenta", tvpDetalleVenta);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.TVP_DetalleVenta"; // Nombre exacto de tu TIPO en SQL

                    try
                    {
                        conexion.Open();
                        // Ejecutamos la transacción
                        comando.ExecuteNonQuery();

                        // Si no hubo excepciones (el CATCH del SP no saltó), fue un éxito
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        // Si el SP falla (ej. RAISERROR por stock), 
                        // la excepción se captura aquí.
                        // El ROLLBACK ocurre en el SP.
                        throw new Exception("Error en la base de datos al registrar la venta: " + ex.Message);
                    }
                }
            }
        }
    }
}