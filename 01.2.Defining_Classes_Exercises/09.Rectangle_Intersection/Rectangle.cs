using System;

public class Rectangle
{
    string id;
    double width;
    double height;
    double row;
    double col;

    public string Id
    {
        get { return id; }
    }

    public Rectangle(string id, double width, double height, double row, double col)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.row = row;
        this.col = col;
    }

    public void IsThereIntersection(Rectangle rectangle)
    {
        if (rectangle.row + rectangle.width >= this.row && rectangle.row <= this.row + this.width
            && rectangle.col >= this.col - this.height && rectangle.col - rectangle.height <= this.col)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}
