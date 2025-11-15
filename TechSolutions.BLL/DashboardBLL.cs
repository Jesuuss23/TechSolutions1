using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;

namespace TechSolutions.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL _dashboardDAL = new DashboardDAL();

        public Dashboard ObtenerDatosDashboard()
        {
            try
            {
                Dashboard dashboardData = new Dashboard();

                dashboardData.TotalVentasHoy = _dashboardDAL.ObtenerVentasHoy();
                dashboardData.ProductosBajoStock = _dashboardDAL.ObtenerBajoStock();
                dashboardData.UltimasVentas = _dashboardDAL.ObtenerUltimasVentas();

                return dashboardData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al cargar el dashboard: " + ex.Message);
            }
        }
    }
}