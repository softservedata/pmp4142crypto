using System;

namespace CardanoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0000 - 0 
            // 0001 - 1
            // 0010 - 2
            // 0100 - 4
            // 1000 - 8

            //Example 1 (2,5,0,8)
            //0010
            //0101
            //0000
            //1000

            //Example 2 (6,0,0,8)
            //0110
            //0000
            //0000
            //1000

            Logic logic = new Logic();

            //Console.WriteLine("Message : " + "abcdefg123456789");
            //Console.WriteLine("Encipher message : ");
            //var en_mes = logic.Encipher("abcdefg123456789", new int[] { 6, 0, 0, 8 });
            //Console.WriteLine(en_mes);
            //Console.WriteLine("Decipher message : ");
            //Console.WriteLine(logic.Decipher(en_mes, new int[] { 6, 0, 0, 8 }));
            //Console.WriteLine("Code hack : ");
            //var m = new char[4, 4] { { 'd', 'a', 'b', 'g' }, { '3', 'P', 'f', 'e' },{ '4', 'u', '6', 'f' },{ 'c', '1', '2', '5' } };
            //var k = logic.CodeHucker("abcdefg123456789", m);
            //Console.WriteLine(k[0] + " " + k[1] + " " + k[2] + " " + k[3]);


            Console.WriteLine("Message : " + "abcdefg123456789");
            Console.WriteLine("Encipher message : ");
            var en_mes = logic.Encipher("abcdefg123456789", new int[] { 2, 5, 0, 8 });
            Console.WriteLine(en_mes);
            Console.WriteLine("Decipher message : ");
            Console.WriteLine(logic.Decipher(en_mes, new int[] { 2, 5, 0, 8 }));

            //Console.WriteLine("Message : " + "перестановки");
            //Console.WriteLine("Encipher message : ");
            //var en_mes = logic.Encipher("перестановки", new int[] { 0, 5, 0, 8 });
            //Console.WriteLine(en_mes);
            //Console.WriteLine("Decipher message : ");
            //Console.WriteLine(logic.Decipher(en_mes, new int[] { 0, 5, 0, 8 }));
        }

    }
}
