
using System.Threading.Tasks;
using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;
using System.Collections.Generic;

namespace TechSolutions.BLL
{
    public class ReporteBLL
    {
        private readonly ReporteDAL _reporteDAL = new ReporteDAL();

        public async Task<List<ReporteVenta>> ObtenerReporteVentasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                return new List<ReporteVenta>();
            }

            try
            {
                return await Task.Run(() => _reporteDAL.ObtenerReporteVentas(fechaInicio, fechaFin));
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al obtener el reporte: " + ex.Message);
            }
        }

        public List<ReporteHistorialCliente> ObtenerHistorialCliente(int idCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            if (idCliente <= 0)
            {
                return new List<ReporteHistorialCliente>(); 
            }

            if (fechaInicio > fechaFin)
            {
                return new List<ReporteHistorialCliente>(); 
            }

            try
            {
                return _reporteDAL.ObtenerHistorialCliente(idCliente, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BLL al obtener historial de cliente: " + ex.Message);
            }
        }
    }
}