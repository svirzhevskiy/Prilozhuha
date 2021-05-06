using Application.Services;

namespace Services
{
    public class DumbHashService : IHashService
    {
        public bool Verify(string text, string hash)
        {
            return text == hash;
        }

        public string GetHash(string text)
        {
            return text;
        }
    }
}