using System;

public class Student:Human
{
    string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        :base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        private set
        {
            Validation.ValidateFacultyNumber(value);
            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}\nLast Name: {LastName}\nFaculty number: {FacultyNumber}";
    }
}