/*
 * 2. Salary Increase
 * 
 * Refactor project from last task.
 * Read person with their names, age and salary. Read percent bonus to every person salary. People younger than 30 get
 * half the increase. Expand Person from the previous task.
 * New fields and methods:
 * •   salary: decimal 
 * •   IncreaseSalary(decimal percentage)
 * 
 * Example
 * Input:                           Output:
 * 5                                Asen Ivanov receives 2640.00 leva.
 * Asen Ivanov 65 2200              Boiko Borisov receives 3999.60 leva.
 * Boiko Borisov 57 3333            Ventsislav Ivanov receives 660.00 leva.
 * Ventsislav Ivanov 27 600         Asen Harizanoov receives 799.99 leva.
 * Asen Harizanoov 44 666.66        Boiko Angelov receives 671.28 leva.
 * Boiko Angelov 35 559.4
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

            Person currentPerson = new Person(inputArgs[0], inputArgs[1], int.Parse(inputArgs[2]), 
                                              decimal.Parse(inputArgs[3]));

            persons.Add(currentPerson);
            numberOfInputs--;
        }

        decimal percentage = decimal.Parse(Console.ReadLine());

        persons.ForEach(x => x.IncreaseSalary(percentage));
        persons.ForEach(x => Console.WriteLine(x));
    }
}
