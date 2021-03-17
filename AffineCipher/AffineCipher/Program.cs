using System;

namespace AffineCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            AffineCipher affineCipher = new AffineCipher();
            affineCipher.a = 3;
            affineCipher.b = 4;

            Console.Write("Enter text for encryption: ");
            string encrText = Console.ReadLine();
            Console.Write("Encrypted text: ");
            Console.WriteLine(affineCipher.Encrypt(encrText));

            Console.Write("Enter text for decryption: ");
            string decrText = Console.ReadLine();
            Console.Write("Decrypted text: ");
            Console.WriteLine(affineCipher.Decrypt(decrText));
        }
    }
}
