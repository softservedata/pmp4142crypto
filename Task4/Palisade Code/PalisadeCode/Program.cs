using System;

namespace PalisadeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            //
            Console.WriteLine(logic.Encipher("Cryptography", 3));
            Console.WriteLine(logic.Decipher(logic.Encipher("Cryptography", 3),3));
            Console.WriteLine();
            Console.WriteLine(logic.Decode(logic.Encipher("Cryptography", 3)).Item2);
            Console.WriteLine(logic.Decode(logic.Encipher("Cryptography", 3)).Item1);
        }
    }
}
