using System;

public class Square
{
    private int SizeSide
    {
        get;
        set;
    }

    public Square (string input)
    {
        SizeSide = int.Parse(input);
    }

    public void DrawingSquare ()
    {
        Console.WriteLine($"|{new string('-', SizeSide)}|");
        for (int i = 0; i < SizeSide - 2; i++)
        {
            Console.WriteLine($"|{new string(' ', SizeSide)}|");
        }
        Console.WriteLine($"|{new string('-', SizeSide)}|");
    }
}
