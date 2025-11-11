using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;

namespace TechSolutions.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL _dashboardDAL = new DashboardDAL();

        /// <summary>
        /// Obtiene todos los datos consolidados para el Dashboard.
        /// </summary>
        public Dashboard ObtenerDatosDashboard()
        {
            try
            {
                Dashboard dashboardData = new Dashboard();

                // Hacemos las 3 llamadas a la DAL
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