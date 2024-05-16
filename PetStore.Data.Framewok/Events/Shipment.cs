using PetStore.Data.Inventory;
using PetStore.Data.Users;
using System;
using System.Collections.Generic;

namespace PetStore.Data.Events
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public Dictionary<Product, int> Products { get; set; }
        public Supplier Supplier { get; set; }
    }
}

