using System;

public class Class1
{

    public string Shifr(int n, string text)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        string text1 = "";
        List<string> FinalText = new List<string>();
        for (int i = 0; i < alphabet.Length; i++)
        {
            foreach (var letter in text)
            {
                text1 += alphabet[(alphabet.IndexOf(letter) + i) % alphabet.Length];
            }
            FinalText.Add(text1);
            text1 = "";
        }

        return FinalText[n];
    }
    public string DeShifr(int n, string text)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        string text1 = "";

        for (int i = 0; i < text.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (text[i] == alphabet[j]) text1 += (alphabet[(j - n + alphabet.Length) % alphabet.Length]);
            }

        }
        return text1;
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

