using System;

public class Worker:Human
{
    private const decimal WORKING_DAYS_IN_WEEK = 5;
    decimal weekSalary;
    double workingHours;

    public Worker(string firstName, string lastName, decimal weekSalary, double workingHours)
        :base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkingHours = workingHours;
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        private set
        {
            Validation.ValidateWeekSalary(value);
            weekSalary = value;
        }
    }

    public double WorkingHours
    {
        get { return workingHours; }
        private set
        {
            Validation.ValidateWorkingHours(value);
            workingHours = value;
        }
    }

    private decimal SalaryPerHour()
    {
        return this.WeekSalary / ((decimal)workingHours * WORKING_DAYS_IN_WEEK);
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}\nLast Name: {LastName}\n" +
            $"Week Salary: {WeekSalary:f2}\nHours per day: {WorkingHours:f2}\nSalary per hour: {SalaryPerHour():f2}";
    }
}