using PetStore.Data.Model.Inventory;
using PetStore.Data.Model.Users;
using System;
using System.Collections.Generic;


namespace PetStore.Data.Model.Events
{
    public class Shipment
    {
        
        public Guid Id { get; set; }
        
        public List<Inventory.Product> Product { get; set; }
        
        public Users.Supplier Supplier { get; set; }
    }
}

