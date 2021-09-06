using System.Collections.Generic;

namespace StoreWebAPI.Models.DB
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public List<Product> Products { get; set; }
    }
}
