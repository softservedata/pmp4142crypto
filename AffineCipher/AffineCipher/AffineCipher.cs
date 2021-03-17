using System;
using System.Collections.Generic;
using System.Text;

namespace AffineCipher
{
    public class AffineCipher
    {
        private string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public int a { get; set; }
        public int b { get; set; }
        private int encryptFormula(int a, int b, int index)
        {
            return (alphabet.Length + (a * index + b)) % alphabet.Length;
        }
        private int findConverseA(int a)
        {
            var A  = -1;
            for(int i = 0; i<alphabet.Length; i++)
            {
                if((i * a+alphabet.Length)%alphabet.Length == 1)
                {
                    A = i;
                }
            }
            return A;
        }
        private int decryptFormula(int a, int b, int index)
        {
            try
            {
                var A = findConverseA(a);
                if (A < 0)
                {
                    throw new Exception("Error key. Cannot find reverse a!");
                    //Console.WriteLine("Error key");
                }
                return A * (index + (alphabet.Length - b)) % alphabet.Length;
            }
            catch (Exception)
            { 
                throw new Exception("Error key. Cannot find reverse a!");
            }
           
        }

        private string Algorithm(string text, bool encrypting)
        {
            var newText = "";
            for (var i = 0; i < text.Length; i++)
            {
                var index = -1;
                for (var j = 0; j < alphabet.Length; j++)
                {
                    if (text[i] == alphabet[j])
                    {
                        index = j;
                    }
                }

                if (index < 0)
                {
                    newText += text[i];
                }
                else
                {
                    int newTextIndex = encrypting ? encryptFormula(a, b, index) : decryptFormula(a, b, index);
                    newText += alphabet[newTextIndex];
                }
            }
            return newText;
        }
        public string Encrypt(string text) => Algorithm(text, true);
        public string Decrypt(string text) => Algorithm(text, false);
        
    }
}
