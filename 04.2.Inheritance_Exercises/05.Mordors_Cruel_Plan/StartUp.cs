/*
 * 05. Mordor’s Cruel Plan
 * 
 * Gandalf the Gray is a great wizard but he also loves to eat and the food makes him loose his capability of fighting the
 * dark. The Mordor’s orcs have asked you to design them a program which is calculating the Gandalf’s mood. So they could
 * predict the battles between them and try to beat The Gray Wizard.  When Gandalf is hungry he gets angry and he could not
 * fight well. Because the orcs have a spy, he has told them the foods that Gandalf is eating and the result on his mood
 * after he has eaten some food. So here is the list:
 * 
 * •   Cram: 2 points of happiness;
 * •   Lembas: 3 points of happiness;
 * •   Apple: 1 point of happiness;
 * •   Melon: 1 point of happiness;
 * •   HoneyCake: 5 points of happiness;
 * •   Mushrooms: -10 points of happiness;
 * •   Everything else: -1 point of happiness;
 * 
 * Gandalf moods are:
 * 
 * •   Angry - below -5 points of happiness;
 * •   Sad - from -5 to 0 points of happiness;
 * •   Happy - from 1 to 15 points of happiness;
 * •   JavaScript - when happiness points are more than 15;
 * 
 * The task is simple. Model an application which is calculating the happiness points, Gandalf has after eating all the 
 * food passed in the input. After you are done, print on the first line – total happiness points Gandalf had collected.
 * On the second line – print the Mood’s name which is corresponding to the points.
 * 
 * Input
 * The input comes from the console. It will hold a single line: all the Gandalf`s foods he has eaten separated by a
 * whitespace.
 * 
 * Output
 * Print on the console Gandalf`s happiness points and the Mood’s name which is corresponding to the points.
 * 
 * Constraints
 * •   The characters in the input string will be no more than: 1000.
 * •   The food count would be in the range [1…100].
 * •   Time limit: 0.3 sec. Memory limit: 16 MB.
 * 
 * Note
 * Try to implement a factory pattern. You should have two factory classes – FoodFactory and MoodFactory. And their task is
 * to produce objects (e.g. FoodFactory, produces – Food and the MoodFactory - Mood). 
 * Try to implement abstract classes (e.g. classes which can’t be instantiated directly)
 * 
 * Example
 * Input:                           Output:
 * Cram melon honeyCake Cake        7
 *                                  Happy
 * 
 * Input:                                       Output:
 * gosho, pesho, meze, Melon, HoneyCake@;       -5
 *                                              Sad
 * 
 * https://github.com/PavelDoynov
 */


using System;

class Program
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        int pointsOfHappiness = GetPoints(inputArr);
        string mood = GetMood(pointsOfHappiness);

        Console.WriteLine(pointsOfHappiness);
        Console.WriteLine(mood);
    }

    private static int GetPoints(string[] inputArr)
    {
        int result = 0;

        foreach (var food in inputArr)
        {
            if (food == "cram")
            {
                result += new Cram().Points;
            }
            else if (food == "lembas")
            {
                result += new Lembas().Points;
            }
            else if (food == "apple")
            {
                result += new Apple().Points;
            }
            else if (food == "melon")
            {
                result += new Melon().Points;
            }
            else if (food == "honeycake")
            {
                result += new HoneyCake().Points;
            }
            else if (food == "mushrooms")
            {
                result += new Mushrooms().Points;
            }
            else
            {
                result += new EverythingElse().Points;
            }
        }

        return result;
    }

    private static string GetMood(int points)
    {
        string mood = null;

        if (points < -5)
        {
            mood = new Angry().Mood;
        }
        else if (points >= -5 && points <= 0)
        {
            mood = new Sad().Mood;
        }
        else if (points >= 1 && points <= 15)
        {
            mood = new Happy().Mood;
        }
        else
        {
            mood = new JavaScript().Mood;
        }

        return mood;
    }
}