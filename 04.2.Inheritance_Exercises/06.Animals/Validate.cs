using System;

public class Validate
{
    public static void ValidateStringArgs(string args)
    {
        if (string.IsNullOrWhiteSpace(args))
        {
            throw new ArgumentException("Invalid input!");
        }
    }

    public static void ValidateNumbers(int args)
    {
        if (args < 0)
        {
            throw new ArgumentException("Invalid input!");
        }
    }
}