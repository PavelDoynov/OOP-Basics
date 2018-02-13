/*
 * 03. Oldest Family Member
 * 
 * Use your Person class from the previous tasks. Create a class Family. The class should have list of people, a method 
 * for adding members (void AddMember(Person member)) and a method returning the oldest family 
 * member (Person GetOldestMember()). Write a program that reads the names and ages of N people and adds them to the family.
 * Then print the name and age of the oldest member.
 * 
 * Example
 * Input:      Output:             Input:               Output:
 * 3           Annie 5             5                    Ivan 35
 * Pesho 3                         Steve 10
 * Gosho 4                         Christopher 15
 * Annie 5                         Annie 4
 *                                 Ivan 35
 *                                 Maria 34
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
        List<Person> data = new List<Person>();

        int returns = int.Parse(Console.ReadLine());

        while (returns != 0)
        {
            string[] input = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Person currentPerson = new Person();
            currentPerson.Name = input[0];
            currentPerson.Age = int.Parse(input[1]);

            data.Add(currentPerson);

            returns --;
        }

        GetOldestPerson(data);
    }

    private static void GetOldestPerson(List<Person> data)
    {
        data = data.OrderByDescending(x => x.Age).ToList();
        Console.WriteLine($"{data[0]}");
    }
}
