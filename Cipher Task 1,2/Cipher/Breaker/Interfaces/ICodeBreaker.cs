using Cipher.Stream.Interfaces;

namespace Cipher.Breaker.Interfaces
{
    public interface ICodeBreaker
    {
        string Break(IStream codeStream, IStream decodedStream);
    }
}
