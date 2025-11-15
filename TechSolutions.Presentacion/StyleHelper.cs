// --- Archivo: StyleHelper.cs ---
// --- Proyecto: TechSolutions.Presentacion ---

// ¡Necesitamos este using para 'Color' y 'Font'!
using System.Drawing;
using System.Windows.Forms; // Para Control, DataGridView, etc.

namespace TechSolutions.Presentacion
{
    /// <summary>
    /// Clase estática para centralizar los estilos (colores y fuentes)
    /// de toda la aplicación.
    /// </summary>
    public static class StyleHelper
    {
        // --- 1. paleta de COLORES ---
        // Puedes cambiar estos valores para "tematizar" la app

        // Un azul oscuro para fondos (como el menú)
        public static Color ColorFondoPrincipal = Color.FromArgb(45, 52, 54);
        // Un gris oscuro para el contenido
        public static Color ColorFondoContenido = Color.FromArgb(99, 110, 114);
        // Un color de acento (ej. azul brillante) para botones
        public static Color ColorAcento = Color.FromArgb(0, 178, 255);
        // Color para el texto
        public static Color ColorTexto = Color.White;


        // --- 2. FUENTES ---
        public static Font FuenteTitulo = new Font("Arial", 16, FontStyle.Bold);
        public static Font FuenteNormal = new Font("Arial", 10, FontStyle.Regular);


        // --- 3. MÉTODOS AUXILIARES ---

        /// <summary>
        /// Aplica el estilo base a un formulario completo.
        /// </summary>
        public static void AplicarEstiloFormulario(Form formulario)
        {
            formulario.BackColor = ColorFondoContenido;
            formulario.ForeColor = ColorTexto;
            formulario.Font = FuenteNormal;

            // Aplica estilo a todos los controles DENTRO del formulario
            AplicarEstiloControles(formulario.Controls);
        }

        /// <summary>
        /// Aplica estilo a los DataGridViews.
        /// </summary>
        public static void AplicarEstiloDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = ColorFondoContenido;
            dgv.GridColor = ColorAcento;
            dgv.ForeColor = Color.Black; // El texto de la celda suele ser negro

            // Estilo de Cabecera
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorFondoPrincipal;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTexto;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false; // ¡Importante para que tome el estilo!

            // Estilo de Filas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        // Método recursivo para aplicar estilos a todos los controles
        private static void AplicarEstiloControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                // Estilo para Botones
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.BackColor = ColorAcento;
                    btn.ForeColor = ColorTexto;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }
                // Estilo para GroupBox
                else if (control is GroupBox)
                {
                    GroupBox gb = (GroupBox)control;
                    gb.ForeColor = ColorTexto;
                    // Llama recursivamente para estilizar lo que está DENTRO del GroupBox
                    AplicarEstiloControles(gb.Controls);
                }
                // Estilo para DataGridView
                else if (control is DataGridView)
                {
                    AplicarEstiloDataGridView((DataGridView)control);
                }
                // (Puedes añadir 'else if' para TextBoxes, Labels, etc.)
            }
        }
    }
}