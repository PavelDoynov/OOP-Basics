/*
 * 02. Book Shop
 * 
 * You are working in a library. And you are pissed of writing descriptions for books by hand, so you wish to use the
 * computer to speed up the process. The task is simple - your program should have two classes – one for the ordinary 
 * books – Book, and another for the special ones – GoldenEditionBook. So let’s get started! We need two classes:
 * 
 * •   Book - represents a book that holds title, author and price. A book should offer information about itself in the 
 * format shown in the output below.
 * •   GoldenEditionBook - represents a special book holds the same properties as any Book, but its price is always
 * 30% higher.
 * 
 * Constraints
 * •   If the author’s second name is starting with a digit– exception’s message is: "Author not valid!"
 * •   If the title’s length is less than 3 symbols – exception’s message is: "Title not valid!"
 * •   If the price is zero or it is negative – exception’s message is: "Price not valid!"
 * •   Price must be formatted to two symbols after the decimal separator
 * 
 * Example
 * Input:                    Output:
 * Ivo 4ndonov               Author not valid!
 * Under Cover
 * 9999999999999999999
 * 
 * Input:                    Output:
 * Petur Ivanov              Type: Book
 * Life of Pesho             Title: Life of Pesho
 * 20                        Author: Petur Ivanov
 *                           Price: 20.00
 * 
 *                           Type: GoldenEditionBook
 *                           Title: Life of Pesho
 *                           Author: Petur Ivanov
 *                           Price: 26.00
 * 
 * https://github.com/PavelDoynov
 */


using System;

class Program
{
    static void Main()
    {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            Book newBook = new Book(author, title, price);
            GoldenEditionBook newGoldenBook = new GoldenEditionBook(author, title, price);

            Console.WriteLine(newBook);
            Console.WriteLine();
            Console.WriteLine(newGoldenBook);
        }
        catch (Exception exAgrs)
        {
            Console.WriteLine(exAgrs.Message);
        }
    }
}