using System.Globalization;

namespace RestaurantSystem;
public class ReceiptGenerator
{
    public void PrintReceipt(Order order)
    {
        Console.WriteLine("\n--- Restaurant Receipt ---");
        Console.WriteLine($"Date: {DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture)}");

        Console.WriteLine("\n--- Ordered Items ---");
        foreach (var item in order.GetItems())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\n-----------------------");
        Console.WriteLine($"Subtotal: {order.GetTotal().ToString("C", CultureInfo.GetCultureInfo("en-US"))}");
        Console.WriteLine($"Discount: {order.GetDiscountName()}"); // show discount name
        Console.WriteLine($"Total: {order.GetDiscountedTotal().ToString("C", CultureInfo.GetCultureInfo("en-US"))}");
        Console.WriteLine("-----------------------");
        Console.WriteLine("Thank you for your order!");
    }
}