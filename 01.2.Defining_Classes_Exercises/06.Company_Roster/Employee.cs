using System;
using System.Linq;

public class Employee
{

    string name;
    decimal salary;
    string department;
    string email;
    int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Employee()
    {
        this.email = "n/a";
        this.age = -1;
    }

    public Employee(string email) :this()
    {
        this.Email = email;
    }

    public Employee(string email, int age) : this(email)
    {
        this.Age = age;
    }
}
