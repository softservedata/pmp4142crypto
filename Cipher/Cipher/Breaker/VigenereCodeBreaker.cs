using Cipher.Breaker.Interfaces;
using Cipher.Cipher;
using Cipher.Cipher.Interfaces;
using Cipher.Stream.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cipher.Breaker
{
    public class VigenereCodeBreaker : ICodeBreaker
    {
        private readonly IList<char> arr_en = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        readonly List<string> potentionalKeys = new List<string>();
        readonly CancellationTokenSource cancelTokenSource;
        readonly CancellationToken token;
        public int KeyMaxLength { get; set; } = 5;
        public VigenereCodeBreaker()
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
        }

        public string Break(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decodedText = "";
            string lowerCaseCode = code.ToLower();
            string potentionalKey = "";

            List<Task> tasks = new List<Task>();

            for (int i = 1; i < KeyMaxLength; i++)
            {
                int localI = i;
                Task.Run(() => Find(localI, lowerCaseCode, token));
            }

            int index = 0;
            ConsoleKey key = ConsoleKey.UpArrow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("UpArrow - Next\nDownArrow - Previous\nEnter - End");
            Console.WriteLine();
            while (key != ConsoleKey.Enter)
            {
                if (potentionalKeys.Count == 0)
                {
                    continue;
                }

                if (key == ConsoleKey.UpArrow)
                {
                    index += 1;
                    if (index == potentionalKeys.Count)
                    {
                        index = 0;
                    }

                }
                if (key == ConsoleKey.DownArrow)
                {
                    index -= 1;
                    if (index == -1)
                    {
                        index = potentionalKeys.Count - 1;
                    }
                }
                potentionalKey = potentionalKeys[index];

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("____________________________________________");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("key = " + potentionalKeys[index]);
                decodedText = Decode(potentionalKey, lowerCaseCode);
                Console.WriteLine();
                for (int i = 0; i < 295; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(decodedText[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("____________________________________________");
                Console.WriteLine();
                key = Console.ReadKey().Key;
            }

            cancelTokenSource.Cancel();
            ICipher cipher = new VigenereCipher(potentionalKey);
            decodedText = cipher.Decode(codeStream, decodedStream);
            return decodedText;
        }
        private void Find(int temp, string lowerCaseCode, CancellationToken token)
        {
            string decodedText = "";
            foreach (string potentionalKey in GenerateStrings(temp))
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                decodedText = Decode(potentionalKey, lowerCaseCode);
                Dictionary<char, int> alphabet = CountLetters(decodedText);

                char[] popularLetters = new char[3];
                popularLetters[0] = alphabet.Select(pair => pair.Key).Where(key => alphabet[key] == alphabet.Select(pair => pair.Value).Max()).First();
                alphabet.Remove(popularLetters[0]);
                popularLetters[1] = alphabet.Select(pair => pair.Key).Where(key => alphabet[key] == alphabet.Select(pair => pair.Value).Max()).First();
                alphabet.Remove(popularLetters[1]);
                popularLetters[2] = alphabet.Select(pair => pair.Key).Where(key => alphabet[key] == alphabet.Select(pair => pair.Value).Max()).First();
                alphabet.Remove(popularLetters[2]);

                char[] unpopularLetters = new char[3];
                unpopularLetters[0] = alphabet.Select(pair => pair.Key).Where(key => alphabet[key] == alphabet.Select(pair => pair.Value).Min()).First();
                alphabet.Remove(unpopularLetters[0]);
                unpopularLetters[1] = alphabet.Select(pair => pair.Key).Where(key => alphabet[key] == alphabet.Select(pair => pair.Value).Min()).First();
                alphabet.Remove(unpopularLetters[1]);
                unpopularLetters[2] = alphabet.Select(pair => pair.Key).Where(key => alphabet[key] == alphabet.Select(pair => pair.Value).Min()).First();
                alphabet.Remove(unpopularLetters[2]);

                if (popularLetters.Contains('e') &&
                   popularLetters.Contains('t') &&
                   popularLetters.Contains('a') &&
                   unpopularLetters.Contains('j') &&
                   unpopularLetters.Contains('q') &&
                   unpopularLetters.Contains('z'))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("New potentional key has been founded!");
                    Console.WriteLine();
                    //Console.WriteLine("key: (" + potentionalKey + "); " +
                    //        "popular letters: (" + popularLetters[0] + popularLetters[1] + popularLetters[2] + "); " +
                    //        "unpopular letters: (" + unpopularLetters[0] + unpopularLetters[1] + unpopularLetters[2] + "); " +
                    //        "TRUE;");
                    potentionalKeys.Add(potentionalKey);
                }
                else
                {
                    //Console.WriteLine("key: (" + potentionalKey + "); " +
                    //        "popular letters: (" + popularLetters[0] + popularLetters[1] + popularLetters[2] + "); " +
                    //        "unpopular letters: (" + unpopularLetters[0] + unpopularLetters[1] + unpopularLetters[2] + "); " +
                    //        "False;");
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Finding (key length:" + temp + ") - ENDED");
            Console.WriteLine();
        }

        private Dictionary<char, int> CountLetters(string text)
        {
            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            foreach (char el in arr_en)
            {
                alphabet.Add(el, 0);
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (arr_en.Contains(text[i]))
                {
                    alphabet[text[i]] += 1;
                }
            }
            return alphabet;
        }
        private string Decode(string key, string lowerCaseCode)
        {
            string decoded = "";
            for (int i = 0; i < lowerCaseCode.Length; i++)
            {
                if (arr_en.Contains(lowerCaseCode[i]))
                {
                    decoded += arr_en[(arr_en.IndexOf(lowerCaseCode[i]) - arr_en.IndexOf(key[i % key.Length]) + 26) % 26];
                }
                else
                {
                    decoded += lowerCaseCode[i];
                }
            }
            return decoded;
        }

        private IEnumerable<String> GenerateStrings(int length)
        {
            if (length == 0)
            {
                yield return String.Empty;
                yield break;
            }
            var strings = arr_en.SelectMany(c => GenerateStrings(length - 1), (c, s) => c + s);
            foreach (var str in strings)
                yield return str;
        }
    }
}
