using Lab6CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n=== Лабораторна робота №6 ===");
            Console.WriteLine("1. Комплексна демонстрація ієрархії");
            Console.WriteLine("2. Керування базою клієнтів банку");
            Console.WriteLine("3. Тестування обробки винятків");
            Console.WriteLine("4. Тестування перерахування (foreach для Node)");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunFullTest();
                    break;

                case "2":
                    RunBankDatabaseTest();
                    break;

                case "3":
                    RunExceptionTest();
                    break;

                case "4":
                    RunEnumerableTest();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }
    }

    static void RunFullTest()
    {
        Console.WriteLine("\n=== 1. Поліморфізм (IDisplayable) ===");
        IDisplayable[] items = new IDisplayable[]
        {
            new Detail("Болт", "Сталь", 0.1),
            new Node("Поршень", "Алюміній", 2.5, 4),
            new Product("Авто", "Комбінований", 1500, 5000, "Транспорт", 30000)
        };

        foreach (var item in items)
        {
            item.Show();
        }

        Console.WriteLine("\n=== 2. Ідентифікація типів (typeof, is, as) ===");
        foreach (var item in items)
        {
            Console.WriteLine($"\nОб'єкт: {item.GetType().Name}");

            if (item.GetType() == typeof(Product))
            {
                Console.WriteLine("Екземпляр визначено через typeof");
            }

            if (item is IComponent comp)
            {
                Console.WriteLine($"Матеріал через IComponent: {comp.Material}");
            }

            Product p = item as Product;
            if (p != null)
            {
                Console.WriteLine("Успішне приведення до Product через as");
            }

        }

        Console.WriteLine("\n=== 3. Тестування індексатора ===");
        Node node = new Node("Коробка", "Чавун", 45.0, 12);
        Console.WriteLine($"Індексатор [0] (назва): {node[0]}");
        Console.WriteLine($"Індексатор [1] (матеріал): {node[1]}");

        Console.WriteLine("\n=== 4. Тест ICloneable та IComparable ===");
        Detail d1 = new Detail("Вал", "Сталь", 15.0);
        Detail d2 = (Detail)d1.Clone();
        Console.WriteLine($"Клон створено: {d2.Name}");

        List<Detail> list = new List<Detail> { d1, new Detail("Гайка", "Мідь", 0.05) };
        list.Sort();
        Console.WriteLine("Відсортовано за вагою:");

        foreach (var d in list)
        {
            d.Show();
        }

    }

    static void RunBankDatabaseTest()
    {
        Client[] db = new Client[]
        {
            new Depositor("Іваненко", new DateTime(2023, 10, 15), 5000, 12),
            new Creditor("Петренко", new DateTime(2024, 03, 17), 100000, 24, 85000),
            new Organization("ТехноСвіт", new DateTime(2023, 10, 15), "UA12345", 500000)
        };

        Console.WriteLine("\n=== Повна база клієнтів ===");
        foreach (var client in db)
        {
            client.Show();
        }

        Console.Write("\nВведіть дату для пошуку (рррр-мм-дд): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime searchDate))
        {
            bool found = false;
            Console.WriteLine($"\nКлієнти, що почали співпрацю {searchDate.ToShortDateString()}:");

            foreach (var client in db)
            {
                if (client.IsMatchDate(searchDate))
                {
                    client.Show();
                    found = true;
                }

            }

            if (!found)
            {
                Console.WriteLine("Нікого не знайдено");
            }
        }

    }

    static void RunExceptionTest()
    {
        Console.WriteLine("\n=== 1. Тест власного винятку (ProductException) ===");
        try
        {
            Console.WriteLine("Спроба створити виріб з ціною -500...");
            Product p = new Product("Брак", "Пластик", 1.0, 1, "Тест", -500);
        }
        catch (ProductException ex)
        {
            Console.WriteLine($"ПЕРЕХОПЛЕНО: {ex.Message}");
            Console.WriteLine($"Некоректне значення: {ex.InvalidValue}");
        }

        Console.WriteLine("\n=== 2. Тест системного винятку (OutOfMemoryException) ===");
        try
        {
            Console.WriteLine("Спроба виділити занадто великий масив пам'яті...");
            long[] bigArray = new long[int.MaxValue];
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("ПЕРЕХОПЛЕНО: Системна помилка - недостатньо пам'яті!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Інша помилка: {ex.Message}");
        }

    }

    static void RunEnumerableTest()
    {
        Console.WriteLine("\n=== Тестування інтерфейсу IEnumerable (foreach) ===");
        Node engineNode = new Node("Блок циліндрів", "Алюміній", 45.5, 5);

        engineNode.Show();
        Console.WriteLine("Перелік внутрішніх компонентів вузла через foreach:");
        int counter = 1;

        foreach (string part in engineNode)
        {
            Console.WriteLine($"{counter}. {part}");
            counter++;
        }

        Console.WriteLine("\nТест завершено успішно");
    }
}