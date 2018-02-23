using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    string name;
    List<Player> players;

    public string TeamName
    {
        get { return name; }
        private set
        {
            Validation.ValidateName(value);
            name = value;
        }
    }

    public List<Player> Players
    {
        get { return players; }
    }

    public Team (string name)
    {
        TeamName = name;
        players = new List<Player>();
    }

    public void AddPlayers(Player currentPlayer)
    {
        this.players.Add(currentPlayer);
    }

    internal void RemovePlayer(string playerName)
    {
        for (int playerIndex = 0; playerIndex < this.players.Count; playerIndex++)
        {
            if (players[playerIndex].Name == playerName)
            {
                players.RemoveAt(playerIndex);
                break;
            }
        }
    }

    internal void ShowStats()
    {
        List<int> statsValue = new List<int>();

        foreach (var player in players)
        {
            statsValue.Add(player.Endurance);
            statsValue.Add(player.Sprint);
            statsValue.Add(player.Dribble);
            statsValue.Add(player.Passing);
            statsValue.Add(player.Shooting);
        }

        if (statsValue.Count() == 0) 
        {
            Console.WriteLine($"{TeamName} - 0");
        }
        else
        {
            Console.WriteLine($"{TeamName} - {Math.Round(statsValue.Average())}");
        }
    }
}