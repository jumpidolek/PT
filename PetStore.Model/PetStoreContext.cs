using System.Data.Entity;
using PetStore.Model.Events;
using PetStore.Model.Inventory;
using PetStore.Model.Users;

namespace PetStore.Model;

public class PetStoreContext() : DbContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\natik\\RiderProjects\\PT\\PetStore.Test\\Instrumentation\\PetStore.mdf;Integrated Security=True")
{
    private DbSet<Customer> Customers { get; set; }
    private DbSet<Supplier> Suppliers { get; set; }
    private DbSet<Product> Products { get; set; }
    private DbSet<CurrentStock> Stocks { get; set; }
    private DbSet<Shipment> Shipments { get; set; }
    private DbSet<Order> Orders { get; set; }
    private DbSet<Invoice> Invoices { get; set; }

    // "Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;"

    // "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\Users\natik\RiderProjects\PT\PetStore.Test\Instrumentation\PetStore.mdf;Integrated Security=True"
}