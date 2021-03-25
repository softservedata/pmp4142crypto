using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void ReadEncodeWrite(string key)
        {
            string path = @"data.txt";
            string readText = File.ReadAllText(path);
            if (File.Exists("EncodeData.txt"))
            {
                File.WriteAllText("EncodeData.txt", string.Empty);
                File.WriteAllText("EncodeData.txt", String.Empty);
                File.AppendAllText("EncodeData.txt", Encipher(readText, key));
            }
            else
            {
                File.Create("EncodeData.txt");
                File.AppendAllText("EncodeData.txt", Encipher(readText, key));
            }
        }


        public string DecodeParallel(int max_key_lenght)
        {
            string path = @"EncodeData.txt";
            string readText = File.ReadAllText(path);
            //
            var alpabet = "abcdefghijklmnopqrstuvwxyz".ToList();
            //
            int max_sum = 0;
            int min_sum = int.MaxValue;
            string best_key = "";
            //
            List<Task<(int, int, string)>> tasks = new List<Task<(int, int, string)>>();
            for (int i = 1; i < max_key_lenght; i++)
            {
                var combination = GetPermutationsWithRept(alpabet, i);
                tasks.Add(Task<(int,int, string)>.Run(() => Decode(readText,combination)));
            }
            //
            Task.WaitAll(tasks.ToArray());
            //
            List<(int, int, string)> ls = new List<(int,int,string)>();
            foreach (var t in tasks)
                ls.Add(t.Result);
            //
            foreach(var elem in ls)
            {
                if (elem.Item1>max_sum&&elem.Item2<min_sum)
                {
                    max_sum = elem.Item1;
                    min_sum = elem.Item2;

                    best_key = elem.Item3;
                }
            }
            //var bla = best_key.ToCharArray();
            //for(int i =0; i < bla.Length; i++)
            //{
            //    bla[i] = (char)(bla[i] - 13);
            //}
            //best_key = new string(bla);
            //
            if (File.Exists("DecodeData.txt"))
            {
                File.WriteAllText("DecodeData.txt", string.Empty);
                File.WriteAllText("DecodeData.txt", String.Empty);
                File.WriteAllText("DecodeData.txt", Decipher(readText, best_key));
            }
            else
            {
                File.Create("DecodeData.txt");
                File.AppendAllText("DecodeData.txt", Decipher(readText, best_key));
            }
            return (best_key);
        }
        public (int,int,string) Decode(string readText, IEnumerable<IEnumerable<char>> combination)
        {
            string potential_key = "";
            int max_sum = 0;
            int min_sum = int.MaxValue;
           // int bes_sum = int.MaxValue;
            string best_key = "";
            foreach (var variant in combination)
            {
                var v = variant.ToList();
                for (int j = 0; j < v.Count; j++)
                {
                    potential_key += v[j];
                }
                var temp = DecodeHelper(potential_key, readText);
                //var r = -max_sum + temp.Item1 + min_sum + temp.Item2;
                if (temp.Item1>max_sum && temp.Item2<min_sum)
                {
                    //bes_sum = r;
                    max_sum = temp.Item1;
                    min_sum = temp.Item2;
                    best_key = potential_key;
                }
                Console.WriteLine(potential_key + "  " + temp);
                potential_key = "";
            }
            return (max_sum,min_sum, best_key);
        }
        public (int,int) DecodeHelper(string potential_key,string encode_text)
        {
            string decode_text = "";
            decode_text = Decipher(encode_text, potential_key);
            var dic = GetLettersEntrence(decode_text);
            var e = dic.FirstOrDefault(c => c.Key == 'e').Value;
            var t = dic.FirstOrDefault(c => c.Key == 't').Value;
            var a = dic.FirstOrDefault(c => c.Key == 'a').Value;
            //
            var z = dic.FirstOrDefault(c => c.Key == 'z').Value;
            var q = dic.FirstOrDefault(c => c.Key == 'q').Value;
            var x = dic.FirstOrDefault(c => c.Key == 'x').Value;
            return (e + t + a,z+q+z);
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
        public IEnumerable<IEnumerable<T>> GetPermutationsWithRept<T>(IEnumerable<T> list, int length)
        {
            if(length == 1)
                return list.Select(t => new T[] { t });
            else
                return GetPermutationsWithRept(list, length - 1).SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
