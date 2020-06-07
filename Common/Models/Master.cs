using System;

namespace Common.Models
{
  public class Master
  {
    private readonly string secret;

    public Master(string secret)
    {
      this.secret = secret;
    }

    public int guess(string word)
    {
      if (secret.Length != word.Length)
      {
        throw new ArgumentException("The word length must be matching secret length, which is length of six!");
      }

      int count = 0;

      for (var i = 0; i < word.Length; i++)
      {
        if (secret[i] == word[i])
        {
          count++;
        }
      }

      return count;
    }
  }
}