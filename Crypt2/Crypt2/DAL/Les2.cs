using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypt2.DAL
{

    class Les2
    {
        string[] alf = new string[] { }; // алфавіт як массив букв string
        int[] x = new int[] { }; // x номер букви
        int[] eMod = new int[] { };// зашифрованні номера букв (3x+4)mod26
        string[] shifr = new string[] { }; //зашифрованний алфавіт - букви шифротексту
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static int ExtendedEuclide(int a, int b)
        {
            
            int q;
            int x = 1;
            int y = 0;
            int d;
            int x2 = 1;
            int x1 = 0;
            int y1 = 1;
            int y2 = 0;

            int r;
            while (b > 0)
            {
                q = a / b;
                
                r = a % b;
                x = x2 - q * x1;
                y = y2 - q * y1;
                a = b;
                b = r;
                x2 = x1; x1 = x; y2 = y; y1 = y;
            }

            d = a;
            x = x2;
            y = y2;
            return d;
        }
        public void CreateAlphabet(int a, int b, string alphabet)
        {
            eMod = null;
            shifr = null;

            alf = new string[alphabet.Length];
            x = new int[alphabet.Length];
            eMod = new int[alphabet.Length];
            shifr = new string[alphabet.Length];

            for (int i = 0; i < alphabet.Length; i++)
            {
                alf[i] = alphabet.Substring(i, 1);
                x[i] = i;
            }

            for (int i = 0; i < alphabet.Length; i++)
            {

                eMod[i] = (a * x[i] + b) % alphabet.Length;
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                shifr[i] = alf[eMod[i]];
            }
        }
        public  string AffineEncrypt(string plainText, int a, int b)
        {
            string cipherText = "";

            char[] chars = plainText.ToUpper().ToCharArray();

            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c - 65);
                cipherText += Convert.ToChar(((a * x + b) % 26) + 65);
            }

            return cipherText;
        }
        public  string AffineDecrypt(string cipherText, int a, int b)
        {
            string plainText = "";

            
            int aInverse = MultiplicativeInverse(a);

           
            char[] chars = cipherText.ToUpper().ToCharArray();
            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c - 65);
                if (x - b < 0) x = Convert.ToInt32(x) + 26;
                plainText += Convert.ToChar(((aInverse * (x - b)) % 26) + 65);
            }

            return plainText;
        }
        public List<string> ReadText2(string FileLocation)
        {
            // TODO 

            string path = @"data2.txt";

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
        public int ReadN(string FileLocation)
        {
            string path = @"data3.txt";


            string readText = File.ReadAllText(path);

            return Convert.ToInt32(readText);
        }
        public int ReadN1(string FileLocation)
        {
            string path = @"data4.txt";


            string readText = File.ReadAllText(path);

            return Convert.ToInt32(readText);
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
        public  int MultiplicativeInverse(int a)
        {
            for (int x = 1; x < 27; x++)
            {
                if ((a * x) % 26 == 1)
                    return x;
            }

            throw new Exception("No multiplicative inverse found!");
        }

    }

    
}
