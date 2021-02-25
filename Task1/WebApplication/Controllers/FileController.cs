using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("encrypt/{shift}")]
        public async Task<IActionResult> Encrypt(int shift)
        {
            var cipherText = Encrypt(await Read("plain_text.txt"), shift);
            await Write(cipherText, "cipher_text.txt");
            return Ok(cipherText);
        }

        [HttpGet("decrypt/{shift}")]
        public async Task<IActionResult> Decrypt(int shift)
        {
            var plainText = Encrypt(await Read("cipher_text.txt"), -shift);
            await Write(plainText, "plain_text.txt");
            return Ok(plainText);
        }

        private async Task<string> Read(string fileName)
        {
            char[] buffer;

            using (var sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "Files", fileName)))
            {
                buffer = new char[(int) sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int) sr.BaseStream.Length);
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

        private static string Encrypt(string plainText, int shift)
        {
            var sb = new StringBuilder(plainText);

            for (var i = 0; i < sb.Length; i++)
            {
                if (!char.IsLetter(sb[i])) continue;
                
                bool isUpperFlab = char.IsUpper(sb[i]);
                if (isUpperFlab) sb[i] = char.ToLower(sb[i]);
                    
                int count = Math.Abs(shift % 25);
                int vector = shift < 0 ? -1 : 1;
                for (var j = 0; j < count; j++)
                {
                    sb[i] = (char) (sb[i] + vector);
                    if (sb[i] > 'z') sb[i] = (char) (sb[i] - 26);
                    else if (sb[i] < 'a') sb[i] = (char) (sb[i] + 26);
                }

                if (isUpperFlab) sb[i] = char.ToUpper(sb[i]);
            }

            return sb.ToString();
        }
    }
}