namespace RestaurantSystem;

using System.Globalization;

public class MenuItem
{
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty or whitespace.");
            }
            _name = value;
        }
    }

    public decimal Price { get; private set; }

    public MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - {Price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
    }
}