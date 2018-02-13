/*
 * 03. Test Client
 * 
 * Create a test client that tests your BankAccount class.
 * Support the following commands:
 * •   Create {Id}
 * •   Deposit {Id} {amount}
 * •   Withdraw {Id} {amount}
 * •   Print {Id}
 * •   End
 * 
 * If you try to create an account with an existing Id, print "Account already exists".
 * If you try to perform an operation on a non-existing account, print "Account does not exist".
 * If you try to withdraw an amount larger than the balance, print "Insufficient balance".
 * The Print command should print "Account ID{id}, balance {balance}". Round the balance to the second digit after 
 * the decimal separator.
 * 
 * Example
 * Input:              Output:
 * Create 1            Account already exists
 * Create 1            Insufficient balance
 * Deposit 1 20        Account ID1, balance 10.00.
 * Withdraw 1 30
 * Withdraw 1 10
 * Print 1
 * End
 * 
 * Input:              Output:
 * Deposit 2 20        Account does not exist
 * Withdraw 2 30       Account does not exist
 * Print 2             Account does not exist
 * End
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
