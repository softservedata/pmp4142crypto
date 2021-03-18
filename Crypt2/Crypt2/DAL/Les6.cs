using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Crypt2.DAL
{
    class Les6
    {
        public char[] characters = new char[] { '#', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H','I','J','K', 'L',
                                                'M', 'N', 'O','P', 'Q', 'R', 'S', 'T', 'U', 'V',
                                                'W', 'X', 'Y', 'Z', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0' };
        public string ReadN(string FileLocation)
        {
            string path = @"data3.txt";


            string readText = File.ReadAllText(path);


            return readText;
        }

        public string ReadN1(string FileLocation)
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

            if (File.Exists("data3.txt"))
            {
                System.IO.File.WriteAllText("data3.txt", string.Empty);
                File.WriteAllText("data3.txt", String.Empty);
                for (int j = 0; j < TotalCountOfWords; j++)
                {

                    File.AppendAllText("data3.txt", res[j] + " ");
                }
            }
            else
            {
                File.Create("data3.txt");
                for (int j = 0; j < TotalCountOfWords; j++)
                {
                    File.AppendAllText("data3.txt", res[j] + " ");
                }
            }
        }
        public void WriteKey1(List<string> res)
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
        public bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        public string CreateKey()
        {
            Random random = new Random();
            
            long a = random.Next(100, 1000);
            while(!IsTheNumberSimple(a)){
                a = random.Next(100, 1000);
            }
            return Convert.ToString(a);
        }
        public List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }



        public string RSA_Dedoce(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());
                index = Math.Abs(index);
                result += characters[index].ToString();
            }

            return result;
        }


        public long Calculate_d(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //якщо є спільні дільники
                {
                    d--;
                    i = 1;
                }

            return d;
        }

        public long Calculate_e(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }
    }
}
