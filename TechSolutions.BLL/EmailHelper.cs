using System.Net.Mail;
using System.Net;
using System.Text; // Para el CSV
using System.Collections.Generic; // Para List<>
using System.Threading.Tasks; // Para async
using System.Configuration; // Para App.config
using TechSolutions.Entidades; // Para ReporteHistorialCliente
using System.IO; // Para MemoryStream

namespace TechSolutions.BLL
{
    public class EmailHelper
    {
        private string _emailEmisor;
        private string _passwordEmisor;

        public EmailHelper()
        {
            // 1. Lee las credenciales desde el App.config
            _emailEmisor = ConfigurationManager.AppSettings["EmailEmisor"];
            _passwordEmisor = ConfigurationManager.AppSettings["EmailPassword"];
        }

        /// <summary>
        /// Tarea principal: Genera un CSV y envía el correo de forma asíncrona.
        /// </summary>
        public async Task EnviarHistorialClienteAsync(string emailDestinatario, string nombreCliente, List<ReporteHistorialCliente> historial)
        {
            // 1. Generar el archivo CSV en memoria
            byte[] archivoCsvBytes = GenerarCsv(historial);

            // 2. Preparar el correo
            string asunto = $"Historial de Compras - {nombreCliente}";
            string cuerpo = $"Hola {nombreCliente},\n\nAdjuntamos tu historial de compras solicitado.\n\nGracias,\nTechSolutions";

            // 3. Enviar (esto se ejecuta en un hilo secundario)
            await EnviarCorreoAsync(emailDestinatario, asunto, cuerpo, archivoCsvBytes, "Historial.csv");
        }

        /// <summary>
        /// (Privado) Genera un archivo CSV a partir de la lista del reporte.
        /// </summary>
        private byte[] GenerarCsv(List<ReporteHistorialCliente> historial)
        {
            StringBuilder sb = new StringBuilder();

            // Cabeceras
            sb.AppendLine("Fecha,Producto,Cantidad,Precio Unitario,Subtotal");

            // Filas
            foreach (var item in historial)
            {
                sb.AppendLine($"{item.FechaVenta},{item.Producto},{item.Cantidad},{item.PrecioUnitario},{item.Subtotal}");
            }

            // Convertir el string a bytes
            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        /// <summary>
        /// (Privado) Se conecta a Gmail (SMTP) y envía el correo.
        /// </summary>
        private async Task EnviarCorreoAsync(string destinatario, string asunto, string cuerpo, byte[] adjunto, string nombreAdjunto)
        {
            // 1. Configurar el cliente SMTP para Gmail
            SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true, // Gmail requiere SSL
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_emailEmisor, _passwordEmisor)
            };

            // 2. Crear el mensaje
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_emailEmisor, "TechSolutions Reportes"),
                Subject = asunto,
                Body = cuerpo,
                IsBodyHtml = false,
            };
            mailMessage.To.Add(destinatario);

            // 3. Adjuntar el archivo CSV (creado desde la memoria)
            mailMessage.Attachments.Add(new Attachment(new MemoryStream(adjunto), nombreAdjunto, "text/csv"));

            // 4. Enviar el correo de forma asíncrona
            await clienteSmtp.SendMailAsync(mailMessage);
        }

        // --- MÉTODO NUEVO 1: Para Reporte de Ventas ---
        /// <summary>
        /// Tarea principal: Genera un CSV y envía el Reporte de Ventas.
        /// </summary>
        public async Task EnviarReporteVentasAsync(string emailDestinatario, DateTime fechaInicio, DateTime fechaFin, List<ReporteVenta> reporte)
        {
            // 1. Generar el archivo CSV en memoria
            byte[] archivoCsvBytes = GenerarCsv(reporte); // Llama al nuevo método de abajo

            // 2. Preparar el correo
            string asunto = $"Reporte de Ventas ({fechaInicio:d} - {fechaFin:d})";
            string cuerpo = $"Hola,\n\nAdjuntamos el reporte de ventas solicitado desde {fechaInicio:d} hasta {fechaFin:d}.\n\nSaludos,\nTechSolutions";

            // 3. Enviar
            await EnviarCorreoAsync(emailDestinatario, asunto, cuerpo, archivoCsvBytes, "ReporteVentas.csv");
        }

        // --- MÉTODO NUEVO 2: Sobrecarga para generar el CSV ---
        /// <summary>
        /// (Privado) Genera un archivo CSV a partir de la lista del Reporte de Ventas.
        /// </summary>
        private byte[] GenerarCsv(List<ReporteVenta> reporte)
        {
            StringBuilder sb = new StringBuilder();

            // Cabeceras (deben coincidir con tu reporte)
            sb.AppendLine("ID Venta,Cliente,Vendedor,Fecha Venta,Total,Estado");

            // Filas
            foreach (var item in reporte)
            {
                // Limpiamos comas del nombre del cliente (ej. "Perez, Juan")
                string clienteLimpio = item.Cliente.Replace(",", "");
                sb.AppendLine($"{item.IdVenta},{clienteLimpio},{item.Vendedor},{item.FechaVenta},{item.Total},{item.Estado}");
            }

            // Convertir el string a bytes
            return Encoding.UTF8.GetBytes(sb.ToString());
        }
    }
}