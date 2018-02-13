/*
 * 04. Person Class
 * 
 * Create a Person class.
 * The class should have private fields for:
 * •   name: string
 * •   age: int
 * •   accounts: List<BankAccount>
 * 
 * The class should have constructors:
 * •   Person(string name, int age)
 * •   Person(string name, int age, List<BankAccount> accounts)
 * 
 * The class should also have public methods for:
 * •   GetBalance(): decimal
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
        Dictionary<int, BankAccount> data = new Dictionary<int, BankAccount>();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (inputArgs[0] == "Create")
            {
                int id = int.Parse(inputArgs[1]);

                if (!data.ContainsKey(id))
                {
                    BankAccount currentAccount = new BankAccount();
                    currentAccount.Id = id;
                    data[id] = currentAccount;
                }
                else
                {
                    Console.WriteLine("Account already exists");
                }
            }
            else if (inputArgs[0] == "Deposit")
            {
                int id = int.Parse(inputArgs[1]);
                int amount = int.Parse(inputArgs[2]);

                if (data.ContainsKey(id))
                {
                    data[id].Deposit(amount);
                }
                else
                {
                    Console.WriteLine("Account does not exist");
                }
            }
            else if (inputArgs[0] == "Withdraw")
            {
                int id = int.Parse(inputArgs[1]);
                int amount = int.Parse(inputArgs[2]);

                if (data.ContainsKey(id) && amount <= data[id].Balance)
                {
                    data[id].Withdraw(amount);
                }
                else if (data.ContainsKey(id) && amount > data[id].Balance)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    Console.WriteLine("Account does not exist");
                }
            }
            else if (inputArgs[0] == "Print")
            {
                int id = int.Parse(inputArgs[1]);

                if (data.ContainsKey(id))
                {
                    Console.WriteLine($"{data[id]}");
                }
                else
                {
                    Console.WriteLine("Account does not exist");
                }
            }
        }
    }
}
