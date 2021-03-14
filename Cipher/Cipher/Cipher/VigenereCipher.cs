using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System.Collections.Generic;


namespace Cipher.Cipher
{
    public class VigenereCipher : ICipher
    {
        private readonly IList<char> arr_en = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly IList<char> arr_EN = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public string key { get; private set; }
        public VigenereCipher(string key)
        {
            this.key = key;
        }

        public string Encode(IStream textStream, IStream encodedStream)
        {
            string text = textStream.GetText();
            string encoded = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (arr_en.Contains(text[i]))
                {
                    encoded += arr_en[(arr_en.IndexOf(text[i]) + arr_en.IndexOf(key[i % key.Length])) % 26];
                }
                else if (arr_EN.Contains(text[i]))
                {
                    encoded += arr_EN[(arr_EN.IndexOf(text[i]) + arr_en.IndexOf(key[i % key.Length])) % 26];
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
                if (arr_en.Contains(code[i]))
                {
                    decoded += arr_en[(arr_en.IndexOf(code[i]) - arr_en.IndexOf(key[i % key.Length]) + 26) % 26];
                }
                else if (arr_EN.Contains(code[i]))
                {
                    decoded += arr_EN[(arr_EN.IndexOf(code[i]) - arr_en.IndexOf(key[i % key.Length]) + 26) % 26];
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
