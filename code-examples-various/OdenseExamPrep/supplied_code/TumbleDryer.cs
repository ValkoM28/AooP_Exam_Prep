using System;

namespace laundry_facade;

public class TumbleDryer : ILaundryMachine
{
    
    private double _pricePerMinute;
    private readonly string _model;

    public TumbleDryer(string model)
    {
        throw new NotSupportedException("Not supported yet.");
    }

    public void SetPrice(double pricePerMinute)
    {
        throw new NotSupportedException("Not supported yet.");
    }

    public override string ToString() {
        return GetModel() + " Minute price: " + _pricePerMinute + "\n";
    }

    public string GetModel()
    {
        throw new NotSupportedException("Not supported yet.");
    }

    public double GetPrice(int prog)
    {
        throw new NotSupportedException("Not supported yet.");
    }

    public string GetProgramName(int prog)
    {
        throw new NotSupportedException("Not supported yet.");
    }
}