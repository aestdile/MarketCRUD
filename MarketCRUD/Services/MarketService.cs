using System;
using System.Collections.Generic;
using System.Globalization;
using MarketCRUD.Models;
using MarketCRUD.Services.IServices;

namespace MarketCRUD.Services
{
    class MarketService : IMarketService
    {
        public List<Market> Mahsulotlar { get; set; } = new List<Market>();
        public string AddProduct(Market product)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty.");
            }
            else if (name.Length > 20)
            {
                Console.WriteLine("Name cannot be more than 20 characters.");
            }
            else if (name.Length < 3)
            {
                Console.WriteLine("Name cannot be less than 3 characters.");
            }
            else if (!char.IsUpper(name[0]))
            {
                Console.WriteLine("Name must start with an uppercase letter.");
            }
            else if (name.Contains(" "))
            {
                Console.WriteLine("Name cannot contain spaces.");
            }
            else
            {
                product.Name = name;
            }
            Console.Write("Enter Cost: ");
            Console.Write("Enter Cost: ");
            double cost = Convert.ToDouble(Console.ReadLine());
            if (cost < 0)
            {
                Console.WriteLine("Cost cannot be negative.");
            }
            else if (cost == 0)
            {
                Console.WriteLine("Cost cannot be zero.");
            }
            else if (!double.TryParse(Console.ReadLine(), out cost))
            {
                Console.WriteLine("Invalid cost. Please enter a valid number.");
            }
            else
            {
                product.Cost = cost;
            }
            Console.WriteLine("Enter Made Date (YYYY-MM-DD): ");
            Console.Write("YYYY: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("MM: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("DD: ");
            int day = Convert.ToInt32(Console.ReadLine());
            product.MadeDate = new DateTime(year, month, day);
            Console.Write("Enter Expiration Date (YYYY-MM-DD): ");
            Console.Write("YYYY: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("MM: ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("DD: ");
            day = Convert.ToInt32(Console.ReadLine());
            product.ExpirationDate = new DateTime(year, month, day);
            Mahsulotlar.Add(product);
            return "Product Added Successfully";
        }

        public string DeleteProduct(Guid Id)
        {
            Market product = Mahsulotlar.Find(x => x.Id == Id);
            if (product != null)
            {
                Mahsulotlar.Remove(product);
                return "Product Deleted Successfully";
            }
            return "Product Not Found";
        }

        public List<Market> GetAllProducts()
        {
            if (Mahsulotlar.Count == 0)
            {
                Console.WriteLine("No products available.");
                return null;
            }
            Console.Write("Todays Date: ");
            DateTime today = DateTime.Now;
            foreach (var product in Mahsulotlar)
            {
                if (product.ExpirationDate < today)
                {
                    Console.WriteLine($"Product {product.Name} has expired.");
                    product.IsExpired = true;
                }
                else
                {
                    Console.WriteLine($"Product {product.Name} is valid.");
                    product.IsExpired = false;
                }
            }
            return Mahsulotlar;
        }

        public Market GetProductById(Guid Id)
        {
            Market product = Mahsulotlar.Find(x => x.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public string UpdateProduct(Market product)
        {
            Market product1 = Mahsulotlar.Find(x => x.Id == product.Id);
            if (product1 != null)
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                }
                else if (name.Length > 20)
                {
                    Console.WriteLine("Name cannot be more than 20 characters.");
                }
                else if (name.Length < 3)
                {
                    Console.WriteLine("Name cannot be less than 3 characters.");
                }
                else if (!char.IsUpper(name[0]))
                {
                    Console.WriteLine("Name must start with an uppercase letter.");
                }
                else if (name.Contains(" "))
                {
                    Console.WriteLine("Name cannot contain spaces.");
                }
                else
                {
                    product1.Name = name;
                }
                Console.Write("Enter Cost: ");
                double cost = Convert.ToDouble(Console.ReadLine());
                if (cost < 0)
                {
                    Console.WriteLine("Cost cannot be negative.");
                }
                else if (cost == 0)
                {
                    Console.WriteLine("Cost cannot be zero.");
                }
                else if (!double.TryParse(Console.ReadLine(), out cost))
                {
                    Console.WriteLine("Invalid cost. Please enter a valid number.");
                }
                else
                {
                    product1.Cost = cost;
                }
                Console.WriteLine("Enter Made Date (YYYY-MM-DD): ");
                Console.Write("YYYY: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("MM: ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.Write("DD: ");
                int day = Convert.ToInt32(Console.ReadLine());
                product1.MadeDate = new DateTime(year, month, day);
                Console.Write("Enter Expiration Date (YYYY-MM-DD): ");
                Console.Write("YYYY: ");
                year = Convert.ToInt32(Console.ReadLine());
                Console.Write("MM: ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write("DD: ");
                day = Convert.ToInt32(Console.ReadLine());
                product1.ExpirationDate = new DateTime(year, month, day);
                return "Product Updated Successfully";
            }
            return "Product Not Found";
        }
    }
}