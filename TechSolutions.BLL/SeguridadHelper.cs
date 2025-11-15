// --- Este archivo va en TechSolutions.BLL ---

using System.Security.Cryptography;
using System.Text;

namespace TechSolutions.BLL
{
    public static class SeguridadHelper
    {
        public static byte[] GenerarHashSHA512(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return new byte[0];
            }

            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytesEntrada = Encoding.UTF8.GetBytes(texto);

                byte[] bytesHash = sha512.ComputeHash(bytesEntrada);

                return bytesHash;
            }
        }
    }
}