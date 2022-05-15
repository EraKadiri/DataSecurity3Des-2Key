using _3DES;
using System.Reflection;

namespace TripleDES
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deshironi te enkriptoni/dekriptoni file apo text? ");
            string input = Console.ReadLine();
            input = input.ToLower();
            Perserite:
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Shenoni vetem 'text' ose 'file'");
                input = Console.ReadLine();
            }
            Console.WriteLine("Deshironi te beni encrypt apo decrypt : ");
            string lexoje = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(lexoje))
            {
                Console.WriteLine("Shenoni encrypt ose decrypt!!");
                input = Console.ReadLine();
            }
            if(lexoje == "encrypt")
            {
                Encrypt(input);
            }
            else if(lexoje == "decrypt")
            {
                Decrypt(input);
            }
            else
            {
                goto Perserite;
            }
            
            Console.WriteLine("Doni te perserisni programin? (y/n): ");
            string continueInput = Console.ReadLine();
            while (continueInput.ToLower() == "y")
            {
                Console.WriteLine("Deshironi te enkriptoni/dekriptoni file apo text? ");
                input = Console.ReadLine();
                input = input.ToLower();
            Perserite2:
                while (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Shenoni vetem 'text' ose 'file'");
                    input = Console.ReadLine();
                }
                Console.WriteLine("Deshironi te beni encrypt apo decrypt : ");
                lexoje = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(lexoje))
                {
                    Console.WriteLine("Shenoni encrypt ose decrypt!!");
                    input = Console.ReadLine();
                }
                if (lexoje == "encrypt")
                {
                    Encrypt(input);
                }
                else if (lexoje == "decrypt")
                {
                    Decrypt(input);
                }
                else
                {
                    goto Perserite2;
                }
            }

        }

        public static void Encrypt(string input)
        {
            if (input == "text")
            {
                Console.WriteLine("Sheno tekstin qe deshiron te enkriptosh: ");
                string plainText = Console.ReadLine();

                string encryptedText = TripleDes.Encrypt(plainText);

                Console.WriteLine("Para enkriptimit = " + plainText + "\n");
                Console.WriteLine("Pas enkriptimit = " +
                   encryptedText + "\n");

            }
            else if (input == "file")
            {
                Environment.CurrentDirectory = "C:/Users/erdis/Desktop/GitHub/Data_Security_3DES/3DES/3DES/tektstet per enkriptim";
                Console.WriteLine("Sheno emrin e file qe deshironi te enkriptoni: ");
                String path = Console.ReadLine();

                string readText = File.ReadAllText(path);

                string encryptedText = TripleDes.Encrypt(readText);

                Console.WriteLine("Para enkriptimit = " + readText + "\n");
                Console.WriteLine("Pas enkriptimit = " +
                   encryptedText + "\n");

            }
        }
        
        public static void Decrypt(string input)
        {
            if (input == "text")
            {
                Console.WriteLine("Sheno tekstin qe deshiron te dekriptosh: ");
                string encryptedText = Console.ReadLine();

                string decryptedText = TripleDes.Decrypt(encryptedText);

                Console.WriteLine("Teksti i enkriptuar = " +
                   encryptedText + "\n");
                Console.WriteLine("Tekskti i dekriptuar = " +
                   decryptedText + "\n");

            }
            else if (input == "file")
            {
                Environment.CurrentDirectory = "C:/Users/erdis/Desktop/GitHub/Data_Security_3DES/3DES/3DES/tektstet per enkriptim";
                Console.WriteLine("Sheno emrin e file te enkriptuar: ");
                String path = Console.ReadLine();

                string encryptedText = File.ReadAllText(path);

                string decryptedText = TripleDes.Decrypt(encryptedText);

                Console.WriteLine("Teksti i enkriptuar = " +
                   encryptedText + "\n");
                Console.WriteLine("Teksti i dekriptuar = " +
                   decryptedText + "\n");

            }
        }
    }

}
