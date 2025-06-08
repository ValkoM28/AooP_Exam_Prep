namespace RestaurantSystem;
public class NoDiscount : IDiscount
{
    public decimal ApplyDiscount(decimal total)
    {
        return 0;
    }
    public string GetDiscountName()
    {
        return "No Discount";
    }
}

public class StudentDiscount : IDiscount
{
    public decimal ApplyDiscount(decimal total)
    {
        return total * 0.10m;
    }
     public string GetDiscountName()
    {
        return "Student Discount (10%)";
    }
}

public class SeniorDiscount : IDiscount
{
    public decimal ApplyDiscount(decimal total)
    {
        return total * 0.15m; 
    }
    public string GetDiscountName()
    {
        return "Senior Discount (15%)";
    }
}

public class HolidayDiscount : IDiscount
{
    public decimal ApplyDiscount(decimal total)
    {
        return total * 0.20m;
    }
      public string GetDiscountName()
    {
        return "Holiday Discount (20%)";
    }
}
