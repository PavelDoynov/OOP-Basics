using System;

public interface ICar
{
    string Model { get; }
    string Driver { get; }
    string Start();
    string Stop();
}