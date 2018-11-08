using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptoTools
{
    class Common
    {
        // Visual Studio 里面快捷键 CTRL+F5 运行
        static void Main2()
        {
            Console.WriteLine(AesEncrypt("100A31EA42E09EB6C8A3F8C55EE2AFF5316181107",
                "12345678876543211234567887654abc"));

            Console.WriteLine(AesDecrypt("QLY0LiMTcOoCE383CZDcm/Tu1zKdJ8FTYNtbBicS9nMc4QkhrfdDYP5Vee4iI9ki",
                "12345678876543211234567887654abc"));
        }

        public static string ToBase64Str(byte[] inArray) {
            return Convert.ToBase64String(inArray, 0, inArray.Length);
        }

        public static string AesEncrypt(string str, string key) {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            RijndaelManaged rm = new RijndaelManaged {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string AesDecrypt(string str, string key) {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(str);

            RijndaelManaged rm = new RijndaelManaged {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }

    }
}
