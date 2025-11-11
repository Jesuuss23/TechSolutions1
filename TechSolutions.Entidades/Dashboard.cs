using System.Collections.Generic;

namespace TechSolutions.Entidades
{
    public class Dashboard
    {
        public decimal TotalVentasHoy { get; set; }
        public List<DashboardBajoStock> ProductosBajoStock { get; set; }
        public List<DashboardUltimaVenta> UltimasVentas { get; set; }

        public Dashboard()
        {
            ProductosBajoStock = new List<DashboardBajoStock>();
            UltimasVentas = new List<DashboardUltimaVenta>();
        }
    }
}