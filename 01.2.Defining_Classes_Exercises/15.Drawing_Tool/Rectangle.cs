using System;

public class Rectangle
{
    private int Height
    {
        get;
        set;
    }

    private int Width
    {
        get;
        set;
    }

    public Rectangle ()
    {
        Width = int.Parse(Console.ReadLine());
        Height = int.Parse(Console.ReadLine());
    }

    public void DrawingRectangle()
    {
        Console.WriteLine($"|{new string('-', Width)}|");
        for (int i = 0; i < Height - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', Width)}|");
        }
        Console.WriteLine($"|{new string('-', Width)}|");
    }
}
