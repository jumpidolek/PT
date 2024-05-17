using PetStore.Data.Users;
using System;

namespace PetStore.Data.Events
{
    public class Invoice
    {
        public Guid Id { get; set; }
        
        public Customer Customer { get; set; }
        
        public Order Order { get; set; }
    }
}

