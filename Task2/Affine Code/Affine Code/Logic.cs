using NHunspell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affine_Code
{
    public class Logic
    {
        public string Encipher(string plainText, int a, int b)
        {
            string cipherText = string.Empty;
            foreach (char ch in plainText)
            {
                if (!char.IsLetter(ch))
                    cipherText += ch;
                else
                {
                    char d = char.IsUpper(ch) ? 'A' : 'a';
                    cipherText += (char)((((ch - d) * a + b) % 26) + d);
                }
            }
            return cipherText;
        }
        public string Decipher(string cipherText, int a, int b)
        {
            string plainText = "";
            int x = 0;
            bool check = false;
            (check, a) = MultiplicativeInverse(a);
            if (check)
            {
                foreach (char c in cipherText)
                {
                    if (!char.IsLetter(c))
                        plainText += c;
                    else
                    {
                        char d = char.IsUpper(c) ? 'A' : 'a';
                        x = Convert.ToInt32(c - d);
                        if (x - b < 0) x = Convert.ToInt32(x) + 26;
                        plainText += Convert.ToChar(((a * (x - b)) % 26) + d);
                    }
                }
            }
            return plainText;
        }
        public (bool, int) MultiplicativeInverse(int a)
        {
            for (int x = 1; x < 27; x++)
            {
                if ((a * x) % 26 == 1)
                    return (true, x);
            }
            return (false, 0);
        }
        public void ReadEncodeWrite(int a, int b)
        {
            string path = @"data.txt";
            string readText = File.ReadAllText(path);
            if (File.Exists("EncodeData.txt"))
            {
                File.WriteAllText("EncodeData.txt", string.Empty);
                File.WriteAllText("EncodeData.txt", String.Empty);
                File.AppendAllText("EncodeData.txt", Encipher(readText,a,b));
            }
            else
            {
                File.Create("EncodeData.txt");
                File.AppendAllText("EncodeData.txt", Encipher(readText,a,b));
            }
        }
        public  (int,int) Decode()
        {
            string path = @"EncodeData.txt";
            string readText = File.ReadAllText(path);
            //
            Dictionary<Char, int> dic = new Dictionary<char, int>();
            dic = GetLettersEntrence(File.ReadAllText(@"EncodeData.txt"));
            var sortedDict = from entry in dic orderby entry.Value descending select entry;
            //
            int[] potential_a = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
            int[] potential_b = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
            //
            var res = DecodeHelper(potential_a, potential_b, readText);
            if (File.Exists("DecodeData.txt"))
            {
                File.WriteAllText("DecodeData.txt", string.Empty);
                File.WriteAllText("DecodeData.txt", String.Empty);
                File.WriteAllText("DecodeData.txt", Decipher(readText, res.Item1, res.Item2));
            }
            else
            {
                File.Create("DecodeData.txt");
                File.AppendAllText("DecodeData.txt", Decipher(readText, res.Item1, res.Item2));
            }
            return (res.Item1, res.Item2);
        }
        public (int,int,int) DecodeHelper(int[] potential_a, int[] potential_b, string encode_text)
        {
            string decode_text = "";
            int max_sum = 0;
            int best_a = 0;
            int best_b = 0;
            int sum = 0;
            for (int i = 0; i < potential_a.Length; i++)
            {
                for (int j = 0; j < potential_b.Length; j++)
                {
                    decode_text = Decipher(encode_text, potential_a[i], potential_b[j]);
                    var dic = GetLettersEntrence(decode_text);
                    var e = dic.FirstOrDefault(c => c.Key == 'e').Value;
                    var t = dic.FirstOrDefault(c => c.Key == 't').Value;
                    var a = dic.FirstOrDefault(c => c.Key == 'a').Value;
                    sum = e + t + a;
                    if (sum > max_sum)
                    {
                        max_sum = sum;
                        best_a = potential_a[i];
                        best_b = potential_b[j];
                    }
                    sum = 0;
                }
            }
            return (best_a, best_b,max_sum);
        }
        public List<string> ReadTextLst(string path)
        {
            string readText = File.ReadAllText(path);
            string[] SplitText = readText.Split(',', '.', ';', ':', ' ', '-');
            List<string> FinalText = new List<string>();
            foreach (var elem in SplitText)
            {
                if (elem != "" && !FinalText.Contains(elem) && elem != "\n" && elem != string.Empty && elem != String.Empty && !String.IsNullOrEmpty(elem) && !String.IsNullOrWhiteSpace(elem) && !string.IsNullOrEmpty(elem))
                {
                    FinalText.Add(String.Concat(elem.Where(c => !Char.IsWhiteSpace(c))));
                }
            }
            return FinalText;
        } 
        public Dictionary<Char, int> GetLettersEntrence(string text)
        {
            Dictionary<Char, int> alphabets = new Dictionary<Char, int>();
            char character;
            foreach (var elem in text)
            {
                if (char.IsLetter(elem))
                {
                    character = Convert.ToChar(elem.ToString().ToLower());
                    if (Char.IsLetter(character))
                    {
                        if (alphabets.ContainsKey(character))
                            alphabets[character] = alphabets[character] + 1;
                        else
                            alphabets.Add(character, 1);
                    }
                }
            }
            return alphabets;
        }
        public double SpellChecker()
        {
            List<string> FinalText = new List<string>();
            FinalText = ReadTextLst(@"DecodeData.txt");
            int oll_words = 0;
            int good_words = 0;
            using (Hunspell speller = new Hunspell("en_us.aff", "en_us.dic"))
            {
                foreach (var elem in FinalText)
                {
                    if (speller.Spell(elem))
                        good_words++;
                    oll_words++;
                }
            }
            return 100.0 * good_words / oll_words;
        }
    }
}
