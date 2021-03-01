using NHunspell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarsCode
{
    public class Logic
    {
        public void ReadEncodeWrite(int key)
        {
            string path = @"data.txt";
            string readText = File.ReadAllText(path);
            if (File.Exists("EncodeData.txt"))
            {
                System.IO.File.WriteAllText("EncodeData.txt", string.Empty);
                File.WriteAllText("EncodeData.txt", String.Empty);
                File.AppendAllText("EncodeData.txt", Encipher(readText, key));
            }
            else
            {
                File.Create("EncodeData.txt");
                File.AppendAllText("EncodeData.txt", Encipher(readText, key));
            }
        }
        public char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }
        public string Encipher(string input, int key)
        {
            string output = string.Empty;
            foreach (char ch in input)
                output += cipher(ch, key);
            return output;
        }
        public string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
        public int Decode()
        {
            List<string> lst = new List<string>();
            lst = ReadTextLst();
            Dictionary<Char, int> dic = new Dictionary<char, int>();
            dic = GetLettersEntrence(lst);
            var sortedDict = from entry in dic orderby entry.Value descending select entry;

            int key = 0;
            while (Decipher(sortedDict.ElementAt(0).Key.ToString(),key).ToLower() != "e")
            {
                key++;
                if (key > 50)
                    break;
            }

            string path = @"EncodeData.txt";
            string readText = File.ReadAllText(path);
            if (File.Exists("DecodeData.txt"))
            {
                System.IO.File.WriteAllText("DecodeData.txt", string.Empty);
                File.WriteAllText("DecodeData.txt", String.Empty);
                File.AppendAllText("DecodeData.txt", Decipher(readText, key));
            }
            else
            {
                File.Create("DecodeData.txt");
                File.AppendAllText("DecodeData.txt", Decipher(readText, key));
            }

            return key;
        }
        public List<string> ReadTextLst()
        {
            string path = @"EncodeData.txt";
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
        public Dictionary<Char, int> GetLettersEntrence(List<string> text)
        {
            Dictionary<Char, int> alphabets = new Dictionary<Char, int>();
            foreach (var elem in text)
            {
                for (int i = 0; i < elem.Length; i++)
                {
                    char character = elem[i];
                    character = Convert.ToChar(character.ToString().ToLower());
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
            string path = @"DecodeData.txt";
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

            int oll_words = 0;
            int good_words = 0;

            using (Hunspell speller = new Hunspell("en_us.aff", "en_us.dic"))
            {
                foreach(var elem in FinalText)
                {
                    if (speller.Spell(elem))
                        good_words++;
                    oll_words++;
                }
               
            }

            return 100.0 * good_words / oll_words;
            //string aff = Path.Combine("D:\\University\\8_semestr\\Cryptology\\TODELETE\\TODELETE\\bin\\Debug\\netcoreapp3.1\\", "en_us.aff");
            //string dic = Path.Combine("D:\\University\\8_semestr\\Cryptology\\TODELETE\\TODELETE\\bin\\Debug\\netcoreapp3.1\\", "en_us.dic");

            //hunspell.Load(aff, dic);
        }
    }
}
