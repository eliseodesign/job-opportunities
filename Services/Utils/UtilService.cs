using System.Security.Cryptography;
using System.Text;

namespace job_opportunities_asp_react.Services.Utils
{
    public static class UtilService
    {
        public static string ConvertSHA256(string text)
        {
            string hash = string.Empty;
            using (SHA256 sha256 = SHA256.Create())
            {
                //obtener el hash recibido
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));

                // convertir array de bytes en cadena de texto
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }
            return hash;
        }

        public static string GenerateToken() => Guid.NewGuid().ToString("N");

    }
}
