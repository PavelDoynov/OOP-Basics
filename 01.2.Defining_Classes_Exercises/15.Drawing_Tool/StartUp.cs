/*
 * 15. Drawing Tool
 * 
 * You are a young programmer and your boss gave you a task to create a tool, which draws figures on the console. He knows
 * you are not too good at OOP tasks, so he told you to create a class - DrawingTool. Its task is to draw rectangular 
 * figures on the console.
 * 
 * DrawingTool’s constructor should take as a parameter a Square or a Rectangle object, extract its characteristics and
 * draw the figure. Like we said, your boss is a good guy and he has some more info for you:
 * 
 * One of the extra classes you will need should be a class named Square that should have only one method – Draw() which 
 * uses the length of the square’s sides and draws them on the console. For horizontal lines, use dashes ("-") and spaces
 * (" "). For vertical lines – pipes ("|"). If the size of the figure is 6, the dashes should also be 6.
 * 
 * Hint
 * Search in the internet for abstract classes and try implementing one. This will help you to reduce the input parameters
 * in the DrawingTool’s constructor to one.
 * 
 * Example
 * Input:      Output:               Input:         Output:
 * Square      |---|                 Rectangle      |-------|
 * 3           |   |                 7              |       |
 *             |---|                 3              |-------|
 * 
 * https://github.com/PavelDoynov
 */


using System;

class Program
{
    static void Main()
    {
        string figure = Console.ReadLine();

        if (figure == "Square")
        {
            Square square = new Square(Console.ReadLine());
            square.DrawingSquare();
        }
        else if (figure == "Rectangle")
        {
            Rectangle rectangle = new Rectangle();
            rectangle.DrawingRectangle();
        }
    }
}
