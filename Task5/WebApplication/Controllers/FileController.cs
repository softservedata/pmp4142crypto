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
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly List<char> _enUpper = new List<char> 
        { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public string Key => "word";

        [HttpGet]
        public async Task<IActionResult> VigenereCipherAsync()
        {
            var cipherText = Encrypt(await Read("plain_text.txt"));
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

            for (int i = 0; i < text.Length; i++)
            {
                if (_en.Contains(text[i]))
                {
                    encrypted += _en[(_en.IndexOf(text[i]) + _en.IndexOf(Key[i % Key.Length])) % 26];
                }
                else if (_enUpper.Contains(text[i]))
                {
                    encrypted += _enUpper[(_enUpper.IndexOf(text[i]) + _en.IndexOf(Key[i % Key.Length])) % 26];
                }
                else
                {
                    encrypted += text[i];
                }
            }

            return encrypted;
        }

        private string Decrypt(string code)
        {
            string plain = "";

            for (int i = 0; i < code.Length; i++)
            {
                if (_en.Contains(code[i]))
                {
                    plain += _en[(_en.IndexOf(code[i]) - _en.IndexOf(Key[i % Key.Length]) + 26) % 26];
                }
                else if (_enUpper.Contains(code[i]))
                {
                    plain += _enUpper[(_enUpper.IndexOf(code[i]) - _en.IndexOf(Key[i % Key.Length]) + 26) % 26];
                }
                else
                {
                    plain += code[i];
                }
            }

            return plain;
        }
    }
}