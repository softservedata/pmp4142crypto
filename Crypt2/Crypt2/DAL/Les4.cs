using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypt2.DAL
{
    public class Les4
    {
        public string Encipher(string plainText, int key)
        {
            string cipherText = string.Empty;
            char[,] matr = new char[key, plainText.Length];
            int i = 0;
            int j = 0;
            bool move_down = true;

            while (j < plainText.Length)
            {
                if (move_down)
                {
                    matr[i, j] = plainText[j];
                    i++; j++;
                    if (i == key - 1)
                        move_down = false;
                }
                else
                {
                    matr[i, j] = plainText[j];
                    i--; j++;
                    if (i == 0)
                        move_down = true;
                }
            }

            for (int k = matr.GetLength(0) - 1; k >= 0; k--)
            {
                for (int m = 0; m < matr.GetLength(1); m++)
                {
                    if (matr[k, m] != '\0')
                        cipherText += matr[k, m];
                }
            }

            return cipherText;
        }
        public string Decipher(string cipherText, int key)
        {
            string plainText = string.Empty;
            char[,] matr = new char[key, cipherText.Length];
            int i = 0;
            int j = 0;
            bool move_down = true;

            while (j < cipherText.Length)
            {
                if (move_down)
                {
                    matr[i, j] = '1';
                    i++; j++;
                    if (i == key - 1)
                        move_down = false;
                }
                else
                {
                    matr[i, j] = '1';
                    i--; j++;
                    if (i == 0)
                        move_down = true;
                }
            }

            int temp = 0;
            for (int k = key - 1; k >= 0; k--)
            {
                for (int m = 0; m < matr.GetLength(1); m++)
                {
                    if (matr[k, m] == '1')
                    {
                        matr[k, m] = cipherText[temp];
                        temp++;
                    }
                }
            }

            for (int k = 0; k < key; k++)
            {
                for (int m = 0; m < cipherText.Length; m++)
                {
                    Console.Write(matr[k, m] + " ");
                }
                Console.WriteLine();
            }

            i = 0;
            j = 0;
            move_down = true;
            while (j < cipherText.Length)
            {
                if (move_down)
                {
                    plainText += matr[i, j];
                    i++; j++;
                    if (i == key - 1)
                        move_down = false;
                }
                else
                {
                    plainText += matr[i, j];
                    i--; j++;
                    if (i == 0)
                        move_down = true;
                }
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
    }
}
