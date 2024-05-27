using System;
using PetStore.Model.Users;

namespace PetStore.Model.Events
{
    public class Invoice
    {
        public Guid Id { get; set; }
        
        public Customer Customer { get; set; }
        
        public Order Order { get; set; }
    }
}

