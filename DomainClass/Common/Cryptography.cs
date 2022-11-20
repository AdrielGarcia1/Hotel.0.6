using System.Security.Cryptography;
using System.Text;

namespace DomainClass.Common
{
    public static class Cryptography
    {
        public static string Encriptar(this string value)
        {
            SHA256 sHA256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = sHA256.ComputeHash(encoding.GetBytes(value));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                sb.AppendFormat("{0:x2}", bytes[i]);
            return sb.ToString();
        }
    }
}
//public static string Encriptacion(this string value)
//{
//    SHA256 sHA256 = SHA256.Create();
//    ASCIIEncoding encoding = new ASCIIEncoding();
//    byte[] bytes = sHA256.ComputeHash(encoding.GetBytes(value));
//    StringBuilder sb = new StringBuilder();
//    for(int i = 0; i < bytes.Length;i++)
//    {
//        sb.AppendFormat("{0:X2}", bytes[i]);
//        return sb.ToString();
//    }
//}