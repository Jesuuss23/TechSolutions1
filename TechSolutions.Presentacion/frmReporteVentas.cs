using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSolutions.BLL;
using TechSolutions.Entidades;

namespace TechSolutions.Presentacion
{
    public partial class frmReporteVentas : Form
    {
        // --- AÑADE LA INSTANCIA DE LA BLL ---
        private readonly ReporteBLL _reporteBLL = new ReporteBLL();
        // ------------------------------------
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener las fechas
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                // --- INICIO DEL CAMBIO POR HILOS ---

                // A. Deshabilitamos el botón y mostramos un cursor de espera
                //    para que el usuario sepa que algo está pasando.
                btnGenerarReporte.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                dgvReporteVentas.DataSource = null; // Limpiamos la grilla

                // B. Llamamos al método ASÍNCRONO con 'await'.
                //    El hilo de la UI NO se bloqueará aquí.
                List<ReporteVenta> listaReporte = await _reporteBLL.ObtenerReporteVentasAsync(fechaInicio, fechaFin);

                // C. Cuando 'await' termina, el código sigue en el hilo de la UI.
                //    Restauramos el cursor y el botón.
                this.Cursor = Cursors.Default;
                btnGenerarReporte.Enabled = true;

                // --- FIN DEL CAMBIO POR HILOS ---

                // 3. Asignar la lista como la fuente de datos
                dgvReporteVentas.DataSource = listaReporte;

                // 4. Configuración visual (el código que ya tenías)
                if (listaReporte.Count > 0)
                {
                    dgvReporteVentas.Columns["IdVenta"].Visible = false;
                    // ... (el resto de tu configuración de columnas) ...
                }

                // 5. Mostrar mensaje si no hay resultados
                if (listaReporte.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron ventas en el rango de fechas seleccionado.",
                        "Sin Resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Restauramos el cursor y botón también si hay un error
                this.Cursor = Cursors.Default;
                btnGenerarReporte.Enabled = true;

                MessageBox.Show(
                    "Error inesperado al generar el reporte: " + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya datos en la cuadrícula
            if (dgvReporteVentas.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Primero debe generar un reporte para poder imprimir.",
                    "No hay datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Salimos del método
            }

            // 2. Le decimos a la Vista Previa que se muestre.
            //    Esto disparará automáticamente el evento 'docImprimir_PrintPage'
            vistaPreviaImpresion.ShowDialog();
        }

        private void docImprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                // --- 1. CONFIGURACIÓN INICIAL ---
                // Definir fuentes
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 10, FontStyle.Bold);
                Font bodyFont = new Font("Arial", 10);

                // Definir márgenes y posición
                float leftMargin = e.MarginBounds.Left;
                float topMargin = e.MarginBounds.Top;
                float yPos = topMargin; // Posición Y (vertical)
                float lineHeight = bodyFont.GetHeight(e.Graphics) + 5; // Alto de línea + espacio

                // --- 2. DIBUJAR EL TÍTULO ---
                e.Graphics.DrawString(
                    "Reporte de Ventas - TechSolutions",
                    titleFont,
                    Brushes.Black,
                    leftMargin,
                    yPos);
                yPos += titleFont.GetHeight(e.Graphics) * 2; // Dejar doble espacio

                // --- 3. DIBUJAR LAS CABECERAS (Definir posiciones X) ---
                float xFecha = leftMargin;
                float xCliente = leftMargin + 150;
                float xVendedor = leftMargin + 350;
                float xTotal = leftMargin + 500; // Alineado a la derecha

                e.Graphics.DrawString("Fecha de Venta", headerFont, Brushes.Black, xFecha, yPos);
                e.Graphics.DrawString("Cliente", headerFont, Brushes.Black, xCliente, yPos);
                e.Graphics.DrawString("Vendedor", headerFont, Brushes.Black, xVendedor, yPos);
                e.Graphics.DrawString("Total", headerFont, Brushes.Black, xTotal, yPos);
                yPos += lineHeight * 2; // Doble espacio después de cabeceras

                // --- 4. DIBUJAR EL CONTENIDO (Loop) ---
                // (Simplificado, no maneja múltiples páginas. Para este proyecto es suficiente)
                foreach (DataGridViewRow row in dgvReporteVentas.Rows)
                {
                    // Formatear los datos
                    string fecha = Convert.ToDateTime(row.Cells["FechaVenta"].Value).ToString("g");
                    string cliente = row.Cells["Cliente"].Value.ToString();
                    string vendedor = row.Cells["Vendedor"].Value.ToString();
                    string total = Convert.ToDecimal(row.Cells["Total"].Value).ToString("C"); // "C" de Currency

                    // Dibujar la línea
                    e.Graphics.DrawString(fecha, bodyFont, Brushes.Black, xFecha, yPos);
                    e.Graphics.DrawString(cliente, bodyFont, Brushes.Black, xCliente, yPos);
                    e.Graphics.DrawString(vendedor, bodyFont, Brushes.Black, xVendedor, yPos);
                    e.Graphics.DrawString(total, bodyFont, Brushes.Black, xTotal, yPos);

                    yPos += lineHeight; // Mover a la siguiente línea
                }

                // --- 5. FINALIZAR ---
                // Le decimos que ya no hay más páginas
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la vista de impresión: " + ex.Message);
            }

        }
    }
}
