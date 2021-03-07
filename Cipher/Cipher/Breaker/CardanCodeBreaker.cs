using Cipher.Breaker.Interfaces;
using Cipher.Cipher;
using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher.Breaker
{
    public class CardanCodeBreaker : ICodeBreaker
    {
        public string Break(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decodedText = "";
            string data = "THE OLD MAN\nAND\nTHE SEA";
            int[] holePosition = new int[4];
            char[,] charMatr = new char[4, 4];
            string key = "";

            int temp = 0;
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

            temp = 0;
            bool zeroRow;
            for (int i = 0; i < 4; i++)
            {
                zeroRow = true;
                for (int j = 0; j < 4; j++)
                {
                    if(charMatr[i,j] == data[temp])
                    {
                        key += GetHolePositionKey(j);
                        temp += 1;
                        zeroRow = false;
                        break;
                    }
                }
                if (zeroRow)
                {
                    key += GetHolePositionKey(-1);
                }
            }

            Console.WriteLine("Finded key : " + key);

            ICipher cipher = new CardanCipher(key);
            decodedText=cipher.Decode(codeStream, decodedStream);
            return decodedText;
        }
        private char GetHolePositionKey(int position) => position switch
        {
            3 => '1',
            2 => '2',
            1 => '4',
            0 => '8',
            _ => '0'
        };
    }
}
