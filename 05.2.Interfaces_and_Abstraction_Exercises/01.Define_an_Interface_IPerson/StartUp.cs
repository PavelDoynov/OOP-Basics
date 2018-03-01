/*
 * 01. Define an Interface IPerson
 * 
 * Define an interface IPerson with properties for Name and Age. Define a class Citizen which implements IPerson and has 
 * a constructor which takes a string name and an int age.
 * 
 * Try to create a new Person like this:
 *   string name = Console.ReadLine();
 *   int age = int.Parse(Console.ReadLine());
 *   IPerson person = new Citizen(name, age);
 *   Console.WriteLine(person.Name);
 *   Console.WriteLine(person.Age);
 * 
 * Example
 * Input:       Output:
 * Pesho        Pesho
 * 25           25
 * 
 * https://github.com/PavelDoynov
 */


using System;

class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        IPerson person = new Citizen(name, age);
        Console.WriteLine($"{person.Name}");
        Console.WriteLine($"{person.Age}");
    }
}