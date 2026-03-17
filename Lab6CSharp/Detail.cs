using System;

namespace Lab6;

public class Detail : IComponent, ICloneable, IComparable<Detail>
{
    protected string name;
    protected string material;
    protected double weight;

    public string Name => name;
    public string Material { get => material; set => material = value; }
    public double Weight { get => weight; set => weight = value; }

    public Detail(string name, string material, double weight)
    {
        this.name = name;
        this.material = material;
        this.weight = weight;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Деталь: {name} | Матеріал: {material} | Вага: {weight}кг");
    }

    public object Clone() => new Detail(name, material, weight);

    public int CompareTo(Detail other)
    {
        if (other == null) return 1;
        return weight.CompareTo(other.weight);
    }

    ~Detail() => Console.WriteLine($"Деструктор Detail: {name} видалено");
}