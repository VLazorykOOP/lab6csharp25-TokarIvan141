using System;

namespace Lab6;

public sealed class Product : Mechanism
{
    private double price;

    public Product(string name, string material, double weight, int partCount, string type, double price)
        : base(name, material, weight, partCount, type)
    {
        if (price < 0)
        {
            throw new ProductException("Ціна виробу не може бути від'ємною!", price);
        }

        this.price = price;
    }

    public override void Show()
    {
        Console.WriteLine($"Виріб: {name} | Ціна: {price} | Тип: {type}");
    }

}