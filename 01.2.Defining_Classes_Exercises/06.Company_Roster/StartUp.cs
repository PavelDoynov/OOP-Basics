/*
 * 06. Company Roster
 * 
 * Define a class Employee that holds the following information: name, salary, position, department, email and age.
 * The name, salary, position and department are mandatory while the rest are optional. 
 * 
 * Your task is to write a program which takes N lines of employees from the console and calculates the department with the
 * highest average salary and prints for each employee in that department his name, salary, email and age – sorted by 
 * salary in descending order. If an employee doesn’t have an email – in place of that field you should print “n/a” instead,
 * if he doesn’t have an age – print “-1” instead. The salary should be printed to two decimal places after the seperator.
 * 
 * Example
 * Input:                                                            Output:
 * 4                                                                 Highest Average Salary: Development
 * Pesho 120.00 Dev Development pesho@abv.bg 28                      Ivan 840.20 ivan@ivan.com -1
 * Toncho 333.33 Manager Marketing 33                                Pesho 120.00 pesho@abv.bg 28
 * Ivan 840.20 ProjectLeader Development ivan@ivan.com
 * Gosho 0.20 Freeloader Nowhere 18
 * 
 * Input:                                                            Output:
 * 6                                                                 Highest Average Salary: Sales
 * Stanimir 496.37 Temp Coding stancho@yahoo.com                     Yovcho 610.13 n/a -1
 * Yovcho 610.13 Manager Sales                                       Toshko 609.99 toshko@abv.bg 44
 * Toshko 609.99 Manager Sales toshko@abv.bg 44
 * Venci 0.02 Director BeerDrinking beer@beer.br 23
 * Andrei 700.00 Director Coding
 * Popeye 13.3333 Sailor SpinachGroup popeye@pop.ey
 * 
 * https://github.com/PavelDoynov
 */



using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int numberOfInput = int.Parse(Console.ReadLine());

        Dictionary<string, decimal> dataForSorting = new Dictionary<string, decimal>();
        List<Employee> data = new List<Employee>();

        while (numberOfInput != 0)
        {
            string[] input = Console.ReadLine()
                                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .ToArray();

            Employee currentEmployee = new Employee();
            currentEmployee.Name = input[0];
            currentEmployee.Salary = decimal.Parse(input[1]);
            currentEmployee.Department = input[3];

            if (input.Length == 6)
            {
                currentEmployee.Email = input[4];
                currentEmployee.Age = int.Parse(input[5]);
            }
            else if (input.Length == 5)
            {
                try
                {
                    currentEmployee.Age = int.Parse(input[4]);
                }
                catch (Exception )
                {
                    currentEmployee.Email = input[4];
                }
            }

            data.Add(currentEmployee);

            if (dataForSorting.ContainsKey(input[3]))
            {
                dataForSorting[input[3]] += decimal.Parse(input[1]);
            }
            else
            {
                dataForSorting[input[3]] = decimal.Parse(input[1]);
            }

            numberOfInput--;
        }

        string department = dataForSorting.OrderByDescending(x => x.Value).Select(x => x.Key).First();

        Console.WriteLine($"Highest Average Salary: {department}");

        foreach (var employee in data.Where(x => x.Department == department).OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}