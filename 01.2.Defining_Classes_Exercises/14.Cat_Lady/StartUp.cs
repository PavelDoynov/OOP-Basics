/*
 * 14. Cat Lady
 * 
 * Ginka has many cats of various breeds in her house. Since some breeds have specific characteristics, Ginka needs some 
 * way to catalogue the cats. Help her by creating a class hierarchy with all her breeds of cats, so she can easily check 
 * on their characteristics. Ginka has 3 specific breeds of cats: “Siamese”, “Cymric” and the very famous bulgarian 
 * breed “Street Extraordinaire”. Each breed has a specific characteristic about which information should be kept. 
 * For the Siamese cats their ear size should be kept, for Cymric cats - the length of their fur in centimeters and for
 * the Street Extraordinaire - the decibels of their meowing during the night.
 * 
 * From the console you will receive lines of information with cats. Until the command “End” is received, the information
 * will come in one of the following formats:
 * •   “Siamese <name> <earSize>”
 * •   “Cymric <name> <furLength>”
 * •   “StreetExtraordinaire <name> <decibelsOfMeows>”
 * 
 * On the last line after the “End” command you will receive the name of a cat. You should print that cat’s information
 * in the same format in which you received it (with fur size being formated to two decimal places after the separator).
 * 
 * Constraints
 * •   Ear size and decibels will always be positive integers
 * •   Cat names are unique
 * 
 * Example
 * Input:                                Output
 * StreetExtraordinaire Maca 85          Cymric Top 2.80
 * Siamese Sim 4
 * Cymric Tom 2.80
 * End
 * Tom
 * 
 * Input:                                Output:
 * StreetExtraordinaire Koti 80          StreetExtraordinaire Maca 100
 * StreetExtraordinaire Maca 100
 * Cymric Tim 3.10
 * End
 * Maca
 * 
 * Hint
 * Use class inheritance to represent the cat hierarchy and override the ToString() methods of concrete breeds to allow 
 * for easy printing of the cat, regardless the breed.
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Cat> cats = new List<Cat>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            Cat currentCat = GetCatInfo(input);
            cats.Add(currentCat);
        }

        string resultCat = Console.ReadLine();
        Console.WriteLine(cats.Where(x => x.Name == resultCat).Select(x => x).First());
    }

    private static Cat GetCatInfo(string input)
    {
        string[] catArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

        if (catArgs[0] == "Siamese")
        {
            Cat siameseCat = new Siamese(catArgs[1], int.Parse(catArgs[2]));
            return siameseCat;
        }
        else if (catArgs[0] == "StreetExtraordinaire")
        {
            Cat strExtraCat = new StreetExtraordinaire(catArgs[1], int.Parse(catArgs[2]));
            return strExtraCat;
        }
        else if (catArgs[0] == "Cymric")
        {
            Cat cymricCat = new Cymric(catArgs[1], decimal.Parse(catArgs[2]));
            return cymricCat;
        }

        throw new ArgumentException("Invalid cat breed.");
    }
}
