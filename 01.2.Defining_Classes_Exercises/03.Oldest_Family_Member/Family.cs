using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    List<Person> data = new List<Person>();

    public Person AddPerson
    {
        set { this.data.Add(value);}
    }

    public override string ToString()
    {
        Person result = new Person();
        result = GetOldestPerson(data);
        return $"{result.Name} {result.Age}";
    }

    private static Person GetOldestPerson(List<Person> data)
    {
        data = data.OrderByDescending(x => x.Age).ToList();
        Person result = new Person();
        return result = data[0];
    }
}
