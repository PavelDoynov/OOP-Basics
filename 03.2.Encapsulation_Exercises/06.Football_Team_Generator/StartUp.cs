/*
 * 06. Football Team Generator
 * 
 * A football team has variable number of players, a name and a rating. A player has a name and stats, which are the basis
 * for his skill level. The stats a player has are endurance, sprint, dribble, passing and shooting. Each stat can be an
 * integer in the range [0..100]. The overall skill level of a player is calculated as the average of his stats. 
 * Only the name of a player and his stats should be visible to the entire outside world. Everything else should be 
 * hidden.
 * 
 * A team should expose a name, a rating (calculated by the average skill level of all players in the team and rounded 
 * to the integer part only) and methods for adding and removing players.
 * 
 * Your task is to model the team and the players following the proper principles of Encapsulation. Expose only the 
 * properties that need to be visible and validate data appropriately.
 * 
 * Input
 * Your application will receive commands until the "END" command is given. The command can be one of the following:
 * •   "Team;<TeamName>" – add a new team;
 * •   "Add;<TeamName>;<PlayerName>;<Endurance>;<Sprint>;<Dribble>;<Passing>;<Shooting>" – add a new player to the team;
 * •   "Remove;<TeamName>;<PlayerName>" – remove the player from the team;
 * •   "Rating;<TeamName>" – print the team rating, rounded to an integer.
 * 
 * Data Validation
 * •   A name cannot be null, empty or white space. If not, print "A name should not be empty."
 * •   Stats should be in the range 0..100. If not, print "[Stat name] should be between 0 and 100."
 * •   If you receive a command to remove a missing player, print "Player [Player name] is not in [Team name] team."
 * •   If you receive a command to add a player to a missing team, print "Team [team name] does not exist."
 * •   If you receive a command to show stats for a missing team, print "Team [team name] does not exist."
 * 
 * Example
 * Input:                                            Output:
 * Team;Arsenal                                      Arsenal – 81
 * Add;Arsenal;Kieran_Gibbs;75;85;84;92;67
 * Add;Arsenal;Aaron_Ramsey;95;82;82;89;68
 * Remove;Arsenal;Aaron_Ramsey
 * Rating;Arsenal
 * END
 * 
 * Input:                                            Output:
 * Team;Arsenal                                      Endurance should be between 0 and 100.
 * Add;Arsenal;Kieran_Gibbs;75;85;84;92;67           Player Aaron_Ramsey is not in Arsenal team.
 * Add;Arsenal;Aaron_Ramsey;195;82;82;89;68          Arsenal - 81
 * Remove;Arsenal;Aaron_Ramsey
 * Rating;Arsenal
 * END
 * 
 * Input:                           Output:
 * Team;Arsenal                     Arsenal – 0
 * Rating;Arsenal
 * END
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
        List<Team> teamsList = new List<Team>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                ManageTeam(teamsList, input);
            }
            catch (Exception exArgs)
            {
                Console.WriteLine(exArgs.Message);
            }
        }
    }


    private static void ManageTeam(List<Team> teamsList, string input)
    {
        string[] inputArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
        string command = inputArgs[0];
        string teamName = inputArgs[1];

        if (command == "Team")
        {
            teamsList.Add(new Team(teamName));
        }

        if (command == "Add")
        {
            Validation.ValidateTeamName(teamsList, teamName);
            Team currentTeam = teamsList.First(t => t.TeamName == teamName);

            string playerName = inputArgs[2];
            int endurance = int.Parse(inputArgs[3]);
            int sprint = int.Parse(inputArgs[4]);
            int dribble = int.Parse(inputArgs[5]);
            int passing = int.Parse(inputArgs[6]);
            int shooting = int.Parse(inputArgs[7]);

            currentTeam.AddPlayers(new Player(playerName, endurance, sprint, dribble, passing, shooting));
        }

        if (command == "Remove")
        {
            string playerName = inputArgs[2];
            Validation.ValidateTeamName(teamsList, teamName);

            Team currentTeam = teamsList.First(t => t.TeamName == teamName);
            Validation.ValidatePlayerName(currentTeam, playerName);
            currentTeam.RemovePlayer(playerName);
        }

        if (command == "Rating")
        {
            Validation.ValidateTeamName(teamsList, teamName);
            Team currentTeam = teamsList.First(t => t.TeamName == teamName);
            currentTeam.ShowStats();
        }
    }
}