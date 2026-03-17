using Lab6;

namespace Lab6CSharp;

public class Depositor : Client
{
    private double amount;
    private double interest;

    public Depositor(string name, DateTime date, double amount, double interest)
        : base(name, date)
    {
        this.amount = amount;
        this.interest = interest;
    }

    public override void Show()
    {
        Console.WriteLine($"Вкладник: {name} | Дата: {serviceDate.ToShortDateString()} | Сума: {amount} | Відсоток: {interest}");
    }

}