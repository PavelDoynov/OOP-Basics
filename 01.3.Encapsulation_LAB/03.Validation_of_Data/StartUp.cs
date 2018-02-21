/*
 * 03. Validation of Data
 * 
 * Expand Person with proper validation for every field:
 * •   Names must be at least 3 symbols
 * •   Age must not be zero or negative
 * •   Salary can't be less than 460.0 
 * 
 * Print proper messages to the user:
 * •   “Age cannot be zero or a negative integer!”
 * •   “First name cannot contain fewer than 3 symbols!”
 * •   “Last name cannot contain fewer than 3 symbols!”
 * •   “Salary cannot be less than 460 leva!”
 * 
 * Use ArgumentExeption with messages from example.
 * 
 * Example
 * Input:                             Output:
 * 5                                  Age cannot be zero or a negative integer!
 * Asen Ivanov -6 2200                First name cannot contain fewer than 3 symbols!
 * B Borisov 57 3333                  Last name cannot contain fewer than 3 symbols!
 * Ventsislav Ivanov 27 600           Salary cannot be less than 460 leva!
 * Asen H 44 666.66                   Ventsislav Ivanov gets 660.00 leva.
 * Boiko Angelov 35 300
 * 20
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

        decimal percentage = decimal.Parse(Console.ReadLine());

        persons.ForEach(x => x.IncreaseSalary(percentage));
        persons.ForEach(x => Console.WriteLine(x));
    }
}