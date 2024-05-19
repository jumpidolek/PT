using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PetStore.Data.Model.Inventory
{
    internal class CurrentStock
    {
        public Guid Id { get; set; }
        
        public Product Product { get; set; }
        
        public int Amount { get; set; }
    }
}
