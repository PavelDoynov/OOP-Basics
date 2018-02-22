/*
 * 04. Shopping Spree
 * 
 * Create two classes: class Person and class Product. Each person should have a name, money and a bag of products. 
 * Each product should have name and cost. Name cannot be an empty string. Money cannot be a negative number. 
 * 
 * Create a program in which each command corresponds to a person buying a product. If the person can afford a product
 * add it to his bag. If a person doesn’t have enough money, print an appropriate message 
 * ("[Person name] can't afford [Product name]").
 * 
 * On the first two lines you are given all people and all products. After all purchases print every person in the order
 * of appearance and all products that he has bought also in order of appearance. If nothing is bought, print the name 
 * of the person followed by "Nothing bought". 
 * 
 * In case of invalid input (negative money exception message: "Money cannot be negative") or empty name
 * (empty name exception message: "Name cannot be empty") break the program with an appropriate message. See the examples
 * below:
 * 
 * Example
 * Input:                 Output:                               Input:                 Output:
 * Pesho=11;Gosho=4       Pesho bought Bread                    Mimi=0                 Mimi can't afford Kafence
 * Bread=10;Milk=2;       Gosho bought Milk                     Kafence=2              Mimi – Nothing bought
 * Pesho Bread            Gosho bought Milk                     Mimi Kafence
 * Gosho Milk             Pesho can't afford Milk               END
 * Gosho Milk             Pesho - Bread
 * Pesho Milk             Gosho - Milk, Milk
 * END
 * 
 * Input:                 Output:
 * Jeko=-3                Money cannot be negative
 * Chushki=1;
 * Jeko Chushki
 * END
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
        try
        {
            List<Person> persons = GetPersons();
            List<Product> products = GetProducts();

            Buying(persons, products);

            foreach (var personResultInfo in persons)
            {
                Console.Write($"{personResultInfo.Name} - ");
                if (personResultInfo.Products.Count() == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", personResultInfo.Products));
                }
            }
        }
        catch (Exception exArgs)
        {
            Console.WriteLine(exArgs.Message);
        }
    }

    private static void Buying(List<Person> persons, List<Product> products)
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] buyingArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            persons.First(p => p.Name == buyingArgs[0]).BuyingProducts(products.First(p => p.Name == buyingArgs[1]));
        }
    }

    private static List<Product> GetProducts()
    {
        List<Product> products = new List<Product>();

        string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        foreach (var product in productsInput)
        {
            string[] productsArgs = product.Split('=');
            products.Add(new Product(productsArgs[0], decimal.Parse(productsArgs[1])));
        }

        return products;
    }

    private static List<Person> GetPersons()
    {
        List<Person> persons = new List<Person>();

        string[] personsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

        foreach (var person in personsInput)
        {
            string[] personArgs = person.Split('=');
            persons.Add(new Person(personArgs[0], decimal.Parse(personArgs[1])));
        }

        return persons;
    }
}