using System;
using System.Linq;

public class Validation
{
    private const int MIN_FIRSTNAME_LENGTH = 3;
    private const int MIN_LASTNAME_LENGTH = 2;
    private const int MIN_FACULTYNUMBER_LENGTH = 5;
    private const int MAX_FACULTYNUMBER_LENGTH = 10;
    private const decimal MIN_WEEK_SALARY = 10;
    private const double MIN_WORKING_HOURS = 1;
    private const double MAX_WORKING_HOURS = 12;

    public static void ValidateFirstName(string firstName)
    {
        if (char.IsLower(firstName[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: firstName");
        }

        if (firstName.Length <= MIN_FIRSTNAME_LENGTH)
        {
            throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
        }
    }

    public static void ValidateLastName(string lastName)
    {
        if (char.IsLower(lastName[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: lastName");
        }

        if (lastName.Length <= MIN_LASTNAME_LENGTH)
        {
            throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
        }
    }

    public static void ValidateFacultyNumber(string facultyNumber)
    {
        if (facultyNumber.Length < MIN_FACULTYNUMBER_LENGTH || 
            facultyNumber.Length > MAX_FACULTYNUMBER_LENGTH || !IsValidFacultyNumber(facultyNumber))
        {
            throw new ArgumentException("Invalid faculty number!");
        }
    }

    private static bool IsValidFacultyNumber(string value)
    {
        bool isValidFacultyNumber = true;
        foreach (char ch in value)
        {
            if (!char.IsLetterOrDigit(ch))
            {
                isValidFacultyNumber = false;
            }
        }
        return isValidFacultyNumber;
    }

    public static void ValidateWeekSalary(decimal weekSalary)
    {
        if (weekSalary <= MIN_WEEK_SALARY)
        {
            throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
        }
    }

    public static void ValidateWorkingHours(double workingHours)
    {
        if (workingHours < MIN_WORKING_HOURS || workingHours > MAX_WORKING_HOURS)
        {
            throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
        }
    }
}