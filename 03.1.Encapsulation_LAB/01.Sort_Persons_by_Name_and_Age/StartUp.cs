/*
 * 01. Sort Persons by Name and Age
 *
 * Create a class Person, which should have private fields for:
 * •   firstName: string
 * •   lastName: string
 * •   age: int
 * •   ToString(): string - override
 * 
 * Example
 * Input:                      Output:
 * 5                           Asen Harizanoov is 44 years old.
 * Asen Ivanov 65              Asen Ivanov is 65 years old.
 * Boiko Borisov 57            Boiko Angelov is 35 years old.
 * Ventsislav Ivanov 27        Boiko Borisov is 57 years old.
 * Asen Harizanoov 44          Ventsislav Ivanov is 27 years old.
 * Boiko Angelov 35
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
        int numberOfInputs = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        while (numberOfInputs != 0)
        {
            string[] inputArgs = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

            Person currentPerson = new Person(inputArgs[0], inputArgs[1], int.Parse(inputArgs[2]));

            persons.Add(currentPerson);
            numberOfInputs--;
        }

        persons.OrderBy(p => p.FirstName)
               .ThenBy(p => p.Age)
               .ToList()
               .ForEach(p => Console.WriteLine(p));

    }
}