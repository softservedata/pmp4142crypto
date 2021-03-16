using NHunspell;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalisadeCode
{
    public class Logic
    {
        public string Encipher(string plainText, int key)
        {
            string cipherText = string.Empty;
            char[,] matr = new char[key, plainText.Length];
            int i = 0;
            int j = 0;
            bool move_down = true;

            while (j < plainText.Length)
            {
                if (move_down)
                {
                    matr[i, j] = plainText[j];
                    i++; j++;
                    if (i == key - 1)
                        move_down = false;
                }
                else
                {
                    matr[i, j] = plainText[j];
                    i--; j++;
                    if (i == 0)
                        move_down = true;
                }
            }

            for (int k = key-1; k>=0; k--)
            {
                for (int m = 0; m < plainText.Length; m++)
                {
                    if (matr[k, m] != '\0')
                     cipherText += matr[k, m];
                }
            }

            return cipherText;
        }
        public string Decipher(string cipherText,int key)
        {
            string plainText = string.Empty;
            char[,] matr = new char[key, cipherText.Length];
            int i = 0;
            int j = 0;
            bool move_down = true;

            while (j < cipherText.Length)
            {
                if (move_down)
                {
                    matr[i, j] = '1';
                    i++; j++;
                    if (i == key - 1)
                        move_down = false;
                }
                else
                {
                    matr[i, j] = '1';
                    i--; j++;
                    if (i == 0)
                        move_down = true;
                }
            }

            int temp = 0;
            for (int k = key-1; k >=0; k--)
            {
                for (int m = 0; m < cipherText.Length; m++)
                {
                    if (matr[k, m] == '1')
                    {
                        matr[k, m] = cipherText[temp];
                        temp++;
                    }
                }
            }
           
            i = 0;
            j = 0;
            move_down = true;
            while (j < cipherText.Length)
            {
                if (move_down)
                {
                    plainText += matr[i, j];
                    i++; j++;
                    if (i == key - 1)
                        move_down = false;
                }
                else
                {
                    plainText += matr[i, j];
                    i--; j++;
                    if (i == 0)
                        move_down = true;
                }
            }
            return plainText;
        }
        
        public (string,int) Decode(string cipherText)
        {
            int key = 2;
            bool res = true;
            while (res)
            {
                if (SpellChecker(Decipher(cipherText, key)))
                {
                    return (Decipher(cipherText, key), key);
                }
                key++;
            }
            return ("", key);
        }
        public bool SpellChecker(string str)
        {
            using (Hunspell speller = new Hunspell("en_us.aff", "en_us.dic"))
            {
                return speller.Spell(str);
            }
        }

    }

}
