namespace laundry_facade;

public interface ILaundryMachine
{
    string GetModel();

    double GetPrice(int prog);

    string GetProgramName(int prog);

}