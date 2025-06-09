namespace laundry_facade;

public class WashProgram
{
    private string _name;
    private double _price;

    public WashProgram(string name, double price)
    {
        _name = name;
        _price = price;
    }

    public string GetName()
    {
        return _name;
    }

    public double GetPrice()
    {
        return _price;
    }


    public override string ToString()
    {
        return _name + ": " + _price + "\n";
    }
}