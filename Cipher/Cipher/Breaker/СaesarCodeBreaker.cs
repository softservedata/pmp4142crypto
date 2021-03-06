using Cipher.Breaker.Interfaces;
using Cipher.Cipher;
using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cipher.Breaker
{
    public class СaesarCodeBreaker : ICodeBreaker
    {
        private readonly char[] arr_en = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public string Break(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            foreach (char el in arr_en)
            {
                alphabet.Add(el, 0);
            }
            string lowerCaseCode = code.ToLower();
            for (int i = 0; i < code.Length; i++)
            {
                if (arr_en.Contains(lowerCaseCode[i]))
                {
                    alphabet[lowerCaseCode[i]] += 1;
                }
            }
            char theMostPopularLetter = (from latter in alphabet where latter.Value == (from num in alphabet select num.Value).Max() select latter.Key).FirstOrDefault();

            foreach (var el in alphabet)
            {
                Console.WriteLine(el.Key + " : " + el.Value);
            }
            Console.WriteLine("The Most Popular Letter Is 'E' = " + theMostPopularLetter);

            int n = arr_en.ToList().IndexOf(theMostPopularLetter) - arr_en.ToList().IndexOf('e');

            Console.WriteLine("Code kay = " + n);

            ICipher cipher = new CeaserCipher(n);
            string decodedText = cipher.Decode(codeStream, decodedStream);

            decodedStream.SetText(decodedText);
            return decodedText;
        }
    }
}
