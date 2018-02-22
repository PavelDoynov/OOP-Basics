using System;

public class Box
{
    double length;
    double width;
    double height;

    private double Length
    {
        get { return length; }
        set 
        {
            if (value > 0)
            {
                length = value;
            }
            else
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
        }
    }

    private double Width
    {
        get { return width; }
        set
        {
            if (value > 0)
            {
                width = value;
            }
            else
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
        }
    }

    private double Height
    {
        get { return height; }
        set
        {
            if (value > 0)
            {
                height = value;
            }
            else
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
        }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double SurfaceArea ()
    {
        return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height; 
    }

    public double LateralSurfaceArea()
    {
        return 2 * Length * Height + 2 * Width * Height; 
    }

    public double Volume()
    {
        return Length * Width * Height; 
    }

}