using System;

namespace StoreWebAPI.Models.DB
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime DataAdded { get; set; }

        public Store Store { get; set; }
        public int StoreId { get; set; }
    }
}
