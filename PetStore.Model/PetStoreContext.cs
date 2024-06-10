using Microsoft.EntityFrameworkCore;
using PetStore.Model.Models.Events;
using PetStore.Model.Models.Inventory;
using PetStore.Model.Models.Users;

namespace PetStore.Model;

public class PetStoreContext : DbContext
{
    private DbSet<Customer> Customers { get; set; }
    private DbSet<Supplier> Suppliers { get; set; }
    private DbSet<Product> Products { get; set; }
    private DbSet<CurrentStock> Stocks { get; set; }
    private DbSet<Shipment> Shipments { get; set; }
    private DbSet<Order> Orders { get; set; }
    private DbSet<Invoice> Invoices { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\natik\RiderProjects\PT\ServiceTest\Instrumentation\PetStoreServiceTest.mdf;Integrated Security=True");
    }

    // "Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;TrustServerCertificate=True;"
    // "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\Users\natik\RiderProjects\PT\PetStore.Test\Instrumentation\PetStore.mdf;Integrated Security=True"
}