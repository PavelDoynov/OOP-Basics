using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class CasualRace : Race
{
    public CasualRace(int id, int length, string route, int prizePool) 
        : base(id, length, route, prizePool)
    {
    }

	public override string ToString()
	{
        StringBuilder result = new StringBuilder();
        int count = 0;
        int money = 0;

        base.Participants.ForEach(c => c.OverallPerformance());
        base.Participants = base.Participants.OrderByDescending(c => c.Points).ToList();

        foreach (var car in this.Participants)
        {
            count++;
            if (count == 1)
            {
                money = (base.PrizePool * 50) / 100; 
            }
            else if (count == 2)
            {
                money = (base.PrizePool * 30) / 100; 
            }
            else if (count == 3)
            {
                money = (base.PrizePool * 20) / 100; 
            }

            result.Append(Environment.NewLine + $"{count}. {car.Brand} {car.Model} " +
                          $"{car.Points}PP - ${money}");
            

            if (count == 3)
            {
                break;
            }
        }

        return base.ToString() + result.ToString();
	}
}