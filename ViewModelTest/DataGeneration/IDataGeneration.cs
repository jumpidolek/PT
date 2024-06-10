using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetStore.ViewModel.Repository;
using Customer = PetStore.Model.Models.Users.Customer;

namespace ViewModelTest.DataGeneration;

public interface IDataGeneration
{
    protected abstract List<Customer> GenerateCustomers();
    
    public IDataRepository GetRepository();
}