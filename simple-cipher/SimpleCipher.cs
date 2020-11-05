using System;
using System.Text;

public class SimpleCipher
{
    public string key;

    public SimpleCipher() => key = "aaaaaaaaaa";

    public SimpleCipher(string key) => this.key = key;

    public string Key => key;

    public string Encode(string ciphertext)
    {
        StringBuilder answer = new StringBuilder();

        for (int i = 0; i < ciphertext.Length; ++i)
        {
            int chars = ciphertext[i] + (key[i % key.Length] - 'a');
            answer.Append((chars < 'a') ? Convert.ToChar(chars + 26) :
                (chars > 'z') ? Convert.ToChar(chars - 26) : Convert.ToChar(chars));
        }

        return answer.ToString();
    }

    public string Decode(string ciphertext)
    {
        StringBuilder answer = new StringBuilder();

        for (int i = 0; i < ciphertext.Length; ++i)
        {
            int chars = ciphertext[i] - (key[i % key.Length] - 'a');
            answer.Append((chars < 'a') ? Convert.ToChar(chars + 26) :
                (chars > 'z') ? Convert.ToChar(chars - 26) : Convert.ToChar(chars));
        }

        return answer.ToString();
    }
}
