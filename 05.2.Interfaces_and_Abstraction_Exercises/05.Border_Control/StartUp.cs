/*
 * 05. Border Control
 * 
 * It’s the future, you’re the ruler of a totalitarian dystopian society inhabited by citizens and robots, since you’re 
 * afraid of rebellions you decide to implement strict control of who enters your city. Your soldiers check the Ids of 
 * everyone who enters and leaves.
 * 
 * You will receive an unknown amount of lines from the console until the command “End” is received, on each line there
 * will be a piece of information for either a citizen or a robot who tries to enter your city in the 
 * format “<name> <age> <id>” for citizens and “<model> <id>” for robots. After the end command on the next line you will 
 * receive a single number representing the last digits of fake ids, all citizens or robots whose Id ends with the 
 * specified digits must be detained.
 * 
 * The output of your program should consist of all detained Ids each on a separate line in the order of input.
 * 
 * Input
 * The input comes from the console. Every commands’ parameters before the command “End” will be separated by a 
 * single space.
 * 
 * Example
 * Input:                   Output:                  Input:                     Output:
 * Pesho 22 9010101122      9010101122               Toncho 31 7801211340       7801211340
 * MK-13 558833251          33283122                 Penka 29 8007181534
 * MK-12 33283122                                    IV-228 999999
 * End                                               Stamat 54 3401018380
 * 122                                               KKK-666 80808080
 *                                                   End
 *                                                   340
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Society> society = GetSocietyList();

        string fakeIdNumbers = Console.ReadLine();
        society.ForEach(c => c.PrintFakeID(fakeIdNumbers));
    }

    private static List<Society> GetSocietyList()
    {
        List<Society> society = new List<Society>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (inputArgs.Length == 2)
            {
                society.Add(new Robot(inputArgs[0], inputArgs[1]));
            }
            else if (inputArgs.Length == 3)
            {
                society.Add(new Human(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]));
            }
        }
        return society;
    }
}