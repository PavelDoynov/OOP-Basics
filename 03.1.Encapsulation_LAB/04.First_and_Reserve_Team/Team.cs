using System;
using System.Collections.Generic;

public class Team
{
    string name;
    List<Person> firstTeam = new List<Person>();
    List<Person> reserveTeam = new List<Person>();

    public List<Person> FirstTeam
    {
        get { return firstTeam; }
    }

    public List<Person> ReserveTeam
    {
        get { return reserveTeam; }
    }

    public Team(string name)
    {
        this.name = name;
    }

    public void AddPlayer (Person person)
    {
        if (person.Age < 40)
        {
            this.firstTeam.Add(person);
        }
        else
        {
            this.reserveTeam.Add(person);
        }
    }
}