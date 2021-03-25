using System;
using System.Collections.Generic;
using System.Text;

namespace VigenerCode
{
    public class Logic
    {
        public string Encipher(string plainText, string key)
        {
            string cipherText = string.Empty;

            int j = 0;
            for(int i = 0; i < plainText.Length; i++)
            {
                cipherText += encipher(plainText[i], key[j]);
                if (j == key.Length - 1)
                    j = 0;
                else
                    j++;
            }
            return cipherText;
        }
        public string Decipher(string cipherText, string key)
        {
            string plainText = string.Empty;
            int j = 0;
            for (int i = 0; i < cipherText.Length; i++)
            {
                plainText += decipher(cipherText[i], key[j]);
                if (j == key.Length - 1)
                    j = 0;
                else
                    j++;
            }
            return plainText;
        }
        public char encipher(char ch, char key)
        {
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((ch+key-2*d)%26+d);
        }
        public char decipher(char ch, char key)
        {
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((ch - key + 26) % 26 + d);
        }

    }
}
