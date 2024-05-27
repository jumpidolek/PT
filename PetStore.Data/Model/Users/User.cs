using System;


namespace PetStore.Data.Model.Users
{
    public class User
    {
        
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string Address { get; set; }
    }
}