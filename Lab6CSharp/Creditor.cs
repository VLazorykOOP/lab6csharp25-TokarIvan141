using Lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab6CSharp;

public class Creditor : Client
{
    private double loan;
    private double interest;
    private double balance;

    public Creditor(string name, DateTime date, double loan, double interest, double balance)
        : base(name, date)
    {
        this.loan = loan;
        this.interest = interest;
        this.balance = balance;
    }

    public override void Show()
    {
        Console.WriteLine($"Кредитор: {name} | Дата: {serviceDate.ToShortDateString()} | Кредит: {loan} | Залишок: {balance}");
    }

}
