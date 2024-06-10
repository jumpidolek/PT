using PetStore.Model.Models.Events;
using PetStore.Model.Models.Inventory;
using PetStore.Model.Models.Users;

namespace PetStore.ViewModel.Repository;

public interface IDataRepository
{
    List<Customer> Customers { get; set; }
    List<Supplier> Suppliers { get; }
    List<Product> Products { get; }
    List<CurrentStock> CurrentStocks { get; }
    List<Order> Orders { get; }
    List<Invoice> Invoices { get; }
    List<Shipment> Shipments { get; }
    
    string GetConnectionString(); 
}