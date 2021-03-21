using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System.Collections.Generic;
using System;

namespace Cipher.Cipher
{
    public class RSA : ICipher
    {
        private readonly IList<char> arr_en = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly IList<char> arr_EN = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly (long e, long n) publicKey;
        private readonly (long d, long n) privateKey;

        public RSA(int q, int p)
        {
            Console.WriteLine("p = " + p);
            Console.WriteLine("q = " + q);

            long n = q * p;
            long phi = (q - 1) * (p - 1);

            Console.WriteLine("n = q * p = " + q + " * " + p + " = " + n);
            Console.WriteLine("phi = (q - 1) * (p - 1) = " + (q - 1) + " * " + (p - 1) + " = " + phi);

            List<long> potentionalE = new List<long>();
            List<long> potentionalD = new List<long>();

            Random random = new Random();

            for (long i = 3; i < phi; i++)
            {
                bool isSimple = true;
                for (long j = 2; j < i; j++)
                {
                    if ((double)i % j == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }
                if (isSimple)
                {
                    bool isMutualSimple = true;
                    for (long j = 2; j <= i; j++)
                    {
                        if ((double)i % j == 0 && (double)phi % j == 0)
                        {
                            isMutualSimple = false;
                            break;
                        }
                    }
                    if (isMutualSimple)
                    {
                        potentionalE.Add(i);
                        if (potentionalE.Count == 1000)
                        {
                            break;
                        }
                    }
                }
            }

            long e = potentionalE[random.Next() % potentionalE.Count];
            Console.WriteLine("e < phi; e - simple; e, phi - mutual simple; e = " + e);

            for (long i = 0; i < Int32.MaxValue; i++)
            {
                if ((i * e) % phi == 1)
                {
                    potentionalD.Add(i);
                    if (potentionalD.Count == 100)
                    {
                        break;
                    }
                }
            }

            long d = potentionalD[random.Next() % potentionalD.Count];
            Console.WriteLine("(d * e) % phi == 1; d = " + d);

            publicKey.n = privateKey.n = n;
            publicKey.e = e;
            privateKey.d = d;

            Console.WriteLine("publicKey : { e , n } = { " + publicKey.e + " , " + publicKey.n + " }");
            Console.WriteLine("privateKey : { d , n } = { " + privateKey.d + " , " + privateKey.n + " }");
        }

        public string Encode(IStream textStream, IStream encodedStream)
        {
            string text = textStream.GetText();
            string encoded = "";

            foreach (char symbol in text)
            {
                long encodeNumber = symbol;
                long encodeTemp = 1;
                for (int i = 0; i < publicKey.e; i++)
                {
                    encodeTemp = (encodeTemp * encodeNumber) % publicKey.n;
                }
                encoded+=encodeTemp+" ";
            }
            encoded=encoded.Remove(encoded.Length - 1);
            encodedStream.SetText(encoded);
            return encoded;
        }

        public string Decode(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decoded = "";

            foreach (string codeSymbol in code.Split(' '))
            {
                long decodeNumber = Convert.ToInt64(codeSymbol);
                long decodeTemp = 1;
                for (int i = 0; i < privateKey.d; i++)
                {
                    decodeTemp = (decodeTemp * decodeNumber) % privateKey.n;
                }
                decoded += (char)decodeTemp;
                Console.WriteLine(decoded);
            }

            decodedStream.SetText(decoded);
            return decoded;
        }
    }
}
