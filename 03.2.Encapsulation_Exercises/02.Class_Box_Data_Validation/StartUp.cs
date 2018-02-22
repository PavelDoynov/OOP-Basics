/*
 * 02. Class Box Data Validation
 * 
 * A box’s side should not be zero or a negative number. Expand your class from the previous problem by adding data 
 * validation for each parameter given to the constructor. Make a private setter that performs data validation internally.
 * 
 * Example
 * Input:         Output:
 * 2              Width cannot be zero or negative. 
 * -3
 * 4
 * 
 * https://github.com/PavelDoynov
 */


using System;

class Program
{
    static void Main()
    {

        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Box box = new Box(length, width, height);

            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
        catch (Exception exArgs)
        {
            Console.WriteLine(exArgs.Message);
        }
    }
}