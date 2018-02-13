/*
 * 01. Bank Account
 * 
 * Create a class named BankAccount.
 * The class should have private fields for:
 * •   id: int
 * •   balance: decimal
 * 
 * The class should also have public properties for:
 * •   Id: int
 * •   Balance: decimal
 * 
 * You should be able to use the class like this:
 * 
 * static void Main()
 *  {
 *      BankAccount acc = new BankAccount();
 * 
 *      acc.Id = 1;
 *      acc.Balance = 15;
 * 
 *      Console.WriteLine($"Account {acc.Id}, balance  {acc.Balance}");
 * }
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
        acc.Balance = 15;

        Console.WriteLine($"Account {acc.Id}, balance  {acc.Balance}");
    }
}
