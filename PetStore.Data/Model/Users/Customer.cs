﻿using System;


namespace PetStore.Data.Model.Users
{
    internal class Customer : User
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string DeliveryAddress { get; set; }
        
        public string BillingInformation { get; set; }
        
        public DateTime DateOfBirth { get; set; }
    }
}