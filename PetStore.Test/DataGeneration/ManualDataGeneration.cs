using System;
using System.Collections.Generic;
using PetStore.Model.Users;

namespace PetStore.Test.DataGeneration;

public static class ManualDataGeneration
{
    public static List<Customer> GenerateCustomers()
    {
        return
        [
            new Customer { FirstName = "Maddy", LastName = "Chaplin",  DeliveryAddress = "1234 Elm St", BillingInformation = "1234 5678 9012 3456", DateOfBirth = new DateTime(1990, 1, 1), Address = "Elm St", Email = "maddy@gmail.com", Id = Guid.NewGuid(), Phone = "123456789"},
            new Customer { FirstName = "John", LastName = "Doe", Email = "john@gmail.com", Address = "Maple St", Phone = "987654321", DeliveryAddress = "5678 Maple St", BillingInformation = "5678 9012 3456 7890", DateOfBirth = new DateTime(1995, 1, 1), Id = Guid.NewGuid()},
            new Customer { FirstName = "Jane", LastName = "Doe", Email = "jane@gmail.com", DateOfBirth =  new DateTime(1995, 1, 1), Id = Guid.NewGuid(), Address = "Maple St", Phone = "987654321", DeliveryAddress = "5678 Maple St", BillingInformation = "5678 9012 3456 7890"},
        ];
    }
}