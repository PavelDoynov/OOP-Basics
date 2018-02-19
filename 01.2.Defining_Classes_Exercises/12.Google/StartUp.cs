/*
 * 12. Google
 * 
 * Google is always watching you, so it should come as no surprise that they know everything about you 
 * (even your pokemon collection). Since you’re really good at writing classes, Google asked you to design a class that 
 * can hold all the information they need for people.
 * 
 * From the console you will receive an unkown amount of lines until the command “End” is read. On each of those lines
 * there will be information about a person in one of the following formats:
 * •   “<Name> company <companyName> <department> <salary>”  
 * •   “<Name> pokemon <pokemonName> <pokemonType>”
 * •   “<Name> parents <parentName> <parentBirthday>”
 * •   “<Name> children <childName> <childBirthday>”
 * •   “<Name> car <carModel> <carSpeed>”
 * 
 * You should structure all information about a person in a class with nested subclasses. People’s names are 
 * unique - there won’t be 2 people with the same name. A person can also have only 1 company and car, but can have 
 * multiple parents, children and pokemons. After the command “End” is received, on the next line you will receive a 
 * single name. You should print all information about that person. Note that information can change during the 
 * input - for instance if we receive multiple lines which specify a person’s company, only the last one should be the one
 * remembered. The salary must be formated to two decimal places after the seperator.
 * 
 * Example
 * Input:                                                    Output:
 * PeshoPeshev company PeshInc Management 1000.00            TonchoTonchev
 * TonchoTonchev car Trabant 30                              Company:
 * PeshoPeshev pokemon Pikachu Electricity                   Car:
 * PeshoPeshev parents PoshoPeshev 22/02/1920                Trabant 30
 * TonchoTonchev pokemon Electrode Electricity               Pokemon:
 * End                                                       Electrode Electricity
 * TonchoTonchev                                             Parents:
 *                                                           Children:
 * 
 * Input:                                                    Output:
 * JelioJelev pokemon Onyx Rock                              JelioJelev
 * JelioJelev parents JeleJelev 13/03/1933                   Company:
 * GoshoGoshev pokemon Moltres Fire                          JeleInc Jelior 777.77
 * JelioJelev company JeleInc Jelior 777.77                  Car:
 * JelioJelev children PudingJelev 01/01/2001                AudiA4 180
 * StamatStamatov pokemon Blastoise Water                    Pokemon:
 * JelioJelev car AudiA4 180                                 Onyx Rock
 * JelioJelev pokemon Charizard Fire                         Charizard Fire
 * End                                                       Parents:
 * JelioJelev                                                JeleJelev 13/03/1933
 *                                                           Children:
 *                                                           PudingJelev 01/01/2001
 * 
 * Bonus*
 * Override the ToString() method in the classes to standardize the displaying of objects.
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Person> data = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

            if (!data.Any(x => x.name == inputArgs[0]))
            {
                data.Add(new Person(inputArgs[0]));
            }

            data = GetArgs(data, inputArgs);
        }

        string person = Console.ReadLine();
        Person currentPerson = data.Where(x => x.name == person).First();

        Print(currentPerson);
    }

    private static void Print(Person currentPerson)
    {
        Console.WriteLine(currentPerson.name);
        Console.WriteLine("Company:");
        if (currentPerson.compnany != null)
        {
            Console.WriteLine(currentPerson.compnany);
        }
        Console.WriteLine("Car:");
        if (currentPerson.car != null)
        {
            Console.WriteLine(currentPerson.car);
        }
        Console.WriteLine("Pokemon:");
        if (currentPerson.pokemons.Count() > 0)
        {
            foreach (var pokemon in currentPerson.pokemons)
            {
                Console.WriteLine(pokemon);
            }
        }
        Console.WriteLine("Parents:");
        if (currentPerson.parents.Count() > 0)
        {
            foreach (var parent in currentPerson.parents)
            {
                Console.WriteLine(parent);
            }
        }
        Console.WriteLine("Children:");
        if (currentPerson.childrens.Count() > 0)
        {
            foreach (var children in currentPerson.childrens)
            {
                Console.WriteLine(children);
            }
        }
    }

    private static List<Person> GetArgs(List<Person> data, string[] inputArgs)
    {
        Person currentPerson = data.Where(x => x.name == inputArgs[0]).First();
        if (inputArgs[1] == "company") 
        {
            currentPerson.compnany = new Company(inputArgs[2], inputArgs[3], decimal.Parse(inputArgs[4]));
        }
        else if (inputArgs[1] == "car")
        {
            currentPerson.car = new Car(inputArgs[2], int.Parse(inputArgs[3]));
        }
        else if (inputArgs[1] == "pokemon")
        {
            currentPerson.pokemons.Add(new Pokemon(inputArgs[2], inputArgs[3]));
        }
        else if (inputArgs[1] == "parents")
        {
            currentPerson.parents.Add(new Parents(inputArgs[2], inputArgs[3]));
        }
        else if (inputArgs[1] == "children")
        {
            currentPerson.childrens.Add(new Children(inputArgs[2], inputArgs[3]));
        }
        return data;
    }
}