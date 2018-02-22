/*
 * 01. Class Box
 * 
 * You are given a geometric figure box with parameters length, width and height. Model a class Box that that can be 
 * instantiated by the same three parameters. Expose to the outside world only methods for its surface area, lateral 
 * surface area and its volume (formulas: http://www.mathwords.com/r/rectangular_parallelepiped.htm).
 * 
 * On the first three lines you will get the length, width and height. On the next three lines print the surface area, 
 * lateral surface area and the volume of the box:
 * 
 * Example
 * Input:      Output:                                   Input:      Output:
 * 2           Surface Area – 52.00                      1.3         Surface Area - 30.20
 * 3           Lateral Surface Area – 40.00              1           Lateral Surface Area - 27.60
 * 4           Volume – 24.00                            6           Volume - 7.80
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

        Box box = new Box(length, width, height);

        Console.WriteLine($"Surface Area - {box.SurfaceArea:f2}");
        Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea:f2}");
        Console.WriteLine($"Volume - {box.Volume:f2}");

    }
}