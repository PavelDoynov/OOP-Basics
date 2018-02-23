using System;
using System.Linq;
using System.Collections.Generic;

public class Validation
{
    private const int MIN_STAT_VALUE = 0;
    private const int MAX_STAT_VALUE = 100;

    public static void ValidateName (string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A name should not be empty.");
        }
    }

    public static void ValidateStats(string statName, int statValue)
    {
        if (statValue < MIN_STAT_VALUE || statValue > MAX_STAT_VALUE)
        {
            throw new ArgumentException($"{statName} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
        }
    }

    internal static void ValidateTeamName(List<Team> teamsList, string teamName)
    {
        if (!teamsList.Select(t => t.TeamName).ToList().Contains(teamName))
        {
            throw new ArgumentException($"Team {teamName} does not exist.");
        }
    }

    internal static void ValidatePlayerName(Team currentTeam, string playerName)
    {
        if (!currentTeam.Players.Select(x => x.Name).ToList().Contains(playerName))
        {
            throw new ArgumentException($"Player {playerName} is not in {currentTeam.TeamName} team.");
        }
    }
}