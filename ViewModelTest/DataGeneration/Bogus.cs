using Bogus;
using PetStore.Model.Models.Users;
using PetStore.ViewModel.Repository;

namespace ViewModelTest.DataGeneration;

public class Bogus : IDataGeneration
{
    public List<Customer> GenerateCustomers()
    {
        return new Faker<Customer>()
            .RuleFor(c => c.Id, _ => Guid.NewGuid())
            .RuleFor(c => c.FirstName, f => f.Person.FirstName)
            .RuleFor(c => c.LastName, f => f.Person.LastName)
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.Phone, f => f.Person.Phone)
            .RuleFor(c => c.DateOfBirth, f => f.Person.DateOfBirth)
            .Generate(10);
    }

    public IDataRepository GetRepository()
    {
        return new DataRepository(GenerateCustomers(), [], [], [], [], [], []);
    }
}