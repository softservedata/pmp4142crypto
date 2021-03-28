using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly List<char> _en = new List<char>
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 
            'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
            'U', 'V', 'W', 'X', 'Y', 'Z', ' '
        };

        private int _height;

        [HttpGet]
        public async Task<IActionResult> FenceCipherAsync()
        {
            var text = await Read("plain_text.txt");
            _height = (int)Math.Sqrt(text.Length);

            var cipherText = Encrypt(text);
            await Write(cipherText, "cipher_text.txt");

            var plainText = Decrypt(await Read("cipher_text.txt"));
            await Write(plainText, "plain_text.txt");

            return Ok();
        }

        private async Task<string> Read(string fileName)
        {
            char[] buffer;

            using (var sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Files", fileName)))
            {
                buffer = new char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }

            return new string(buffer);
        }

        private async Task Write(string text, string fileName)
        {
            using (var sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "Files", fileName)))
            {
                await sw.WriteAsync(text);
            }
        }

        private string Encrypt(string text)
        {
            string encrypted = "";
            char[,] fence = new char[_height, text.Length];
            int i = 0, j = 0;
            bool moveDown = true;

            while (j < text.Length)
            {
                fence[i, j] = text[j];
                j++;

                if (moveDown)
                {
                    i++;
                    if (i == _height - 1) moveDown = false;
                }
                else
                {
                    i--;
                    if (i == 0) moveDown = true;
                }
            }

            Random random = new Random();

            for (int p = 0; p < fence.GetLength(0); p++)
            {
                for (int m = 0; m < fence.GetLength(1); m++)
                {
                    if (fence[p, m] == '\0')
                    {
                        encrypted += _en[random.Next() % _en.Count];
                    }
                    else
                    {
                        encrypted += fence[p, m];
                    }
                }
            }

            return encrypted;
        }

        private string Decrypt(string code)
        {
            string plain = "";
            char[,] fence = new char[_height, code.Length / _height];

            for (int q = 0; q < fence.GetLength(0); q++)
            {
                for (int m = 0; m < fence.GetLength(1); m++)
                {
                    fence[q, m] = code[q * fence.GetLength(1) + m];
                }
            }

            int i = 0, j = 0;
            bool moveDown = true;

            while (j < fence.GetLength(1))
            {
                plain += fence[i, j];
                j++;

                if (moveDown)
                {
                    i++;
                    if (i == _height - 1) moveDown = false;
                }
                else
                {
                    i--;
                    if (i == 0) moveDown = true;
                }
            }

            return plain;
        }
    }
}