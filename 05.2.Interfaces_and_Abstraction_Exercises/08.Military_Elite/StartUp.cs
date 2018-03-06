/*
 * 08. Military Elite
 * 
 * Create the following class hierarchy:
 * 
 * •    Soldier – general class for soldiers, holding id, first name and last name.
 *   o    Private – lowest base soldier type, holding the field salary(double). 
 *     •   LeutenantGeneral – holds a set of Privates under his command.
 *     •   SpecialisedSoldier – general class for all specialised soldiers – holds the corps of the soldier. 
 *         The corps can only be one of the following: Airforces or Marines.
 *       -   Engineer – holds a set of repairs. A repair holds a part name and hours worked(int).
 *       -   Commando – holds a set of missions. A mission holds code name and a state (inProgress or Finished). 
 *         A mission can be finished through the method CompleteMission().
 *   o    Spy – holds the code number of the spy (int).
 * 
 * Extract interfaces for each class. (e.g. ISoldier, IPrivate, ILeutenantGeneral, etc.) The interfaces should hold 
 * their public properties and methods (e.g. Isoldier should hold id, first name and last name). Each class should 
 * implement its respective interface. Validate the input where necessary (corps, mission state) - input should match 
 * exactly one of the required values, otherwise it should be treated as invalid. In case of invalid corps the entire 
 * line should be skipped, in case of an invalid mission state only the mission should be skipped.
 * 
 * You will receive from the console an unknown amount of lines containing information about soldiers until the command
 * “End” is received. The information will be in one of the following formats:
 * 
 * •   Private: “Private <id> <firstName> <lastName> <salary>”
 * •   LeutenantGeneral: “LeutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>” 
 *     where privateXId will always be an Id of a private already received through the input.
 * •   Engineer: “Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>”
 *     where repairXPart is the name of a repaired part and repairXHours the hours it took to repair it 
 *     (the two parameters will always come paired). 
 * •   Commando: “Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … 
 *     <missionNCodeName> <missionNstate>” a missions cde name, description and state will always come together.
 * •   Spy: “Spy <id> <firstName> <lastName> <codeNumber>”
 * 
 * Define proper constructors. Avoid code duplication through abstraction. Override ToString() in all classes to print
 * detailed information about the object.
 * 
 * •   Privates:
 *     Name: <firstName> <lastName> Id: <id> Salary: <salary>
 * •   Spy:
 *     Name: <firstName> <lastName> Id: <id>
 *     Code Number: <codeNumber>
 * •   LeutenantGeneral:
 *     Name: <firstName> <lastName> Id: <id> Salary: <salary>
 *     Privates:
 *       <private1 ToString()>
 *       <private2 ToString()>
 *       …
 *       <privateN ToString()>
 * •   Engineer:
 *     Name: <firstName> <lastName> Id: <id> Salary: <salary>
 *     Corps: <corps>
 *     Repairs:
 *       <repair1 ToString()>
 *       <repair2 ToString()>
 *       …
 *       <repairN ToString()>
 * •   Commando:
 *     Name: <firstName> <lastName> Id: <id> Salary: <salary>
 *     Corps: <corps>
 *     Missions:
 *       <mission1 ToString()>
 *       <mission2 ToString()>
 *       …
 *       <missionN ToString()>
 * •   Repair:
 *     Part Name: <partName> Hours Worked: <hoursWorked>
 * •   Mission:
 *     Code Name: <codeName> State: <state>
 * 
 * NOTE: Salary should be printed rounded to two decimal places after the separator.
 * 
 * Example
 * Input:                                         Output:
 * Private 1 Pesho Peshev 22.22                   Name: Pesho Peshev Id: 1 Salary: 22.22
 * Commando 13 Stamat Stamov 13.1 Airforces       Name: Stamat Stamov Id: 13 Salary: 13.10
 * Private 222 Toncho Tonchev 80.08               Corps: Airforces
 * LeutenantGeneral 3 Joro Jorev 100 222 1        Missions:
 * End                                            Name: Toncho Tonchev Id: 222 Salary: 80.08
 *                                                Name: Joro Jorev Id: 3 Salary: 100.00
 *                                                Privates:
 *                                                  Name: Toncho Tonchev Id: 222 Salary: 80.08
 *                                                  Name: Pesho Peshev Id: 1 Salary: 22.22
 * 
 * Input:                                        
 * Engineer 7 Pencho Penchev 12.23 Marines Boat 2 Crane 17
 * Commando 19 Penka Ivanova 150.15 Airforces HairyFoot finished Freedom inProgress
 * End
 * 
 *  Output:
 * Name: Pencho Penchev Id: 7 Salary: 12.23
 * Corps: Marines
 * Repairs:
 *   Part Name: Boat Hours Worked: 2
 *   Part Name: Crane Hours Worked: 17
 * Name: Penka Ivanova Id: 19 Salary: 150.15
 * Corps: Airforces
 * Missions:
 *   Code Name: Freedom State: inProgress
 * 
 * https://github.com/PavelDoynov
 */


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Soldier> soldiersData = new List<Soldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string currentArmyPossition = inputArgs[0];

            if (currentArmyPossition == "Private")
            {
                soldiersData.Add(new Private (int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3],
                                              decimal.Parse(inputArgs[4])));
            }
            else if (currentArmyPossition == "LeutenantGeneral")
            {
                List<Private> generalSoldiers = GetSoldiers(inputArgs, soldiersData);
                soldiersData.Add(new LeutenantGeneral(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3],
                                                      decimal.Parse(inputArgs[4]), generalSoldiers));
            }
            else if (currentArmyPossition == "Engineer")
            {
                if (inputArgs[5] == "Airforces" || inputArgs[5] == "Marines")
                {
                    if (inputArgs.Count() == 6)
                    {
                        soldiersData.Add(new Engineer(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3],
                                                      decimal.Parse(inputArgs[4]), inputArgs[5]));
                    }
                    else
                    {
                        List<string[]> repairs = GetRepairs(inputArgs);
                        soldiersData.Add(new Engineer(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3],
                                                      decimal.Parse(inputArgs[4]), inputArgs[5], repairs));
                    }
                }
            }
            else if (currentArmyPossition == "Commando")
            {
                if (inputArgs[5] == "Airforces" || inputArgs[5] == "Marines")
                {
                    if (inputArgs.Count() == 6)
                    {
                        soldiersData.Add(new Commando(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3],
                                                      decimal.Parse(inputArgs[4]), inputArgs[5]));
                    }
                    else
                    {
                        List<string[]> missions = GetMissions(inputArgs);
                        soldiersData.Add(new Commando(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3],
                                                      decimal.Parse(inputArgs[4]), inputArgs[5], missions));
                    }
                }
            }
            else if (currentArmyPossition == "Spy")
            {
                soldiersData.Add(new Spy(int.Parse(inputArgs[1]), inputArgs[2], inputArgs[3],
                                         int.Parse(inputArgs[4])));
            }
        }

        foreach (Soldier soldier in soldiersData)
        {
            Console.WriteLine(soldier);
        }
    }

    private static List<string[]> GetMissions(string[] inputArgs)
    {
        List<string[]> missions = new List<string[]>();
        for (int i = 6; i < inputArgs.Count() - 1; i+=2)
        {
            if (inputArgs[i + 1] == "inProgress" || inputArgs[i + 1] == "Finished")
            {
                string[] currentMissionArr = new string[2];
                currentMissionArr[0] = inputArgs[i];
                currentMissionArr[1] = inputArgs[i + 1];
                missions.Add(currentMissionArr);
            }
        }
        return missions;
    }

    private static List<Private> GetSoldiers(string[] inputArgs, List<Soldier> soldiersData)
    {
        List<Private> generalSoldiers = new List<Private>();
        for (int i = 5; i <= inputArgs.Count() - 1; i++)
        {
            int currentId = int.Parse(inputArgs[i]);
            Private currentSoldier = (Private)soldiersData.First(x => x.Id == currentId);
            generalSoldiers.Add(currentSoldier);
        }
        return generalSoldiers;
    }

    private static List<string[]> GetRepairs(string[] inputArgs)
    {
        List<string[]> repairs = new List<string[]>();
        for (int i = 6; i < inputArgs.Count() - 1; i+=2)
        {
            bool isANumber = int.TryParse(inputArgs[i + 1], out int number);
            if (isANumber)
            {
                string[] currentRepair = new string[2];
                currentRepair[0] = inputArgs[i];
                currentRepair[1] = inputArgs[i + 1];
                repairs.Add(currentRepair);
            }
        }
        return repairs;
    }
}