using PetStore.Model.Models.Users;
using PetStore.ViewModel.Repository;

namespace ViewModelTest.DataGeneration;

public class Manual : IDataGeneration
{
    public List<Customer> GenerateCustomers()
    {
        return
        [
            new Customer { FirstName = "Maddy", LastName = "Chaplin", DateOfBirth = new DateTime(1990, 1, 1), Address = "Elm St", Email = "maddy@gmail.com", Id = Guid.NewGuid(), Phone = "123456789"},
            new Customer { FirstName = "John", LastName = "Doe", Email = "john@gmail.com", Address = "Maple St", Phone = "987654321", DateOfBirth = new DateTime(1995, 1, 1), Id = Guid.NewGuid()},
            new Customer { FirstName = "Jane", LastName = "Doe", Email = "jane@gmail.com", DateOfBirth =  new DateTime(1995, 1, 1), Id = Guid.NewGuid(), Address = "Maple St", Phone = "987654321"},
        ];
    }
    
    public IDataRepository GetRepository()
    {
        return new DataRepository(GenerateCustomers(), [], [], [], [], [], []);
    }
}