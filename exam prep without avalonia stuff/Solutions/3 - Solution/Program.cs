using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductPriceAnalyzer
{
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public Product(string name, string category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        // Sort by price ascending
        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"{Name} - {Category} - ${Price:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("Bluetooth Speaker", "Electronics", 49.99m),
                new Product("Coffee Mug", "Kitchen", 12.50m),
                new Product("Laptop", "Electronics", 899.00m),
                new Product("Notebook", "Stationery", 3.75m),
                new Product("Desk Lamp", "Furniture", 29.99m)
            };

            // Sort products by price (ascending)
            products.Sort();

            // Filter products under $50 using LINQ and Lambda
            var affordableProducts = products.Where(p => p.Price < 50).ToList();

            Console.WriteLine("Affordable Products (< $50):");
            foreach (var product in affordableProducts)
            {
                Console.WriteLine(product); // uses overridden ToString()
            }
        }
    }
}
