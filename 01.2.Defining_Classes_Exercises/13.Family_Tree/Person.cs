using System;
using System.Collections.Generic;
using System.Linq;


public class Person
{


    public string personName
    {
        get;
        set;
    }

    public string personBirthDate
    {
        get;
        set;
    }

    public Person()
    {
        
    }

    public Person(string personInfo)
    {
        if (personInfo.Contains("/"))
        {
            personBirthDate = personInfo;
        }
        else 
        {
            personName = personInfo;
        }
    }

    public override string ToString()
    {
        return $"{personName} {personBirthDate}";
    }

}
