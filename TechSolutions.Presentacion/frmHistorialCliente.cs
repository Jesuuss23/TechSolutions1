// --- Archivo: frmHistorialCliente.cs ---
// --- Proyecto: TechSolutions.Presentacion ---

// --- AÑADE ESTOS USINGS ---
using TechSolutions.BLL;
using TechSolutions.Entidades;
using System.Collections.Generic;
// ----------------------------
using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Printing;
using System;
using System.Windows.Forms;

namespace TechSolutions.Presentacion
{
    public partial class frmHistorialCliente : Form
    {
        private readonly ReporteBLL _reporteBLL = new ReporteBLL();
        private readonly int _idCliente;
        private readonly string _nombreCliente;
        private readonly EmailHelper _emailHelper = new EmailHelper();

        public frmHistorialCliente(int idCliente, string nombreCliente)
        {
            InitializeComponent();
            _idCliente = idCliente;
            _nombreCliente = nombreCliente;

            this.Text = $"Historial de: {_nombreCliente}";
            lblNombreCliente.Text = $"Historial de: {_nombreCliente}";
        }


        private void btnBuscarHistorial_Click(object sender, EventArgs e)
        {
        }

        private void btnBuscarHistorial_Click_1(object sender, EventArgs e)
        {
            try
            {

                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;


                List<ReporteHistorialCliente> listaHistorial = _reporteBLL.ObtenerHistorialCliente(_idCliente, fechaInicio, fechaFin);

                dgvHistorial.DataSource = null;
                dgvHistorial.DataSource = listaHistorial;


                if (listaHistorial.Count > 0)
                {
                    dgvHistorial.Columns["FechaVenta"].HeaderText = "Fecha";
                    dgvHistorial.Columns["PrecioUnitario"].HeaderText = "Precio Unit.";
                    dgvHistorial.Columns["Subtotal"].DefaultCellStyle.Format = "c";
                    dgvHistorial.Columns["PrecioUnitario"].DefaultCellStyle.Format = "c";
                }

                if (listaHistorial.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron compras para este cliente en el rango de fechas seleccionado.",
                        "Sin Resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inesperado al generar el historial: " + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void btnImprimirHistorial_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Primero debe buscar un historial para poder imprimir.",
                    "No hay datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }

            vistaPreviaHistorial.ShowDialog();
        }

        private void docImprimirHistorial_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                Font clientFont = new Font("Arial", 12, FontStyle.Italic);
                Font headerFont = new Font("Arial", 10, FontStyle.Bold);
                Font bodyFont = new Font("Arial", 10);

                float leftMargin = e.MarginBounds.Left;
                float topMargin = e.MarginBounds.Top;
                float yPos = topMargin;
                float lineHeight = bodyFont.GetHeight(e.Graphics) + 5;

                e.Graphics.DrawString(
                    "Historial de Compras - TechSolutions",
                    titleFont,
                    Brushes.Black,
                    leftMargin,
                    yPos);
                yPos += titleFont.GetHeight(e.Graphics);

                e.Graphics.DrawString(
                    $"Cliente: {_nombreCliente}",
                    clientFont,
                    Brushes.Gray,
                    leftMargin,
                    yPos);
                yPos += clientFont.GetHeight(e.Graphics) * 2; 

                float xFecha = leftMargin;
                float xProducto = leftMargin + 150;
                float xCantidad = leftMargin + 400;
                float xPrecio = leftMargin + 480;
                float xSubtotal = leftMargin + 580; 

                e.Graphics.DrawString("Fecha", headerFont, Brushes.Black, xFecha, yPos);
                e.Graphics.DrawString("Producto", headerFont, Brushes.Black, xProducto, yPos);
                e.Graphics.DrawString("Cant.", headerFont, Brushes.Black, xCantidad, yPos);
                e.Graphics.DrawString("Precio Unit.", headerFont, Brushes.Black, xPrecio, yPos);
                e.Graphics.DrawString("Subtotal", headerFont, Brushes.Black, xSubtotal, yPos);
                yPos += lineHeight * 2;

                foreach (DataGridViewRow row in dgvHistorial.Rows)
                {
                    string fecha = Convert.ToDateTime(row.Cells["FechaVenta"].Value).ToString("g");
                    string producto = row.Cells["Producto"].Value.ToString();
                    string cantidad = row.Cells["Cantidad"].Value.ToString();
                    string precio = Convert.ToDecimal(row.Cells["PrecioUnitario"].Value).ToString("C");
                    string subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value).ToString("C");

                    e.Graphics.DrawString(fecha, bodyFont, Brushes.Black, xFecha, yPos);
                    e.Graphics.DrawString(producto, bodyFont, Brushes.Black, xProducto, yPos);
                    e.Graphics.DrawString(cantidad, bodyFont, Brushes.Black, xCantidad, yPos);
                    e.Graphics.DrawString(precio, bodyFont, Brushes.Black, xPrecio, yPos);
                    e.Graphics.DrawString(subtotal, bodyFont, Brushes.Black, xSubtotal, yPos);

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
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Primero debe buscar un historial para poder enviar.",
                    "No hay datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string emailDestino = Interaction.InputBox(
                "Ingrese el correo electrónico del destinatario:",
                "Enviar Historial por Correo",
                "");

            if (string.IsNullOrEmpty(emailDestino) || !emailDestino.Contains("@"))
            {
                MessageBox.Show(
                    "Operación cancelada o correo electrónico no válido.",
                    "Inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            List<ReporteHistorialCliente> historial = (List<ReporteHistorialCliente>)dgvHistorial.DataSource;

            btnEnviarCorreo.Enabled = false;
            btnBuscarHistorial.Enabled = false;
            btnImprimirHistorial.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                await _emailHelper.EnviarHistorialClienteAsync(emailDestino, _nombreCliente, historial);

                MessageBox.Show(
                    $"¡Historial enviado exitosamente a {emailDestino}!",
                    "Envío Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inesperado al enviar el correo: " + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnEnviarCorreo.Enabled = true;
                btnBuscarHistorial.Enabled = true;
                btnImprimirHistorial.Enabled = true;
                this.Cursor = Cursors.Default;
            }

        }

        private void frmHistorialCliente_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            StyleHelper.AplicarEstiloDataGridView(dgvHistorial);
        }
    }
}