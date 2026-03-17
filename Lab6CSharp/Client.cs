using System;

namespace Lab6;

public abstract class Client
{
    protected string name;
    protected DateTime serviceDate;

    public Client(string name, DateTime serviceDate)
    {
        this.name = name;
        this.serviceDate = serviceDate;
    }

    public abstract void Show();

    public virtual bool IsMatchDate(DateTime date)
    {
        return serviceDate.Date == date.Date;
    }

}