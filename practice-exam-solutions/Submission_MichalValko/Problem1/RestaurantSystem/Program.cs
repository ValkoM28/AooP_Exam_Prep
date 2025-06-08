namespace RestaurantSystem;

public class RestaurantApp
{
    public static void Main(string[] args)
    {
        // Create the menu
        List<MenuItem> menu = new List<MenuItem>
        {
            new MenuItem("Pizza", 12.50m),
            new MenuItem("Burger", 8.99m),
            new MenuItem("Salad", 6.75m),
            new MenuItem("Pasta", 10.00m),
            new MenuItem("Soda", 2.50m),
            new MenuItem("Ice Cream", 4.00m)
        };

        // Get employee input for discount
        Console.WriteLine("Available Discounts:");
        Console.WriteLine("1. No Discount");
        Console.WriteLine("2. Student Discount");
        Console.WriteLine("3. Senior Discount");
        Console.WriteLine("4. Holiday Discount");
        Console.Write("Enter the number of the discount you want to apply: ");
        string? discountChoice = Console.ReadLine();

        IDiscount discount;
        switch (discountChoice)
        {
            case "1":
                discount = new NoDiscount();
                break;
            case "2":
                discount = new StudentDiscount();
                break;
            case "3":
                discount = new SeniorDiscount();
                break;
            case "4":
                 discount = new HolidayDiscount();
                 break;
            default:
                Console.WriteLine("Invalid discount choice.  Applying no discount.");
                discount = new NoDiscount();
                break;
        }

        // Create an order with the selected discount
        Order order = new Order(discount);


        //Take user input
        Console.WriteLine("\nPlease enter the customer's order:");
        foreach (var item in menu)
        {
            Console.WriteLine(item);
        }

        while (true)
        {

            Console.WriteLine("\nCurrent Order:");
            foreach (var item in order.GetItems())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nEnter the name of the item you want to add to the order (or 'done' to finish):");
            string? itemName = Console.ReadLine();

            if (itemName?.ToLower() == "done")
            {
                break;
            }

            MenuItem? selectedItem = menu.Find(item => item.Name.ToLower() == itemName?.ToLower());
            if (selectedItem != null)
            {
                order.AddItem(selectedItem);
                Console.WriteLine($"{selectedItem.Name} added to your order.");
            }
            else
            {
                Console.WriteLine("Sorry, that item is not on the menu. Please enter a valid item name.");
            }
        }

        // Create a ReceiptGenerator and print the receipt
        ReceiptGenerator receiptGenerator = new ReceiptGenerator();
        receiptGenerator.PrintReceipt(order);

        Console.ReadKey();
    }
}