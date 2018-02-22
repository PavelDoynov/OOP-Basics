using System;

public class Box
{
    double surfaceArea;
    double lateralSurfaceArea;
    double volume;

    public double SurfaceArea
    {
        get { return surfaceArea; }
        private set { surfaceArea = value; }
    }

    public double LateralSurfaceArea 
    {
        get { return lateralSurfaceArea; }
        private set { lateralSurfaceArea = value; }
    }

    public double Volume
    {
        get { return volume; } 
        private set { volume = value; }
    }

    public Box (double length, double width, double height)
    {
        volume = length * width * height;
        lateralSurfaceArea = 2 * length * height + 2 * width * height;
        surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;
    }
}