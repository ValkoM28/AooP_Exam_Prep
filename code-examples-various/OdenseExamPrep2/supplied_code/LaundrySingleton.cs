using System;

namespace laundry_facade;

public class LaundrySingleton
{
    private ILaundryMachine[] _laundryMachines;
    
    
    public static LaundrySingleton GetInstance => throw new NotSupportedException("Not supported yet.");
    
    public static void TestLaundrySingleton() {
        GetInstance.BuildLaundry();

        Console.WriteLine(GetInstance.GetMachine(0)?.GetModel() + ":");
        Console.Write(GetInstance.GetProgramName(0, 5) + "\t");
        Console.Write($"{GetInstance.GetPrice(0, 5):F}");
        Console.WriteLine("\n");
        Console.WriteLine(GetInstance.GetMachine(1)?.GetModel() + ":");
        Console.Write(GetInstance.GetProgramName(1, 5) + "\t");
        Console.Write($"{GetInstance.GetPrice(1, 5):F}");
        Console.WriteLine("\n");
        Console.WriteLine(GetInstance.GetMachine(2)?.GetModel() + ":");
        Console.Write(GetInstance.GetProgramName(2, 5) + "\t");
        Console.Write($"{GetInstance.GetPrice(2, 5):F}");

    }

    
    public override string ToString() {
        return "laundryMachines:\n" +  string.Join(", ", _laundryMachines.ToString());
    }
    
    public ILaundryMachine? GetMachine(int index) {
        if (index < _laundryMachines.Length)
            return _laundryMachines[index];
        else {
            Console.WriteLine("Machine does not exist!");
            return null;
        }
    }

    public double GetPrice(int machine, int program) {
        ILaundryMachine? lm = GetMachine(machine);
        if (lm != null) {
            return lm.GetPrice(program);
        }
        return 0.0;
    }

    public String GetProgramName(int machine, int prog) {
        ILaundryMachine? lm = GetMachine(machine);
        if (lm != null) {
            return lm.GetProgramName(prog);
        }
        return "Machine does not exist!";

    }

    public void BuildLaundry() {
        _laundryMachines = new ILaundryMachine[3];
       
        
        WashingMachine w1 = new WashingMachine(LaundryConstants.WashingMachine6);
        w1.AddProgram(1, LaundryConstants.WashProgram1, LaundryConstants.WashPrice1);
        w1.AddProgram(2, LaundryConstants.WashProgram2, LaundryConstants.WashPrice2);
        w1.AddProgram(3, LaundryConstants.WashProgram3, LaundryConstants.WashPrice3);
        w1.AddProgram(4, LaundryConstants.WashProgram4, LaundryConstants.WashPrice4);
        w1.AddProgram(5, LaundryConstants.WashProgram5, LaundryConstants.WashPrice5);
        w1.AddProgram(6, LaundryConstants.WashProgram6, LaundryConstants.WashPrice6);
        w1.AddProgram(7, LaundryConstants.WashProgram7, LaundryConstants.WashPrice7);

        _laundryMachines[0] = w1;

        WashingMachine w2 = new WashingMachine(LaundryConstants.WashingMachine12);
        w2.AddProgram(1, LaundryConstants.WashProgram1, LaundryConstants.WashPrice1 * LaundryConstants.FactorWash12);
        w2.AddProgram(2, LaundryConstants.WashProgram2, LaundryConstants.WashPrice2 * LaundryConstants.FactorWash12);
        w2.AddProgram(3, LaundryConstants.WashProgram3, LaundryConstants.WashPrice3 * LaundryConstants.FactorWash12);
        w2.AddProgram(4, LaundryConstants.WashProgram4, LaundryConstants.WashPrice4 * LaundryConstants.FactorWash12);
        w2.AddProgram(5, LaundryConstants.WashProgram5, LaundryConstants.WashPrice5 * LaundryConstants.FactorWash12);
        w2.AddProgram(6, LaundryConstants.WashProgram6, LaundryConstants.WashPrice6 * LaundryConstants.FactorWash12);
        w2.AddProgram(7, LaundryConstants.WashProgram7, LaundryConstants.WashPrice7 * LaundryConstants.FactorWash12);

        _laundryMachines[1] = w2;

        TumbleDryer t = new TumbleDryer(LaundryConstants.TumbleDryer);
        t.SetPrice(LaundryConstants.TumblePrice);

        _laundryMachines[2] = t;
    }
}