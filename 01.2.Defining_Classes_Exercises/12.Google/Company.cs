using System;

public class Company
{
    public string company;
    public string department;
    public decimal salary;

    public Company(string company, string department, decimal salary)
    {
        this.company = company;
        this.department = department;
        this.salary = salary;
    }

    public override string ToString()
    {
        return $"{company} {department} {salary:f2}";
    }
}
