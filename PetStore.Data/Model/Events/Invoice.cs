using PetStore.Data.Model.Users;
using System;

namespace PetStore.Data.Model.Events
{
    internal class Invoice
    {
        public Guid Id { get; set; }
        
        public Customer Customer { get; set; }
        
        public Order Order { get; set; }
    }
}

