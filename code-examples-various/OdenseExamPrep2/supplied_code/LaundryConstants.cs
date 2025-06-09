namespace laundry_facade;

public abstract record LaundryConstants
{
    // Machine Models
    public const string WashingMachine6 = "Washing Machine - 6 kg Wash";
    public const string WashingMachine12 = "Washing Machine - 12 kg Wash";
    public const string TumbleDryer = "Tumble Dryer";
    
    // Tumble dryer price per minute
    public const  double TumblePrice = 1.25;
    
    // Wash programs 
    public const string WashProgram1 = "95 Normal";
    public const string WashProgram2 = "60 Normal";
    public const string WashProgram3 = "40 Normal";
    public const string WashProgram4 = "30 Gentle";
    public const string WashProgram5 = "40 Non-iron";
    public const string WashProgram6 = "60 Non-iron";
    public const string WashProgram7 = "Wool";

    // Wash prices (6 kg):
    public const double WashPrice1 = 42.00;
    public const double WashPrice2 = 37.50;
    public const double WashPrice3 = 33.50;
    public const double WashPrice4 = 30.00;
    public const double WashPrice5 = 35.00;
    public const double WashPrice6 = 39.50;
    public const double WashPrice7 = 28.00;

    // Wash prices (12 kg) just 50% over the prices for 6 kg machines 
    public const double FactorWash12 = 1.5;
}