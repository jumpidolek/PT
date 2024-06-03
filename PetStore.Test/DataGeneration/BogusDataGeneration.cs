using System;
using System.Collections.Generic;
using Bogus;
using PetStore.Data;

namespace PetStore.Test.DataGeneration;

public static class BogusDataGeneration
{
    public static List<Model.Users.Customer> CreateCustomers()
    {
        return new Faker<Model.Users.Customer>()
            .RuleFor(c => c.Id, _ => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.Phone, f => f.Person.Phone)
            .RuleFor(c => c.DeliveryAddress, f => f.Address.FullAddress())
            .RuleFor(c => c.BillingInformation, f => f.Finance.CreditCardNumber())
            .RuleFor(c => c.DateOfBirth, f => f.Person.DateOfBirth)
            .Generate(5);
    }
}