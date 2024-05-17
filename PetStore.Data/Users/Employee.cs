using System;


namespace PetStore.Data.Users
{
    public class Employee : User
    {
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Position { get; set; }
        
        public double Salary { get; set; }
        
        public string Department { get; set; }
        
        public DateTime HireDate { get; set; }
    }
}