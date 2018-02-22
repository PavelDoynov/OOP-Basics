/*
 * 03. Animal farm
 * 
 * You should be familiar with encapsulation already. For this problem, you’ll be working with the Animal Farm project. 
 * It contains a class Chicken. Chicken contains several fields, a constructor, several properties and several methods.
 * Your task is to encapsulate or hide anything that is not intended to be viewed or modified from outside the class.
 * 
 * Step 1. Encapsulate Fields
 * Fields should be private. Leaving fields open for modification from outside the class is potentially dangerous. 
 * Make all fields in the Chicken class private.
 * In case the value inside a field is needed elsewhere, use getters to reveal it.
 * 
 * Step 2. Ensure Classes Have a Correct State
 * Having getters and setters is useless if you don’t actually use them. The Chicken constructor modifies the fields 
 * directly which is wrong when there are suitable setters available. Modify the constructor to fix this issue.
 * 
 * Step 3. Validate Data Properly
 * Validate the chicken’s name (it cannot be null, empty or whitespace). In case of invalid name, print exception 
 * message: "Name cannot be empty." .
 * Validate the age properly, minimum and maximum age are provided, make use of them. In case of invalid age, print 
 * exception message: "Age should be between 0 and 15." .
 * 
 * Step 4. Hide Internal Logic
 * If a method is intended to be used only by descendant classes or internally to perform some action, there is no point
 * in keeping them public. The CalculateProductPerDay() method is used by the ProductPerDay public getter. This means the
 * method can safely be hidden inside the Chicken class by declaring it private.
 * 
 * Example
 * Input:       Output:
 * Mara         Chicken Mara (age 10) can produce 1 eggs per day.
 * 10
 * 
 * Input:       Output:
 * Mara         Age should be between 0 and 15.
 * 17
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

        try
        {
            Chicken chicken = new Chicken(name, age);
            Console.WriteLine(
                "Chicken {0} (age {1}) can produce {2} eggs per day.",
                chicken.Name,
                chicken.Age,
                chicken.ProductPerDay);
        }
        catch (Exception exArgs)
        {
            Console.WriteLine(exArgs.Message);
        }
    }
}
