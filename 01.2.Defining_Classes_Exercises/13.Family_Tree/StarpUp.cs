/*
 * 13. Family Tree
 * 
 * You want to build your family tree, so you went to ask your grandmother. Sadly, your grandmother keeps remembering 
 * information about your predecessors in pieces, so it falls to you to group the information and build the family tree.
 * 
 * On the first line of input you will receive either a name or a birthdate in the format “<FirstName> <LastName>” or 
 * “day/month/year” – your task is to find the person’s information in the family tree. On the next lines until the 
 * command “End” is received you will receive information about your predecessors that you will use to build the family tree.
 * 
 * The information will be in one of the following formats: 
 * •   “FirstName LastName - FirstName LastName”
 * •   “FirstName LastName - day/month/year”
 * •   “day/month/year - FirstName LastName”
 * •   “day/month/year - day/month/year”
 * •   “FirstName LastName day/month/year”
 * 
 * The first 4 formats reveal a family tie – the person on the left is parent to the person on the right 
 * (as you can see the format does not need to contain names, for example the 4th format means the person born on the left
 * date is parent to the person born on the right date). The last format ties different information 
 * together – i.e. the person with that name was born on that date. Names and birthdates are unique – there won’t be
 * 2 people with the same name or birthdate, there will always be enough entries to construct the family tree
 * (all people’s names and birthdates are known and they have atleast one connection to another person in the tree). 
 * 
 * After the command “End” is received you should print all information about the person whose name or birthdate you 
 * received on the first line – his name, birthday, parents and children (check the examples for the format). 
 * The people in the parents and childrens lists should be ordered by their first appearance in the input 
 * (regardless if they appeared as a birthdate or a name, for example in the first input Stamat is before Penka because he
 * has appeared first on the second line, while she appears on the third one).
 * 
 * Example
 * Input:                             Output:
 * Pesho Peshev                       Pesho Peshev 23/5/1980
 * 11/11/1951 - 23/5/1980             Parents:
 * Penka Pesheva - 23/5/1980          Stamat Peshev 11/11/1951
 * Penka Pesheva 9/2/1953             Penka Pesheva 9/2/1953
 * Pesho Peshev - Gancho Peshev       Children:
 * Gancho Peshev 1/1/2005             Gancho Peshev 1/1/2005
 * Stamat Peshev 11/11/1951
 * Pesho Peshev 23/5/1980
 * End
 * 
 * Input:                                Output:
 * 13/12/1993                            Moncho Tonchev 13/12/1993
 * 25/3/1934 - 4/4/1961                  Parents:
 * Poncho Tonchev 25/3/1934              Toncho Tonchev 4/4/1961
 * 4/4/1961 - Moncho Tonchev             Children:
 * Toncho Tonchev - Lomcho Tonchev
 * Moncho Tonchev 13/12/1993
 * Lomcho Tonchev 7/7/1995
 * Toncho Tonchev 4/4/1961
 * End
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    private static void Main()
    {
        Person currentPerson = new Person(Console.ReadLine());
        List<Person> parents = new List<Person>();
        List<Person> children = new List<Person>();
        List<string[]> unindentifiedInfo = new List<string[]>();
        List<string[]> relativesInfo = new List<string[]>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (input.Contains(" - "))
            {
                string[] inputArgs = input.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

                if (inputArgs[0] == currentPerson.personBirthDate || inputArgs[0] == currentPerson.personName)
                {
                    children.Add(new Person(inputArgs[1]));
                }
                else if (inputArgs[1] == currentPerson.personBirthDate || inputArgs[1] == currentPerson.personName)
                {
                    parents.Add(new Person(inputArgs[0]));
                }
                else
                {
                    unindentifiedInfo.Add(new string[] {inputArgs[0], inputArgs[1]});
                }
            }
            else
            {
                string[] relativesCurrentInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                     .ToArray();
                relativesInfo.Add(new string[] { $"{relativesCurrentInfo[0]} {relativesCurrentInfo[1]}", 
                    relativesCurrentInfo[2] });
            }
        }

        FillCurrentPersonInfo(currentPerson, relativesInfo, unindentifiedInfo, parents, children);

        Console.WriteLine(currentPerson);
        Console.WriteLine("Parents:");
        foreach (var parent in parents) 
        {
            Console.WriteLine(parent);
        }
        Console.WriteLine("Children:");
        foreach (var child in children) 
        {
            Console.WriteLine(child);
        }
    }

    private static void FillCurrentPersonInfo(Person currentPerson, List<string[]> relativesInfo, 
                                              List<string[]> unindentifiedInfo, List<Person> parents, List<Person> children)
    {

        for (int index = 0; index < relativesInfo.Count(); index++)
        {
            if (relativesInfo[index][0] == currentPerson.personName)
            {
                currentPerson.personBirthDate = relativesInfo[index][1];
                relativesInfo.RemoveAt(index);
                break;
            }
            else if (relativesInfo[index][1] == currentPerson.personBirthDate)
            {
                currentPerson.personName = relativesInfo[index][0];
                relativesInfo.RemoveAt(index);
                break;
            }
        }

        for (int index = 0; index < unindentifiedInfo.Count(); index++) 
        {
            if (unindentifiedInfo[index][0] == currentPerson.personBirthDate 
                || unindentifiedInfo[index][0] == currentPerson.personName)
            {
                children.Add(new Person(unindentifiedInfo[index][1]));
            }
            else if (unindentifiedInfo[index][1] == currentPerson.personBirthDate 
                     || unindentifiedInfo[index][1] == currentPerson.personName)
            {
                parents.Add(new Person(unindentifiedInfo[index][0]));
            }
        }

        for (int index = 0; index < relativesInfo.Count(); index++)
        {

            for (int p = 0; p < parents.Count(); p++)
            {
                if (parents[p].personName == relativesInfo[index][0])
                {
                    parents[p].personBirthDate = relativesInfo[index][1];
                }
                else if (parents[p].personBirthDate == relativesInfo[index][1])
                {
                    parents[p].personName = relativesInfo[index][0];
                }
            }
             
            for (int c = 0; c < children.Count(); c++)
            {
                if (children[c].personName == relativesInfo[index][0])
                {
                    children[c].personBirthDate = relativesInfo[index][1];
                }
                else if (children[c].personBirthDate == relativesInfo[index][1])
                {
                    children[c].personName = relativesInfo[index][0];
                }
            }
        }
    }

    private static bool IsDate(string unindentifieldInfo)
    {
        return unindentifieldInfo.Contains("/");
    }
}