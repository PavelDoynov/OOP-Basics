/*
 * 06. Birthday Celebrations
 * 
 * It is a well known fact that people celebrate birthdays, it is also known that some people also celebrate their pets’ 
 * birthdays. Extend the program from your last task to add birthdates to citizens and include a class Pet, pets have a 
 * name and a birthdate. Encompass repeated functionality into interfaces and implement them in your classes. 
 * 
 * You will receive from the console an unknown amount of lines. Until the command “End” is received, each line will 
 * contain information in one of the following formats “Citizen <name> <age> <id> <birthdate>” for citizens,
 * “Robot <model> <id>” for robots or “Pet <name> <birthdate>” for pets. After the “End” command on the next line you will
 * receive a single number representing a specific year, your task is to print all birthdates (of both citizens and pets) 
 * in that year in the format day/month/year in the order of input.
 * 
 * Example
 * Input:                                        Output:
 * Citizen Pesho 22 9010101122 10/10/1990        10/10/1990
 * Pet Sharo 13/11/2005
 * Robot MK-13 558833251
 * End
 * 1990
 * 
 * Input:                                        Output:
 * Citizen Stamat 16 0041018380 01/01/2000       01/01/2000
 * Robot MK-10 12345678                          24/12/2000
 * Robot PP-09 00000001
 * Pet Topcho 24/12/2000
 * Pet Kosmat 12/06/2002 
 * End
 * 2000
 * 
 * Input:                                        Output:
 * Robot VV-XYZ 11213141                         <empty output>
 * Citizen Penka 35 7903210713 21/03/1979
 * Citizen Kane 40 7409073566 07/09/1974
 * End
 * 1975
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
        List<Society> society = GetSocietyList();

        string birthdateYear = Console.ReadLine();
        society.ForEach(c => c.PrintValidBirthdate(birthdateYear)); 
    }

    private static List<Society> GetSocietyList()
    {
        List<Society> society = new List<Society>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (inputArgs[0] == "Citizen")
            {
                society.Add(new Human(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]));
            }
            else if (inputArgs[0] == "Pet")
            {
                society.Add(new Pet(inputArgs[1], inputArgs[2]));
            }
        }
        return society;
    }
}