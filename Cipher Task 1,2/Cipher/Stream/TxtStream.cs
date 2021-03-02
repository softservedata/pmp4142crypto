using Cipher.Stream.Interfaces;
using System;
using System.IO;

namespace Cipher.Stream
{
    public class TxtStream : IStream
    {
        private readonly string filePath;
        public TxtStream(string path)
        {
            filePath = path;
        }
        public string GetText()
        {
            try
            {
                string text;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    text = sr.ReadToEnd();
                }
                return text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }
        public int SetText(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    sw.Write(text);
                }
                return text.Length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
