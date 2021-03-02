using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cipher.Cipher
{
    // alpha = [ 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23 , 25 ]
    // beta  = [ 0 - 25]
    class AffineCipher : ICipher
    {
        private readonly char[] arr_en = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly char[] arr_EN = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly char[] cipherArr_en;
        private readonly char[] cipherArr_EN;
        public int alpha { get; private set; }
        public int beta { get; private set; }
        public AffineCipher() : this(1, 0) { }
        public AffineCipher(int alpha, int beta)
        {
            this.alpha = alpha;
            this.beta = beta;
            this.cipherArr_en = (char[])(arr_en.Clone());
            this.cipherArr_EN = (char[])(arr_EN.Clone());
            for (int i = 0; i < arr_en.Length; i++)
            {
                cipherArr_en[(i * alpha + beta) % arr_en.Length] = arr_en[i];
                cipherArr_EN[(i * alpha + beta) % arr_EN.Length] = arr_EN[i];
            }

            Console.WriteLine(alpha + " " + beta);
            Console.WriteLine(arr_en);
            Console.WriteLine(cipherArr_en);
            Console.WriteLine(arr_EN);
            Console.WriteLine(cipherArr_EN);
        }
        public string Decode(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decoded = "";
            for (int i = 0; i < code.Length; i++)
            {
                if (arr_en.Contains(code[i]) || arr_EN.Contains(code[i]))
                {
                    decoded += cipherArr_en.Contains(code[i]) ? arr_en[cipherArr_en.ToList().IndexOf(code[i])] : arr_EN[cipherArr_EN.ToList().IndexOf(code[i])];
                }
                else
                {
                    decoded += code[i];
                }
            }
            decodedStream.SetText(decoded);
            return decoded;
        }

        public string Encode(IStream textStream, IStream encodedStream)
        {
            string text = textStream.GetText();
            string encoded = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (arr_en.Contains(text[i]) || arr_EN.Contains(text[i]))
                {
                    encoded += arr_en.Contains(text[i]) ? cipherArr_en[arr_en.ToList().IndexOf(text[i])] : cipherArr_EN[arr_EN.ToList().IndexOf(text[i])];
                }
                else
                {
                    encoded += text[i];
                }
            }
            encodedStream.SetText(encoded);
            return encoded;
        }
    }
}
