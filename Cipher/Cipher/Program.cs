using Cipher.Breaker;
using Cipher.Breaker.Interfaces;
using Cipher.Cipher;
using Cipher.Cipher.Interfaces;
using Cipher.Stream;
using Cipher.Stream.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            IStream text = new TxtStream("data.txt");
            IStream encodedText = new TxtStream("data_encoded.txt");
            IStream decodedText = new TxtStream("data_decoded.txt");
            IStream breakedText = new TxtStream("data_breaked.txt");

            ////Task1
            //ICipher cipher = new CeaserCipher(new Random().Next());
            //cipher.Encode(text, encodedText);
            //cipher.Decode(encodedText, decodedText);
            //ICodeBreaker codeBreaker = new СaesarCodeBreaker();
            //codeBreaker.Break(encodedText, breakedText);

            ////Task2
            //// alpha = [ 1, 3, 5, 7, 9, 11, 15, 17, 19, 21, 23 , 25 ]
            //// beta  = [ 0 - 25]
            //ICipher cipher = new AffineCipher(7, 23);
            //cipher.Encode(text, encodedText);
            //cipher.Decode(encodedText, decodedText);
            //ICodeBreaker codeBreaker = new AffineCodeBreaker();
            //codeBreaker.Break(encodedText, breakedText);

            ////Task3
            ///  0 = 0000
            //// 1 = 0001
            //// 2 = 0010
            //// 4 = 0100
            //// 8 = 1000
            ICipher cipher = new CardanCipher("1f84");
            cipher.Encode(text, encodedText);
            cipher.Decode(encodedText, decodedText);
            //ICodeBreaker codeBreaker = new CardanCodeBreaker();
            //codeBreaker.Break(encodedText, breakedText);

        }
    }
}
