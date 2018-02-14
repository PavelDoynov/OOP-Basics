/*
 * 04. Opinion Poll
 * 
 * Using the Person class, write a program that reads from the console N lines of personal information and then prints 
 * all people whose age is more than 30 years, sorted in alphabetical order.
 * 
 * Example
 * Input:        Output:                   Input:           Output:
 * 3             Ivan - 48                 5                Lyubo 44
 * Pesho 12      Stamat - 31               Nikolai 33       Nikolai 33
 * Stamat 31                               Yordan 88        Yordan 88
 * Ivan 48                                 Tosho 22
 *                                         Lyubo 44
 *                                         Stanislav 11
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

        List<Person> data = new List<Person>();

        while (numberOfInputs != 0)
        {
            string[] input = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Person currentPerson = new Person();
            currentPerson.Name = input[0];
            currentPerson.Age = int.Parse(input[1]);

            data.Add(currentPerson);

            numberOfInputs--;
        }

        foreach (var person in data.Where(x => x.Age > 30).OrderBy(x => x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}