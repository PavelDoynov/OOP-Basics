using System;

public class Player
{
    string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public string Name
    {
        get { return name; }
        private set
        {
            Validation.ValidateName(value);
            name = value;
        }
    }

    public int Endurance
    {
        get { return endurance; }
        private set
        {
            Validation.ValidateStats("Endurance", value);
            endurance = value;
        }
    }

    public int Sprint
    {
        get { return sprint; }
        private set
        {
            Validation.ValidateStats("Sprint", value);
            sprint = value;
        }
    }

    public int Dribble
    {
        get { return dribble; }
        private set
        {
            Validation.ValidateStats("Dribble", value);
            dribble = value;
        }
    }

    public int Passing
    {
        get { return passing; }
        private set
        {
            Validation.ValidateStats("Passing", value);
            passing = value;
        }
    }

    public int Shooting
    {
        get { return shooting; }
        private set
        {
            Validation.ValidateStats("Shooting", value);
            shooting = value;
        }
    }

    public Player(string name, int endurance, int sprint, 
                  int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }
}