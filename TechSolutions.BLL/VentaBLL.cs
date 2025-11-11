// --- Archivo: VentaBLL.cs ---
// --- Proyecto: TechSolutions.BLL ---

using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;

namespace TechSolutions.BLL
{
    public class VentaBLL
    {
        private readonly VentaDAL _ventaDAL = new VentaDAL();

        /// <summary>
        /// Lógica de negocio para registrar una venta.
        /// </summary>
        public bool RegistrarVenta(Venta venta)
        {
            // --- Reglas de Negocio ---
            if (venta.IdCliente <= 0 || venta.IdUsuario <= 0 || venta.Detalles.Count == 0)
            {
                // No se puede registrar una venta sin cliente, vendedor o productos
                return false;
            }

            try
            {
                return _ventaDAL.RegistrarVenta(venta);
            }
            catch (Exception ex)
            {
                // Manejar o relanzar la excepción (ej. stock insuficiente)
                throw new Exception("Error en BLL al registrar la venta: " + ex.Message);
            }
        }
    }
}