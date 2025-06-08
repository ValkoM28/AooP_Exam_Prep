namespace RestaurantSystem;
public class Order
{
    private List<MenuItem> _items = new List<MenuItem>();
    private IDiscount _discount;

    public Order(IDiscount discount)
    {
        _discount = discount;
    }

    public void AddItem(MenuItem item)
    {
        _items.Add(item);
    }

    public decimal GetTotal()
    {
        decimal total = 0;
        foreach (var item in _items)
        {
            total += item.Price;
        }
        return total;
    }

    public decimal GetDiscountedTotal()
    {
        decimal total = GetTotal();
        decimal discount = _discount.ApplyDiscount(total);
        return total - discount;
    }

    public List<MenuItem> GetItems()
    {
        return _items;
    }

     public string GetDiscountName()
    {
        return _discount.GetDiscountName();
    }
}