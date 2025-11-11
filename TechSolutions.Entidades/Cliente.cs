// --- Archivo: Cliente.cs ---
// --- Proyecto: TechSolutions.Entidades ---

namespace TechSolutions.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        // --- AÑADE ESTA PROPIEDAD ---
        /// <summary>
        /// Propiedad calculada para mostrar en ComboBoxes.
        /// </summary>
        public string NombreCompleto
        {
            get { return $"{Apellido}, {Nombre}"; } // E.g., "Pérez, Juan"
        }
    }
}