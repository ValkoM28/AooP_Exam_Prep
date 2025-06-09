using System;
using System.Collections.Generic;

namespace laundry_facade;

public class WashingMachine : ILaundryMachine
{
    private readonly Dictionary<int, WashProgram> _programs;
    private readonly string _model;

    public WashingMachine(string model)
    {
        throw new NotSupportedException("Not supported yet.");
    }

    public void AddProgram(int code, string name, double price) {
        throw new NotSupportedException("Not supported yet.");    
    }
    
    public string GetModel()
    {
        throw new NotSupportedException("Not supported yet.");
    }
    
    public double GetPrice(int prog)
    {
        throw new NotSupportedException("Not supported yet.");
    }

    public string GetProgramName(int prog) {
        throw new NotSupportedException("Not supported yet.");
    }

    public override string ToString() {
        return GetModel() + "\n" + string.Join(", ", _programs) + "\n";
    }

}