using System;

namespace WebApplication.Models
{
    public static class AffineCipher
    {
        public static string Encrypt(string plainText, int a, int b)
        {
            CheckParamA(a);

            var text = "";

            foreach (var ch in plainText.ToCharArray())
            {
                if (!char.IsLetter(ch))
                {
                    text += ch;
                }
                else
                {
                    bool flag = char.IsUpper(ch);
                    var res = char.ToLower(ch);

                    var x = ((res - 'a') * a + b) % 26;
                    res = (char)('a' + x);
                    if (flag) res = char.ToUpper(res);

                    text += res;
                }
            }

            return text;
        }

        public static string Decrypt(string cipheredText, int a, int b)
        {
            CheckParamA(a);
            var y = FindY(a);

            var text = "";
            foreach (var ch in cipheredText.ToCharArray())
            {
                char res;

                if (!char.IsLetter(ch))
                {
                    res = ch;
                }
                else
                {
                    bool flag = char.IsUpper(ch);
                    res = char.ToLower(ch);

                    var x = (y * ((res - 'a') - b)) % 26;
                    if (x < 0)
                    {
                        x += 26;
                    }

                    res = (char)('a' + x);
                    if (flag) res = char.ToUpper(res);
                }

                text += res;
            }

            return text;
        }

        private static void CheckParamA(int a)
        {
            if (a % 2 == 0 || a % 13 == 0)
            {
                throw new ArgumentException("'a' and alphabet size must be co-prime.");
            }
        }

        private static int FindY(int a)
        {
            for (var i = 1; i < 26; i++)
            {
                if (a * i % 26 == 1)
                {
                    return i;
                }
            }

            throw new ArgumentException("Cannot find y");
        }
    }
}
