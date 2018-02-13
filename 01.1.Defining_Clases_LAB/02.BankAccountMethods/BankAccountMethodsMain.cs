/*
 * 02. Bank Account Methods
 * 
 * Create a class BankAccount (you can use class from previous task)
 * The class should have private fields for:
 * •   id: int
 * •   balance: decimal
 * 
 * The class should also have properties for:
 * •   Id: int
 * •   Balance: decimal
 * •   Deposit(decimal amount): void
 * •   Withdraw(decimal amount): void
 * 
 * Override the method ToString().
 * 
 * https://github.com/PavelDoynov
 */



using System;

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.Id = 1;
        acc.Deposit(15);
        acc.Withdraw(10);

        Console.WriteLine(acc);
    }
}
