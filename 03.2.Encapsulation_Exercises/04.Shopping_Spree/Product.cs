using System;

public class Product
{
    string name;
    decimal price;

    public string Name
    {
        get { return name; }
        set
        {
            Validate.ValidatorName(value);
            name = value;
        }
    }

    public decimal Price
    {
        get { return price; }
        set
        {
            Validate.ValidatorMoney(value);
            price = value;
        }
    }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}