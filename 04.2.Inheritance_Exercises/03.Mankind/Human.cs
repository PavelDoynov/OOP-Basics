using System;

public class Human
{
    string firstName;
    string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }
        protected set
        {
            Validation.ValidateFirstName(value);
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        protected set 
        {
            Validation.ValidateLastName(value);
            lastName = value;
        }
    }
}