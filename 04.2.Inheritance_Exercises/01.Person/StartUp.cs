﻿/*
 * 01. Person
 * 
 * You are asked to model an application for storing data about people. You should be able to have a person and a child. 
 * The child is derived of the person. Your task is to model the application. The only constraints are:
 * -   People should not be able to have negative age
 * -   Children should not be able to have age more than 15.
 * 
 * •   Person – represents the base class by which all others are implemented
 * •   Child - represents a class which is derived by the Person.
 * 
 * https://github.com/PavelDoynov
 */


using System;

class Program
{
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

       try
        {
            Child child = new Child(name, age);

            Console.WriteLine(child);
        }
        catch (Exception exArgs)
        {
            Console.WriteLine(exArgs.Message);
        }
    }
}