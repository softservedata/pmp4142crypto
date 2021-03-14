using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;

namespace Cipher.Cipher
{
    // 0 = 0000
    // 1 = 0001
    // 2 = 0010
    // 4 = 0100
    // 8 = 1000

    //4X4
    public class CardanCipher : ICipher
    {
        private readonly int[] holePosition = new int[4];
        private readonly char[] arr_en =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '.', ',', '-', '!', '?', ' '
        };

        public CardanCipher(string key)
        {
            for (int i = 0; i < holePosition.Length; i++)
            {
                holePosition[i] = GetHolePosition(key[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GetHolePosition(key[i]) == j)
                    {
                        Console.Write("1 ");
                    }
                    else
                    {
                        Console.Write("0 ");
                    }
                }
                Console.WriteLine();
            }
        }

        public string Decode(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decoded = "";
            char[,] charMatr = new char[4, 4];

            int temp = 0;
            while (code.Length > temp)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (code.Length > temp)
                        {
                            charMatr[i, j] = code[temp];
                            temp += 1;
                        }
                        else
                        {
                            charMatr[i, j] = '\0';
                        }

                    }

                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (holePosition[j] != -1)
                        {
                            decoded += charMatr[j, holePosition[j]];
                        }
                    }
                    charMatr = Rotation(charMatr);
                }

            }

            decodedStream.SetText(decoded);
            return decoded;
        }

        public string Encode(IStream textStream, IStream encodedStream)
        {
            string text = textStream.GetText();
            string encoded = "";
            char[,] charMatr = new char[4, 4];
            Random random = new Random();

            int temp = 0;
            while (text.Length > temp)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (holePosition[j] != -1 && text.Length > temp)
                        {
                            charMatr[j, holePosition[j]] = text[temp];
                            temp += 1;
                        }
                    }
                    charMatr = Rotation(charMatr);
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (charMatr[i, j] == '\0')
                        {
                            encoded += arr_en[random.Next() % arr_en.Length];
                        }
                        else
                        {
                            encoded += charMatr[i, j];
                        }
                    }
                }

                charMatr = new char[4, 4];
            }


            encodedStream.SetText(encoded);
            return encoded;
        }

        //right rotation
        private char[,] Rotation(char[,] matr)
        {
            var result = new char[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = matr[4 - j - 1, i];
                }
            }
            return result;
        }

        private int GetHolePosition(char keyPart) => keyPart switch
        {
            '1' => 3,
            '2' => 2,
            '4' => 1,
            '8' => 0,
            _ => -1
        };
    }
}
