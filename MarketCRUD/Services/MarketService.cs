using System;
using System.Collections.Generic;
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
            product.Name = Console.ReadLine();
            Console.Write("Enter Cost: ");
            product.Cost = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Made Date: ");
            product.MadeDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter Expiration Date: ");
            product.ExpirationDate = Convert.ToDateTime(Console.ReadLine());
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
                product1.Name = Console.ReadLine();
                Console.Write("Enter Cost: ");
                product1.Cost = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Made Date: ");
                product1.MadeDate = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter Expiration Date: ");
                product1.ExpirationDate = Convert.ToDateTime(Console.ReadLine());
                return "Product Updated Successfully";
            }
            return "Product Not Found";
        }
    }
}