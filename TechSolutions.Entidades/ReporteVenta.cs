// --- Archivo: ReporteVenta.cs ---
// --- Proyecto: TechSolutions.Entidades ---

using System;

namespace TechSolutions.Entidades
{
    /// <summary>
    /// Representa una fila del resultado del sp_ReporteVentasPorFecha.
    /// </summary>
    public class ReporteVenta
    {
        public int IdVenta { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Vendedor { get; set; } = string.Empty;
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}