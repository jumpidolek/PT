using PetStore.Data.Model.Users;
using System;

namespace PetStore.Data.Model.Events
{
    public class Invoice
    {
        public Guid Id { get; set; }
        
        public Users.Customer Customer { get; set; }
        
        public Order Order { get; set; }
    }
}

