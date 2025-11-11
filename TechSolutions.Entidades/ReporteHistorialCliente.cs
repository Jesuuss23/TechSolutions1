// --- Archivo: ReporteHistorialCliente.cs ---
// --- Proyecto: TechSolutions.Entidades ---

using System;

namespace TechSolutions.Entidades
{
    /// <summary>
    /// Representa una fila del resultado del sp_ReporteHistorialCliente.
    /// </summary>
    public class ReporteHistorialCliente
    {
        public DateTime FechaVenta { get; set; }
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}