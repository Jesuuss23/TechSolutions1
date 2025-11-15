using System.Net.Mail;
using System.Net;
using System.Text; 
using System.Collections.Generic; 
using System.Threading.Tasks; 
using System.Configuration; 
using TechSolutions.Entidades; 
using System.IO; 

namespace TechSolutions.BLL
{
    public class EmailHelper
    {
        private string _emailEmisor;
        private string _passwordEmisor;

        public EmailHelper()
        {
            _emailEmisor = ConfigurationManager.AppSettings["EmailEmisor"];
            _passwordEmisor = ConfigurationManager.AppSettings["EmailPassword"];
        }

        public async Task EnviarHistorialClienteAsync(string emailDestinatario, string nombreCliente, List<ReporteHistorialCliente> historial)
        {
            byte[] archivoCsvBytes = GenerarCsv(historial);

            string asunto = $"Historial de Compras - {nombreCliente}";
            string cuerpo = $"Hola {nombreCliente},\n\nAdjuntamos tu historial de compras solicitado.\n\nGracias,\nTechSolutions";

            await EnviarCorreoAsync(emailDestinatario, asunto, cuerpo, archivoCsvBytes, "Historial.csv");
        }

        private byte[] GenerarCsv(List<ReporteHistorialCliente> historial)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Fecha,Producto,Cantidad,Precio Unitario,Subtotal");

            foreach (var item in historial)
            {
                sb.AppendLine($"{item.FechaVenta},{item.Producto},{item.Cantidad},{item.PrecioUnitario},{item.Subtotal}");
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        private async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo, byte[] adjunto, string nombreAdjunto)
        {
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true, 
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailEmisor, _passwordEmisor)
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_emailEmisor, "TechSolutions Reportes"),
                Subject = asunto,
                Body = cuerpo,
                IsBodyHtml = false,
            };
            mailMessage.To.Add(destinatario);

            mailMessage.Attachments.Add(new Attachment(new MemoryStream(adjunto), nombreAdjunto, "text/csv"));

            await clienteSmtp.SendMailAsync(mailMessage);
        }

        public async Task EnviarReporteVentasAsync(string emailDestinatario, DateTime fechaInicio, DateTime fechaFin, List<ReporteVenta> reporte)
        {
            byte[] archivoCsvBytes = GenerarCsv(reporte); 

            string asunto = $"Reporte de Ventas ({fechaInicio:d} - {fechaFin:d})";
            string cuerpo = $"Hola,\n\nAdjuntamos el reporte de ventas solicitado desde {fechaInicio:d} hasta {fechaFin:d}.\n\nSaludos,\nTechSolutions";

            await EnviarCorreoAsync(emailDestinatario, asunto, cuerpo, archivoCsvBytes, "ReporteVentas.csv");
        }

        private byte[] GenerarCsv(List<ReporteVenta> reporte)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ID Venta,Cliente,Vendedor,Fecha Venta,Total,Estado");

            foreach (var item in reporte)
            {
                string clienteLimpio = item.Cliente.Replace(",", "");
                sb.AppendLine($"{item.IdVenta},{clienteLimpio},{item.Vendedor},{item.FechaVenta},{item.Total},{item.Estado}");
            }

            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}