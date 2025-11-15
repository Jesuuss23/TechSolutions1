

using System.Collections.Generic; // Necesario para List<>

namespace TechSolutions.Entidades
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        public List<DetalleVenta> Detalles { get; set; }

        public Venta()
        {
            Detalles = new List<DetalleVenta>();
        }
    }
}