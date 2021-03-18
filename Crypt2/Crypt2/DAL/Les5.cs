using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypt2.DAL
{
    class Les5
    {
        public string ReadN(string FileLocation)
        {
            string path = @"data4.txt";


            string readText = File.ReadAllText(path);


            return readText;
        }
        public List<string> ReadText(string FileLocation)
        {
            // TODO 

            string path = @"data1.txt";

            // Open the file to read from.
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
            List<string> FinalText2 = new List<string>();
            foreach (string elem in FinalText)
            {
                FinalText2.Add(elem.ToLower());
            }
            return FinalText2;
        }
        public void WriteResult(List<string> res)
        {


            int TotalCountOfWords = res.Count();

            if (File.Exists("OutputData2.txt"))
            {
                System.IO.File.WriteAllText("OutputData2.txt", string.Empty);
                File.WriteAllText("OutputData2.txt", String.Empty);
                for (int j = 0; j < TotalCountOfWords; j++)
                {

                    File.AppendAllText("OutputData2.txt", res[j] + " ");
                }
            }
            else
            {
                File.Create("OutputData2.txt");
                for (int j = 0; j < TotalCountOfWords; j++)
                {
                    File.AppendAllText("OutputData2.txt", res[j] + " ");
                }
            }
        }
        public void WriteKey(List<string> res)
        {


            int TotalCountOfWords = res.Count();

            if (File.Exists("data4.txt"))
            {
                System.IO.File.WriteAllText("data4.txt", string.Empty);
                File.WriteAllText("data4.txt", String.Empty);
                for (int j = 0; j < TotalCountOfWords; j++)
                {

                    File.AppendAllText("data4.txt", res[j] + " ");
                }
            }
            else
            {
                File.Create("data4.txt");
                for (int j = 0; j < TotalCountOfWords; j++)
                {
                    File.AppendAllText("data4.txt", res[j] + " ");
                }
            }
        }
    }
    public class VigenereCipher
    {
        const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly string letters;
        public VigenereCipher(string alphabet = null)
        {
            letters = string.IsNullOrEmpty(alphabet) ? defaultAlphabet : alphabet;
        }
        private string GetRepeatKey(string s, int n)//генерування повторюваного пароля
        {
            var p = s;
            while (p.Length < n)
            {
                p += p;
            }
            return p.Substring(0, n);
        }

        private string Vigenere(string text, string password, bool encrypting = true)
        {
            var gamma = GetRepeatKey(password, text.Length);
            var result = "";
            var q = letters.Length;
            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = letters.IndexOf(text[i]);
                var codeIndex = letters.IndexOf(gamma[i]);
                if (letterIndex < 0)
                {
                    result += text[i].ToString();//якщо літера не знайдена, додаємо її в незмінному вигляді
                }
                else
                {
                    result += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
                }
            }
            return result;
        }

        //шифрування тексту
        public string Encrypt(string plainMessage, string password)
            => Vigenere(plainMessage, password);

        //дешифрування тексту
        public string Decrypt(string encryptedMessage, string password)
            => Vigenere(encryptedMessage, password, false);
    }
}
