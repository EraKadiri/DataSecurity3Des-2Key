using System.Security.Cryptography;
using System.Text;
using System;

namespace _3DES
{
    public class TripleDes
    {
        // Celesi 16 bytes(2 celesa 8 byte) i inicializuar si string
        private const string securityKey = "DataSecurity3DES";
        // Vektori inicializues 8 bytes i inicizlizuar si string
        private const string iv = "11112222";
 

        public static string Encrypt(string TextToEncrypt)
        {
            // Vektori inicializues kthehet ne form te bajtave
            byte[] IV = Encoding.Default.GetBytes(iv);
            string encryptedText = "";
            // Teksti per enkriptim kthehet ne bajta
            byte[] MyEncryptedArray = UTF8Encoding.UTF8.GetBytes(TextToEncrypt);
            MD5CryptoServiceProvider MyMD5CryptoService = new MD5CryptoServiceProvider();

            // Kryhet hashimi dhe kthimi ne bajta i celsit te enkriptimit
            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash
              (UTF8Encoding.UTF8.GetBytes(securityKey));


            MyMD5CryptoService.Clear();


            var MyTripleDESCryptoService = new
               TripleDESCryptoServiceProvider();

            //Inicializimi i celsit,modes,IV dhe modes se padding
            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.CBC;

            MyTripleDESCryptoService.IV = IV;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCryptoTransform = MyTripleDESCryptoService
               .CreateEncryptor();
            //Ruajtja e bajtave te enkriptuar
            byte[] MyresultArray = MyCryptoTransform
               .TransformFinalBlock(MyEncryptedArray, 0,
               MyEncryptedArray.Length);

            MyTripleDESCryptoService.Clear();
            // Kthimi i bajtave te enkriptuar ne String
            return Convert.ToBase64String(MyresultArray, 0,
               MyresultArray.Length); ;
        }
