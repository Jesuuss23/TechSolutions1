
namespace TechSolutions.Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }

        
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } 
    }
}