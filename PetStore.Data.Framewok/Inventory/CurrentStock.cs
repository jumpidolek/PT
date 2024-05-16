using System.Collections.Generic;

namespace PetStore.Data.Inventory
{
    public class CurrentStock
    {
        public Dictionary<Product, int> Products { get; set; } = new Dictionary<Product, int>();
    }
}
