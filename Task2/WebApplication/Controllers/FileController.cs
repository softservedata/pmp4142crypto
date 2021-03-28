using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpGet("encrypt/{a}/{b}")]
        public async Task<IActionResult> Encrypt(int a, int b)
        {
            var cipherText = AffineCipher.Encrypt(await Read("plain_text.txt"), a, b);
            await Write(cipherText, "cipher_text.txt");
            return Ok(cipherText);
        }

        [HttpGet("decrypt/{a}/{b}")]
        public async Task<IActionResult> Decrypt(int a, int b)
        {
            var plainText = AffineCipher.Decrypt(await Read("cipher_text.txt"), a, b);
            await Write(plainText, "plain_text.txt");
            return Ok(plainText);
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
    }
}