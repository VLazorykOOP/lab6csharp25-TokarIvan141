using Lab6;
using System;
using System.Xml.Linq;

namespace Lab6;

public class Mechanism : Node
{
    protected string type;

    public Mechanism(string name, string material, double weight, int partCount, string type)
        : base(name, material, weight, partCount)
    {
        this.type = type;
    }

    public override void Show()
    {
        Console.WriteLine($"Механізм: {name} | Тип: {type} | Потужність: {weight * 10} к.с.");
    }
}