/*
 * 09. Rectangle Intersection
 * 
 * Create a class Rectangle. It should consist of an id, width, height and the coordinates of its top left corner 
 * (horizontal and vertical). Create a method which receives as a parameter another Rectangle, checks if the two 
 * rectangles intersect and returns true or false.
 * 
 * On the first line you will receive the number of rectangles – N and the number of intersection checks – M.
 * On the next N lines, you will get the rectangles with their id, width, height and coordinates. On the last M lines,
 * you will get pairs of ids which represent rectangles. Print if each of the pairs intersect.
 * 
 * You will always receive valid data. There is no need to check if a rectangle exists.
 * 
 * Example
 * Input:            Output:
 * 2 1               true
 * Pesho 2 2 0 0
 * Gosho 2 2 0 0
 * Pesho Gosho
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] inputArgs = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

        List<Rectangle> data = new List<Rectangle>();

        while (inputArgs[0] != 0)
        {
            string[] input = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Rectangle currentRectangleInfo = new Rectangle(input[0], double.Parse(input[1]), 
                                                           double.Parse(input[2]), double.Parse(input[3]), double.Parse(input[4]));

            data.Add(currentRectangleInfo);

            inputArgs[0]--;
        }

        while (inputArgs[1] != 0)
        {
            string[] pairs = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Rectangle currentRecangle = data.Where(x => x.Id == pairs[0]).First();

            currentRecangle.IsThereIntersection(data.Where(x => x.Id == pairs[1]).First());

            inputArgs[1]--;
        }
    }

}
