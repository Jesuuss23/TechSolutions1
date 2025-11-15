

using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;

namespace TechSolutions.BLL
{
    public class VentaBLL
    {
        private readonly VentaDAL _ventaDAL = new VentaDAL();

        public bool RegistrarVenta(Venta venta)
        {
            if (venta.IdCliente <= 0 || venta.IdUsuario <= 0 || venta.Detalles.Count == 0)
            {
                return false;
            }

            try
            {
                return _ventaDAL.RegistrarVenta(venta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al registrar la venta: " + ex.Message);
            }
        }
    }
}