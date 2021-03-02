using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;
using System.Linq;

namespace Cipher.Cipher
{
    public class CeaserCipher : ICipher
    {
        private readonly char[] arr_en = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly char[] arr_EN = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly char[] cipherArr_en;
        private readonly char[] cipherArr_EN;
        public int N { get; private set; }
        public CeaserCipher() : this(0) { }
        public CeaserCipher(int n)
        {
            N = Math.Abs(n) <= 26 ? n : n % 26;
            cipherArr_en = N >= 0 ? arr_en.Skip(N).Concat(arr_en.Take(N)).ToArray() : arr_en.Skip(26 + N).Concat(arr_en.Take(26 + N)).ToArray();
            cipherArr_EN = N >= 0 ? arr_EN.Skip(N).Concat(arr_EN.Take(N)).ToArray() : arr_EN.Skip(26 + N).Concat(arr_EN.Take(26 + N)).ToArray();

            Console.WriteLine(N);
            Console.WriteLine(arr_en);
            Console.WriteLine(cipherArr_en);
            Console.WriteLine(arr_EN);
            Console.WriteLine(cipherArr_EN);
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
    }
}
