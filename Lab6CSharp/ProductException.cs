using System;

namespace Lab6;

public class ProductException : Exception
{
    public double InvalidValue { get; }

    public ProductException(string message, double value) : base(message)
    {
        InvalidValue = value;
    }

}