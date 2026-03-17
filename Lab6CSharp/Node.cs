using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab6;

public class Node : Detail, IEnumerable
{
    protected int partCount;
    private string[] components;

    public Node(string name, string material, double weight, int partCount)
        : base(name, material, weight)
    {
        this.partCount = partCount;

        components = new string[partCount];
        for (int i = 0; i < partCount; i++)
        {
            components[i] = $"{name}_SubPart_{i + 1}";
        }
    }

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < components.Length)
                return components[index];
            return "Неіснуючий компонент";
        }
    }

    public IEnumerator GetEnumerator()
    {
        return components.GetEnumerator();
    }

    public override void Show()
    {
        Console.WriteLine($"Вузол: {name} | Складається з {partCount} деталей.");
    }
}