using System;

public class Validation
{
    public static void AuthorSecondName (string name)
    {
        string[] nameArgs = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (nameArgs.Length > 1)
        {
            if (char.IsNumber(nameArgs[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
        }
    }

    public static void ValidateTitle (string title)
    {
        if (title.Length < 3)
        {
            throw new ArgumentException("Title not valid!");
        }
    }

    public static void ValidatePrice (decimal price)
    {
        if (price <= 0)
        {
            throw new ArgumentException("Price not valid!");
        }
    }
}