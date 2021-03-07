using Cipher.Breaker.Interfaces;
using Cipher.Cipher;
using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cipher.Breaker
{
    public class AffineCodeBreaker : ICodeBreaker
    {
        private readonly char[] arr_en = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private char[] cipherArr_en;
        private readonly int[] alphaArr = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
        private readonly int[] betaArr = Enumerable.Range(0, 26).ToArray();
        public string Break(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decodedText = "";
            string lowerCaseCode = code.ToLower();
            int trueAlpha = 1;
            int trueBeta = 0;
            foreach (int alpha in alphaArr)
            {
                foreach (int beta in betaArr)
                {
                    calculateCipherArr_en(alpha, beta);
                    decodedText = Decode(lowerCaseCode);

                    //Create dictionary
                    Dictionary<char, int> alphabet = new Dictionary<char, int>();
                    foreach (char el in arr_en)
                    {
                        alphabet.Add(el, 0);
                    }
                    for (int i = 0; i < decodedText.Length; i++)
                    {
                        if (arr_en.Contains(decodedText[i]))
                        {
                            alphabet[decodedText[i]] += 1;
                        }
                    }
                    char[] popularLetters = new char[3];
                    popularLetters[0] = (from letter in alphabet where letter.Value == (from num in alphabet select num.Value).Max() select letter.Key).FirstOrDefault();
                    alphabet.Remove(popularLetters[0]);
                    popularLetters[1] = (from letter in alphabet where letter.Value == (from num in alphabet select num.Value).Max() select letter.Key).FirstOrDefault();
                    alphabet.Remove(popularLetters[1]);
                    popularLetters[2] = (from letter in alphabet where letter.Value == (from num in alphabet select num.Value).Max() select letter.Key).FirstOrDefault();
                    alphabet.Remove(popularLetters[2]);

                    char[] unpopularLetters = new char[3];
                    unpopularLetters[0] = (from letter in alphabet where letter.Value == (from num in alphabet select num.Value).Min() select letter.Key).FirstOrDefault();
                    alphabet.Remove(unpopularLetters[0]);
                    unpopularLetters[1] = (from letter in alphabet where letter.Value == (from num in alphabet select num.Value).Min() select letter.Key).FirstOrDefault();
                    alphabet.Remove(unpopularLetters[1]);
                    unpopularLetters[2] = (from letter in alphabet where letter.Value == (from num in alphabet select num.Value).Min() select letter.Key).FirstOrDefault();
                    alphabet.Remove(unpopularLetters[2]);

                    ///////////////////Console
                    Console.Write("alpha : " + alpha + ", beta: " + beta + ". ");
                    Console.Write("Popular letters: '");
                    Console.Write(popularLetters);
                    Console.Write("'. ");
                    Console.Write("Unpopular letters: '");
                    Console.Write(unpopularLetters);
                    Console.Write("'. ");
                    ////////////////////

                    if (popularLetters.Contains('e') &&
                        popularLetters.Contains('t') &&
                        popularLetters.Contains('a') &&
                        unpopularLetters.Contains('j') &&
                        unpopularLetters.Contains('q') &&
                        unpopularLetters.Contains('z'))
                    {
                        Console.WriteLine("TRUE");
                        trueAlpha = alpha;
                        trueBeta = beta;
                    }
                    else
                    {
                        Console.WriteLine("FAlSE");
                    }
                }
            }

            ICipher cipher = new AffineCipher(trueAlpha, trueBeta);
            decodedText = cipher.Decode(codeStream, decodedStream);
            return decodedText;
        }

        private void calculateCipherArr_en(int alpha, int beta)
        {
            this.cipherArr_en = (char[])(arr_en.Clone());
            for (int i = 0; i < arr_en.Length; i++)
            {
                cipherArr_en[(i * alpha + beta) % arr_en.Length] = arr_en[i];
            }
        }

        private string Decode(string lowerCaseCode)
        {
            string decodedText = "";
            for (int i = 0; i < lowerCaseCode.Length; i++)
            {
                if (arr_en.Contains(lowerCaseCode[i]))
                {
                    decodedText += arr_en[cipherArr_en.ToList().IndexOf(lowerCaseCode[i])];
                }
                else
                {
                    decodedText += lowerCaseCode[i];
                }
            }
            return decodedText;
        }
    }
}
