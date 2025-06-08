namespace RestaurantSystem;
    public interface IDiscount
    {
        decimal ApplyDiscount(decimal total);
        string GetDiscountName();
    }