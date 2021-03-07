using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;

namespace Cipher.Cipher
{
    public class FenceCipher : ICipher
    {
        private readonly char[] arr_en =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '.', ',', '-', '!', '?', ' '
        };
        private readonly int height;

        public FenceCipher(int height)
        {
            this.height = height;
        }
        public FenceCipher(IStream textStream)
        {
            this.height = (int)Math.Sqrt(textStream.GetText().Length);
        }

        public string Decode(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decoded = "";
            char[,] fence = new char[height, code.Length / height];

            for (int k = 0; k < fence.GetLength(0); k++)
            {
                for (int m = 0; m < fence.GetLength(1); m++)
                {
                    fence[k, m] = code[k * fence.GetLength(1) + m];
                }
            }

            int i = 0;
            int j = 0;
            bool moveDown = true;
            while (j < fence.GetLength(1))
            {
                if (moveDown)
                {
                    decoded += fence[i, j];
                    i += 1;
                    j += 1;
                    if (i == height - 1)
                    {
                        moveDown = false;
                    }
                }
                else
                {
                    decoded += fence[i, j];
                    i -= 1;
                    j += 1;
                    if (i == 0)
                    {
                        moveDown = true;
                    }
                }
            }
            decodedStream.SetText(decoded);
            return decoded;
        }

        public string Encode(IStream textStream, IStream encodedStream)
        {
            string text = textStream.GetText();
            string encoded = "";
            char[,] fence = new char[height, text.Length];
            Random random = new Random();
            int i = 0;
            int j = 0;
            bool moveDown = true;
            while (j < text.Length)
            {
                if (moveDown)
                {
                    fence[i, j] = text[j];
                    i += 1;
                    j += 1;
                    if (i == height - 1)
                    {
                        moveDown = false;
                    }
                }
                else
                {
                    fence[i, j] = text[j];
                    i -= 1;
                    j += 1;
                    if (i == 0)
                    {
                        moveDown = true;
                    }
                }
            }
            for (int k = 0; k < fence.GetLength(0); k++)
            {
                for (int m = 0; m < fence.GetLength(1); m++)
                {
                    if (fence[k, m] == '\0')
                    {
                        encoded += arr_en[random.Next() % arr_en.Length];
                        //Console.Write("_");
                    }
                    else
                    {
                        encoded += fence[k, m];
                        //Console.Write(fence[k, m]);
                    }
                }
                //Console.WriteLine();
            }
            encodedStream.SetText(encoded);
            return encoded;
        }
    }
}
