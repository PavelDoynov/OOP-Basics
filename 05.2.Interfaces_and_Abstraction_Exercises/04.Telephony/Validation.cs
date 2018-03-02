using System;
using System.Linq;

public class Validation
{
    public static void ValidateURL(string url)
    {
        if (url.Any(char.IsDigit))
        {
            throw new ArgumentException("Invalid URL!");
        }
    }

    public static void ValidatePhoneNumber(string phoneNumber)
    {
        if (!phoneNumber.All(char.IsDigit))
        {
            throw new ArgumentException("Invalid number!");
        }
    }
}