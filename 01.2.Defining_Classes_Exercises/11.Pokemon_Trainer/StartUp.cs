/*
 * 11. Pokemon Trainer
 * 
 * You wanna be the very best pokemon trainer, like no one ever was, so you set out to catch pokemon. Define a class 
 * Trainer and a class Pokemon. Trainers have a name, number of badges and a collection of pokemon, Pokemon have a 
 * name, an element and health, all values are mandatory. Every Trainer starts with 0 badges.
 * 
 * From the console you will receive an unknown number of lines until you receive the command “Tournament”. Each line will
 * carry information about a pokemon and the trainer who caught it in the 
 * format “<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>” where TrainerName is the name of the Trainer who
 * caught the pokemon. Trainer names are unique.
 * 
 * After receiving the command “Tournament”, an unknown number of lines containing one of the three elements 
 * “Fire”, “Water”, “Electricity” will follow until the “End” command is received. 
 * For every command you must check if a trainer has at least 1 pokemon with the given element. If he does, 
 * he receives 1 badge. Otherwise, all of his pokemon lose 10 health. If a pokemon falls to 0 or less health, he dies and
 * must be deleted from the trainer’s collection.
 * 
 * After the “End” command is received you should print all trainers sorted by the amount of badges they have in 
 * descending order (if two trainers have the same amount of badges they should be sorted by order of appearance in the 
 * input) in the format “<TrainerName> <Badges> <NumberOfPokemon>”.
 * 
 * Example
 * Input:                            Output:                Input:                            Output:
 * Pesho Charizard Fire 100          Pesho 2 2              Stamat Blastoise Water 18         Nasko 1 1
 * Gosho Squirtle Water 38           Gosho 0 1              Nasko Pikachu Electricity 22      Stamat 0 0
 * Pesho Pikachu Electricity 10                             Jicata Kadabra Psychic 90         Jicata 0 1
 * Tournament                                               Tournament
 * Fire                                                     Fire
 * Electricity                                              Electricity
 * End                                                      Fire
 *                                                          End
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
        List<Trainer> data = new List<Trainer>();

        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] args = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Pokemon currentPokemon = new Pokemon(args[1], args[2], int.Parse(args[3]));

            if (data.Select(x => x.Name).ToList().Contains(args[0])) 
            {
                data.Where(x => x.Name == args[0]).Select(x => x.Pokemon = currentPokemon).ToList();
            }
            else
            {
                Trainer currentTrainer = new Trainer();
                currentTrainer.Name = args[0];
                currentTrainer.Pokemon = currentPokemon;
                data.Add(currentTrainer);
            }

        }

        string tournamentArgs;
        while ((tournamentArgs = Console.ReadLine()) != "End")
        {
            for (int trainer = 0; trainer < data.Count(); trainer++)
            {
                data[trainer].CurrentElement(tournamentArgs);
            }
        }

        foreach (var trainer in data.OrderByDescending(x => x.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonList.Count()}");
        }
    }
}
