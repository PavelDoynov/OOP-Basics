using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.isRunning = true;
        this.nationsBuilder = new NationsBuilder();
    }

    public void StartUp()
    {
        while (this.isRunning)
        {
            List<string> inputArgs = Console.ReadLine()
                                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                            .ToList();
            
            string command = inputArgs[0];
            inputArgs.RemoveAt(0);

            if (command == "Bender")
            {
                nationsBuilder.AssignBender(inputArgs);
            }
            else if (command == "Monument")
            {
                nationsBuilder.AssignMonument(inputArgs);
            }
            else if (command == "War")
            {
                string nationType = inputArgs[0];
                nationsBuilder.IssueWar(nationType);
            }
            else if (command == "Status")
            {
                string nationType = inputArgs[0];
                Console.WriteLine(nationsBuilder.GetStatus(nationType));
            }
            else if (command == "Quit")
            {
                Console.WriteLine(nationsBuilder.GetWarsRecord());
                this.isRunning = false;
            }
        }
    }
}