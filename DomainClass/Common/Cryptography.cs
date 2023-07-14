using System.Security.Cryptography;
using System.Text;
namespace DomainClass.Common
{
    public static class Cryptography
    {
        public static string Encriptar(this string value)
        {
            SHA256 sHA256 = SHA256.Create(); // Crear instancia de SHA256 para realizar el hash
            ASCIIEncoding encoding = new ASCIIEncoding(); // Codificación ASCII para convertir la cadena en bytes
            byte[] bytes = sHA256.ComputeHash(encoding.GetBytes(value)); // Calcular el hash de los bytes de la cadena
            StringBuilder sb = new StringBuilder(); // Utilizar StringBuilder para construir la representación hexadecimal del hash
            for (int i = 0; i < bytes.Length; i++)
                sb.AppendFormat("{0:x2}", bytes[i]); // Convertir cada byte en una representación hexadecimal y agregarlo al StringBuilder
            return sb.ToString(); // Devolver la representación hexadecimal del hash
        }
    }
}