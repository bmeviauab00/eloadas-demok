namespace Crypto
{
    public class Encryptor
    {
        public static string Encrypt(string input)
        {
            return new string(input.Reverse().ToArray());
        }
    }
}