using System;
using System.Collections.Generic;
using MarketCRUD.Models;

namespace MarketCRUD.Services.IServices
{
    public interface IMarketService
    {
        public string AddProduct(Market product);
        public string UpdateProduct(Market product);
        public string DeleteProduct(Guid Id);
        public List<Market> GetAllProducts();
        public Market GetProductById(Guid Id);
    }
}
