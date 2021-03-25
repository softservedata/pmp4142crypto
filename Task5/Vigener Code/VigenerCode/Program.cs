using System;

namespace VigenerCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            Console.WriteLine("Encode : " + logic.Encipher("ATTACKATDAWN", "LEMON"));
            Console.WriteLine("Encode : " + logic.Encipher("attackatdawn", "lemon"));
            Console.WriteLine("Decode : " + logic.Decipher(logic.Encipher("ATTACKATDAWN", "LEMON"), "LEMON"));
            Console.WriteLine("Decode : " + logic.Decipher(logic.Encipher("attackatdawn", "lemon"), "lemon"));
        }
    }
}
