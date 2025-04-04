using System;
using MarketCRUD.Services;
using MarketCRUD.Models;

namespace MarketCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            MarketService productService = new MarketService();

            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Delete Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Get Product By Id");
                Console.WriteLine("5. Get All Products");
                Console.WriteLine("6. Exit Programming");
                Console.WriteLine("Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(productService.AddProduct(new Market()));
                        break;
                    case 2:
                        Console.WriteLine("Enter Product ID to delete:");
                        Guid deleteId = Guid.Parse(Console.ReadLine());
                        Console.WriteLine(productService.DeleteProduct(deleteId));
                        break;
                    case 3:
                        Console.WriteLine("Enter Product ID to update:");
                        Guid updateId = Guid.Parse(Console.ReadLine());
                        Market existingProduct = productService.GetProductById(updateId);
                        if (existingProduct != null)
                        {
                            Console.WriteLine(productService.UpdateProduct(existingProduct));
                        }
                        else
                        {
                            Console.WriteLine("Product Not Found");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Product ID:");
                        Guid searchId = Guid.Parse(Console.ReadLine());
                        Market foundProduct = productService.GetProductById(searchId);
                        if (foundProduct != null)
                        {
                            Console.WriteLine($"Name: {foundProduct.Name}, Cost: {foundProduct.Cost}, MadeDate: {foundProduct.MadeDate}, ExprationDate: {foundProduct.ExpirationDate}");
                        }
                        else
                        {
                            Console.WriteLine("Product Not Found");
                        }
                        break;
                    case 5:
                        var products = productService.GetAllProducts();
                        if (products.Count > 0)
                        {
                            foreach (var product in products)
                            {
                                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Cost: {product.Cost}, MadeDate: {product.MadeDate}, ExprationDate: {product.ExpirationDate}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Products Available");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Exit Programming");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}
