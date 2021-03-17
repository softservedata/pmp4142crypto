using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            CaesarCipher caesarCipher = new CaesarCipher();
            //Console.WriteLine(caesarCipher.Encrypt("hello world", 10));
            //Console.WriteLine(caesarCipher.Decrypt("rovvy gybvn", 10));


            Console.Write("Enter message: ");
            var text = Console.ReadLine();
            Console.Write("Enter key: ");
            int key = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Encrypting message: {0}", caesarCipher.Encrypt(text, key));

            Console.Write("Enter message: ");
            var decriptText = Console.ReadLine();

            Console.WriteLine("Decrypting message: {0}", caesarCipher.Decrypt(decriptText, key));


            //var readPath = @"D:\Progi\Криптологія\CaesarCipher\CaesarCipher\ReadFile.txt";
            //var writePath = @"D:\Progi\Криптологія\CaesarCipher\CaesarCipher\WriteFile.txt";

            //FileManager fileManager = new FileManager();
            //var text = fileManager.ReadFromFile(readPath);

            //var key = 3;

            //var encryptText = caesarCipher.Encrypt(text, key);
            //var decryptText = caesarCipher.Decrypt(text, key);

            //fileManager.WriteToFile(writePath, encryptText);
            //fileManager.WriteToFile(writePath, decryptText);
        }
    }
}
