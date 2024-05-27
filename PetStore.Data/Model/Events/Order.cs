using PetStore.Data.Model.Inventory;
using System;
using System.Collections.Generic;


namespace PetStore.Data.Model.Events
{
    public class Order
    {
        public Guid Id { get; set; }
        
        public List<Inventory.Product> Product { get; set; }
        
        public string PromoCode { get; set; }
        
        public float ShippingCost { get; set; }
        
        public float Total { get; set; }
    }
}