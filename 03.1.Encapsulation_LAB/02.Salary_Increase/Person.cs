﻿using System;
using System.Linq;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.age > 30)
        {
            this.salary += this.salary * (percentage / 100);
        }
        else
        {
            this.salary += this.salary * (percentage / 200);
        }
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} receives {salary:f2} leva.";
    }
}