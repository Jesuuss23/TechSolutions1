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
using Microsoft.VisualBasic;
using TechSolutions.BLL;
using TechSolutions.Entidades;

namespace TechSolutions.Presentacion
{
    public partial class frmReporteVentas : Form
    {
        private readonly ReporteBLL _reporteBLL = new ReporteBLL();

        private readonly EmailHelper _emailHelper = new EmailHelper();
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                btnGenerarReporte.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                dgvReporteVentas.DataSource = null; 

                List<ReporteVenta> listaReporte = await _reporteBLL.ObtenerReporteVentasAsync(fechaInicio, fechaFin);

                this.Cursor = Cursors.Default;
                btnGenerarReporte.Enabled = true;


                dgvReporteVentas.DataSource = listaReporte;

                if (listaReporte.Count > 0)
                {
                    dgvReporteVentas.Columns["IdVenta"].Visible = false;
                }

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
            if (dgvReporteVentas.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Primero debe generar un reporte para poder imprimir.",
                    "No hay datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }

            vistaPreviaImpresion.ShowDialog();
        }

        private void docImprimir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font headerFont = new Font("Arial", 10, FontStyle.Bold);
                Font bodyFont = new Font("Arial", 10);

                float leftMargin = e.MarginBounds.Left;
                float topMargin = e.MarginBounds.Top;
                float yPos = topMargin; 
                float lineHeight = bodyFont.GetHeight(e.Graphics) + 5; 

                e.Graphics.DrawString(
                    "Reporte de Ventas - TechSolutions",
                    titleFont,
                    Brushes.Black,
                    leftMargin,
                    yPos);
                yPos += titleFont.GetHeight(e.Graphics) * 2; 

                float xFecha = leftMargin;
                float xCliente = leftMargin + 150;
                float xVendedor = leftMargin + 350;
                float xTotal = leftMargin + 500; 

                e.Graphics.DrawString("Fecha de Venta", headerFont, Brushes.Black, xFecha, yPos);
                e.Graphics.DrawString("Cliente", headerFont, Brushes.Black, xCliente, yPos);
                e.Graphics.DrawString("Vendedor", headerFont, Brushes.Black, xVendedor, yPos);
                e.Graphics.DrawString("Total", headerFont, Brushes.Black, xTotal, yPos);
                yPos += lineHeight * 2; 


                foreach (DataGridViewRow row in dgvReporteVentas.Rows)
                {
                    string fecha = Convert.ToDateTime(row.Cells["FechaVenta"].Value).ToString("g");
                    string cliente = row.Cells["Cliente"].Value.ToString();
                    string vendedor = row.Cells["Vendedor"].Value.ToString();
                    string total = Convert.ToDecimal(row.Cells["Total"].Value).ToString("C"); 

                    e.Graphics.DrawString(fecha, bodyFont, Brushes.Black, xFecha, yPos);
                    e.Graphics.DrawString(cliente, bodyFont, Brushes.Black, xCliente, yPos);
                    e.Graphics.DrawString(vendedor, bodyFont, Brushes.Black, xVendedor, yPos);
                    e.Graphics.DrawString(total, bodyFont, Brushes.Black, xTotal, yPos);

                    yPos += lineHeight; 
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la vista de impresión: " + ex.Message);
            }

        }

        private async void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (dgvReporteVentas.Rows.Count == 0)
            {
                MessageBox.Show("Primero debe generar un reporte para poder enviar.", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string emailDestino = Interaction.InputBox(
                "Ingrese el correo electrónico del destinatario:",
                "Enviar Reporte por Correo",
                "");

            if (string.IsNullOrEmpty(emailDestino) || !emailDestino.Contains("@"))
            {
                MessageBox.Show("Operación cancelada o correo electrónico no válido.", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<ReporteVenta> reporte = (List<ReporteVenta>)dgvReporteVentas.DataSource;
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;

            btnEnviarCorreo.Enabled = false;
            btnGenerarReporte.Enabled = false;
            btnImprimir.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await _emailHelper.EnviarReporteVentasAsync(emailDestino, fechaInicio, fechaFin, reporte);

                MessageBox.Show($"¡Reporte enviado exitosamente a {emailDestino}!", "Envío Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al enviar el correo: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEnviarCorreo.Enabled = true;
                btnGenerarReporte.Enabled = true;
                btnImprimir.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            StyleHelper.AplicarEstiloFormulario(this);
        }
    }
}
