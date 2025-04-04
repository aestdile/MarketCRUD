using System;

namespace MarketCRUD.Models
{
    public class Market
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public DateTime MadeDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
