// --- Archivo: ReporteBLL.cs ---
// --- Proyecto: TechSolutions.BLL ---
using System.Threading.Tasks;
using TechSolutions.DAL;
using TechSolutions.Entidades;
using System;
using System.Collections.Generic;

namespace TechSolutions.BLL
{
    public class ReporteBLL
    {
        // Instancia de la DAL de Reporte
        private readonly ReporteDAL _reporteDAL = new ReporteDAL();

        /// <summary>
        /// Lógica de negocio para obtener el reporte de ventas.
        /// </summary>
        /// /// <summary>
        /// Lógica de negocio para obtener el reporte de ventas (ASÍNCRONO).
        /// </summary>
        public async Task<List<ReporteVenta>> ObtenerReporteVentasAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            // --- Reglas de Negocio ---
            if (fechaInicio > fechaFin)
            {
                return new List<ReporteVenta>();
            }

            try
            {
                // Task.Run() ejecuta el código en un hilo secundario del ThreadPool
                return await Task.Run(() => _reporteDAL.ObtenerReporteVentas(fechaInicio, fechaFin));
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al obtener el reporte: " + ex.Message);
            }
        }

        /// <summary>
        /// Lógica de negocio para obtener el historial detallado de un cliente.
        /// </summary>
        public List<ReporteHistorialCliente> ObtenerHistorialCliente(int idCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            // --- Reglas de Negocio ---

            // Regla 1: Validar que el ID del cliente sea válido
            if (idCliente <= 0)
            {
                return new List<ReporteHistorialCliente>(); // ID no válido
            }

            // Regla 2: Validar rango de fechas
            if (fechaInicio > fechaFin)
            {
                return new List<ReporteHistorialCliente>(); // Rango inválido
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