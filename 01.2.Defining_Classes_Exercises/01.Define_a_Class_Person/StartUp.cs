/*
 * 01. Define a Class Person
 * 
 * Define a class Person with private fields for name and age and public properties Name and Age.
 * 
 * Bonus*
 * Try to create a few objects of type Person:
 * 
 * Name    Age
 * Pesho   20
 * Gosho   18
 * Stamat  43
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Person person1 = new Person();
        person1.Name = "Pesho";
        person1.Age = 20;

        Person person2 = new Person();
        person2.Name = "Gosho";
        person2.Age = 18;

        Person person3 = new Person();
        person3.Name = "Stamat";
        person3.Age = 43;

    }
}
