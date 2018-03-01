/*
 * 06. Animals
 * 
 * Create a hierarchy of Animals. Your program should have 3 different animals – Dog, Frog and Cat. Deeper in the hierarchy
 * you should have two additional classes – Kitten and Tomcat. Kittens are female and Tomcats are male!
 * 
 * All types of animals should be able to produce some kind of sound (ProduceSound()). For example, the dog should be able
 * to bark.
 * 
 * Your task is to model the hierarchy and test its functionality. Create an animal of each kind and make them all produce
 * sound.
 * 
 * You will be given some lines of input. Each two lines will represent an animal. On the first line will be the type of 
 * animal and on the second – the name, the age and the gender. When the command "Beast!" is given, stop the input and 
 * print all the animals in the format shown below.
 * 
 * Output
 * •   Print the information for each animal on three lines. On the first line, print: "<AnimalType>"
 * •   On the second line print: "<Name> <Age> <Gender>"
 * •   On the third line print the sounds it produces: "<ProduceSound()>"
 * 
 * Constraints
 * •   Each Animal should have a name, an age and a gender
 * •   All input values should not be blank (e.g. name, age and so on…)
 * •   If you receive an input for the gender of a Tomcat or a Kitten, ignore it but create the animal
 * •   If the input is invalid for one of the properties, throw an exception with message: "Invalid input!"
 * •   Each animal should have the functionality to ProduceSound()
 * •   Here is the type of sound each animal should produce:
 *     o   Dog: "Woof!"
 *     o   Cat: "Meow meow"
 *     o   Frog: "Ribbit"
 *     o   Kittens: "Meow"
 *     o   Tomcat: "MEOW"
 * 
 * Example
 * Input:               Output:                  Input:               Output:
 * Cat                  Cat                      Frog                 Frog 
 * Tom 12 Male          Tom 12 Male              Kermit 12 Male       Kermit 12 Male
 * Dog                  Meow meow                Beast!               Ribbit
 * Sharo 132 Male       Dog
 * Beast!               Sharo 132 Male
 *                      Woof!
 * 
 * Input:               Output:
 * Frog                 Invalid input!
 * Sashko -2 Male       Frog
 * Frog                 Sashko 2 Male
 * Sashko 2 Male        Ribbit
 * Beast!
 * 
 * Bonus
 * Create an interface ISoundProducable and implement it in the Animal class.
 * 
 * https://github.com/PavelDoynov
 */

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Animal> animals = GetAnimals();

        animals.ForEach(a => Console.WriteLine(a));
    }

    private static List<Animal> GetAnimals()
    {
        List<Animal> animals = new List<Animal>();

        string inputType;
        while ((inputType = Console.ReadLine().ToLower()) != "beast!")
        {
            string[] typeArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = typeArgs[0];
            int age = int.Parse(typeArgs[1]);
            string gender = typeArgs[2];

            try
            {
                if (inputType == "cat")
                {
                    animals.Add(new Cat(name, age, gender));
                }
                else if (inputType == "dog")
                {
                    animals.Add(new Dog(name, age, gender));
                }
                else if (inputType == "frog")
                {
                    animals.Add(new Frog(name, age, gender));
                }
                else if (inputType == "tomcat")
                {
                    animals.Add(new Tomcat(name, age));
                }
                else if (inputType == "kitten")
                {
                    animals.Add(new Kitten(name, age));
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            catch (Exception exArgs)
            {
                Console.WriteLine(exArgs.Message);
            }
        }

        return animals;
    }
}