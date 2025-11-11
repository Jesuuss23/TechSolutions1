namespace TechSolutions.Entidades
{
    public class DashboardUltimaVenta
    {
        public DateTime FechaVenta { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}