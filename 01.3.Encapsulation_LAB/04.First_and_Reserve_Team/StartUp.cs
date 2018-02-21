/*
 * 04. First and Reserve Team
 * 
 * Create a Team class. Add to this team all people you read. All people younger than 40 go on the first team, others go 
 * on the reverse team. At the end print the first and reserve team sizes.
 * 
 * The class should have private fields for:
 * •   name: string
 * •   firstTeam: List<Person>
 * •   reserveTeam: List<Person>
 * 
 * The class should have constructors:
 * •   Team(string name)
 * 
 * The class should also have public properties for:
 * •   FirstTeam: List<Person> (read only!)
 * •   ReserveTeam: List<Person> (read only!)
 * 
 * And a method for adding players:
 * •   AddPlayer(Person person): void
 * 
 * Example
 * Input:                             Output;
 * 5                                  First team has 4 players.
 * Asen Ivanov 20 2200                Reserve team has 1 players.
 * Boiko Borisov 57 3333
 * Ventsislav Ivanov 27 600
 * Grigor Dimitrov 25 666.66
 * Boiko Angelov 35 555
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        int numberOfInputs = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        while (numberOfInputs != 0)
        {
            string[] inputArgs = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

            try
            {
                Person currentPerson = new Person(inputArgs[0], inputArgs[1], int.Parse(inputArgs[2]),
                                              decimal.Parse(inputArgs[3]));

                persons.Add(currentPerson);
            }
            catch (Exception exArgs)
            {
                Console.WriteLine(exArgs.Message);
            }

            numberOfInputs--;
        }

        Team team = new Team("SoftUni");

        foreach (var person in persons)
        {
            team.AddPlayer(person);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count()} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count()} players.");
    }
}