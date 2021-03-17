using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCipher
{
    public class CaesarCipher
    {
        private string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public string Algorithm(string text, int key)
        {
            var newText = "";
            for(var i = 0; i<text.Length; i++)
            {
                var index = -1;
                for(var j = 0; j<alphabet.Length; j++)
                {
                    if(text[i] == alphabet[j])
                    {
                        index = j;
                    }
                }

                if(index < 0)
                {
                    newText += text[i];
                }
                else
                {
                    var newTextIndex = (alphabet.Length + index + key) % alphabet.Length;
                    newText += alphabet[newTextIndex];
                }
            }
            return newText;
        }

        public string Encrypt(string text, int key)
        {
            return Algorithm(text, key);
        }
        public string Decrypt(string text, int key)
        {
            return Algorithm(text, -key);
        }
    }
}
