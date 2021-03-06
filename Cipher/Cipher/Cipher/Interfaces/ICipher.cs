using Cipher.Stream.Interfaces;

namespace Cipher.Cipher.Interfaces
{
    public interface ICipher
    {
        string Encode(IStream textStream, IStream encodedStream);
        string Decode(IStream codeStream, IStream decodedStream);
    }
}
