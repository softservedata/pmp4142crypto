using System;

namespace VigenerCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            Console.WriteLine();
            Console.WriteLine(logic.DecodeParallel(3));
            //Console.WriteLine("Encode : " + logic.Encipher("ATTACKATDAWN", "LEMON"));
            //Console.WriteLine("Encode : " + logic.Encipher("attackatdawn", "lemon"));
            //logic.ReadEncodeWrite("ab");
            //Console.WriteLine("Decode : " + logic.Decipher(logic.Encipher("ATTACKATDAWN", "LEMON"), "LEMON"));
            //Console.WriteLine("Decode : " + logic.Decipher(logic.Encipher("attackatdawn", "lemon"), "lemon"));
            Console.ReadLine();
        }
    }
}
