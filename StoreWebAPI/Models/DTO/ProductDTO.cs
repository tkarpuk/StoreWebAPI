using System;

namespace StoreWebAPI.Models.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime DataAdded { get; set; }

        public int StoreId { get; set; }
    }
}
