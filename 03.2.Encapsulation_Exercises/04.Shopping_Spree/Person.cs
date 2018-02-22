using System;
using System.Collections.Generic;

public class Person
{
    string name;
    decimal money;
    List<Product> listOfProducts;

    public List<Product> Products
    {
        get { return listOfProducts; }
    }

    public string Name
    {
        get { return name; }
        private set 
        {
            Validate.ValidatorName(value);
            name = value;
        }
    }

    public decimal Money
    {
        get { return money; }
        private set
        {
            Validate.ValidatorMoney(value);
            money = value;
        }
    }

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        listOfProducts = new List<Product>();
    }

    public void BuyingProducts(Product product)
    {
        if (this.Money < product.Price)
        {
            Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
        else
        {
            this.Money -= product.Price;
            listOfProducts.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
    }
}