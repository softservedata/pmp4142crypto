using Cipher.Breaker.Interfaces;
using Cipher.Stream.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher.Breaker
{
    public class CardanCodeBreaker : ICodeBreaker
    {
        public string Break(IStream codeStream, IStream decodedStream)
        {
            string code = codeStream.GetText();
            string decodedText = "";



            decodedStream.SetText(decodedText);
            return decodedText;
        }
    }
}
