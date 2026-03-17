using Lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab6CSharp;

public class Organization : Client
{
    private string account;
    private double balance;

    public Organization(string name, DateTime date, string account, double balance)
        : base(name, date)
    {
        this.account = account;
        this.balance = balance;
    }

    public override void Show()
    {
        Console.WriteLine($"Організація: {name} | Дата: {serviceDate.ToShortDateString()} | Рахунок: {account} | Сума: {balance}");
    }

}
