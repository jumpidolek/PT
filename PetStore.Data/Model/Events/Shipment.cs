using PetStore.Data.Model.Inventory;
using PetStore.Data.Model.Users;
using System;
using System.Collections.Generic;


namespace PetStore.Data.Model.Events
{
    internal class Shipment
    {
        
        public Guid Id { get; set; }
        
        public Dictionary<Product, int> Products { get; set; }
        
        public Supplier Supplier { get; set; }
    }
}

