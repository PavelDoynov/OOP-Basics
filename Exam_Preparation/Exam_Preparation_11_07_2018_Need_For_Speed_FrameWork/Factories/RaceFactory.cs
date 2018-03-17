using System;

public class RaceFactory
{
    internal static Race GetRace(int id, string type, int length, string route, int prizePool)
    {
        const string CASUAL_RACE = "Casual";
        const string DRIFT_RACE = "Drift";
        const string DRAG_RACE = "Drag";

        Race currentRace;
        if (type == CASUAL_RACE)
        {
            currentRace = new CasualRace(id, length, route, prizePool);
        }
        else if (type == DRIFT_RACE)
        {
            currentRace = new DriftRace(id, length, route, prizePool);
        }
        else if (type == DRAG_RACE)
        {
            currentRace = new DragRace(id, length, route, prizePool);
        }
        else
        {
            throw new ArgumentException("Invalid race type!");
        }

        return currentRace;
    }
}