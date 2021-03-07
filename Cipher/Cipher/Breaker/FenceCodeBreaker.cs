using Cipher.Breaker.Interfaces;
using Cipher.Cipher;
using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher.Breaker
{
    public class FenceCodeBreaker : ICodeBreaker
    {
        public string Break(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decodedText = "";
            int height = 1;

            ConsoleKey key = ConsoleKey.UpArrow;
            while (key != ConsoleKey.Enter)
            {
                Console.WriteLine();
                Console.WriteLine("____________________________________________");
                Console.WriteLine("height = "+height+"\n"+"UpArrow - height+1\nDownArrow - height-1\nEnter - End");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.UpArrow)
                {
                    height += 1;
                }
                if (key == ConsoleKey.DownArrow)
                {
                    height -= 1;
                    if (height < 2)
                    {
                        height = 2;
                    }
                }
                Console.WriteLine("height = " + height + "_____________________");


                char[,] fence = new char[height, code.Length/height];
                for (int k = 0; k < fence.GetLength(0); k++)
                {
                    for (int m = 0; m < fence.GetLength(1); m++)
                    {
                        fence[k, m] = code[k * fence.GetLength(1) + m];
                    }
                }
                Console.WriteLine();

                decodedText = "";
                int i = 0;
                int j = 0;
                bool moveDown = true;
                while (j < fence.GetLength(1))
                {
                    if (moveDown)
                    {                   
                        decodedText += fence[i, j];
                        i += 1;
                        j += 1;
                        if (i == height - 1)
                        {
                            moveDown = false;
                        }
                    }
                    else
                    {                 
                        decodedText += fence[i, j];
                        i -= 1;
                        j += 1;
                        if (i == 0)
                        {
                            moveDown = true;
                        }
                    }
                }
                for(int l = 0; l < 30; l++)
                {
                    if(l== decodedText.Length)
                    {
                        Console.WriteLine();
                        break;
                    }
                    Console.Write(decodedText[l]);
                }
            }

            ICipher cipher = new FenceCipher(height);
            decodedText = cipher.Decode(codeStream, decodedStream);
            return decodedText;
        }
    }
}
