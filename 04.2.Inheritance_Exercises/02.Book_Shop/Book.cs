using System;

public class Book
{
    string author;
    string title;
    decimal price;

    public Book (string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    { 
        get { return author; }
        protected set 
        {
            Validation.AuthorSecondName(value);
            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        protected set 
        {
            Validation.ValidateTitle(value);
            title = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        protected set
        {
            Validation.ValidatePrice(value);
            price = value;
        }
    }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}\nTitle: {Title}\nAuthor: {Author}\nPrice: {Price:f2}";
    }
}