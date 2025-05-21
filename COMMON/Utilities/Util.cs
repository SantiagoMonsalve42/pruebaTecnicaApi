using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace COMMON.Utilities
{
    public static class Util
    {
        public static T Deserialize<T>(this string jsonString) where T : class
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        public static string Serialize<T>(this T Obj) where T : class
        {
            return JsonConvert.SerializeObject(Obj);
        }
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
