

using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades;
using System.Collections.Generic; // Para List<>

namespace TechSolutions.DAL
{
    public class VentaDAL
    {
        public bool RegistrarVenta(Venta venta)
        {
            DataTable tvpDetalleVenta = new DataTable();
            tvpDetalleVenta.Columns.Add("IdProducto", typeof(int));
            tvpDetalleVenta.Columns.Add("Cantidad", typeof(int));
            tvpDetalleVenta.Columns.Add("PrecioUnitario", typeof(decimal));

            foreach (var detalle in venta.Detalles)
            {
                tvpDetalleVenta.Rows.Add(detalle.IdProducto, detalle.Cantidad, detalle.PrecioUnitario);
            }

            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_RegistrarVenta", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@IdCliente", venta.IdCliente);
                    comando.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                    SqlParameter tvpParam = comando.Parameters.AddWithValue("@DetalleVenta", tvpDetalleVenta);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    tvpParam.TypeName = "dbo.TVP_DetalleVenta"; 

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en la base de datos al registrar la venta: " + ex.Message);
                    }
                }
            }
        }
    }
}