using PetStore.Data.Events;
using PetStore.Data.Inventory;
using PetStore.Data.Users;
using System.Data.Entity;

namespace PetStore.Data
{
    public class PetStoreContext : DbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<CurrentStock> Stocks { get; set; }
        DbSet<Shipment> Shipments { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Invoice> Invoices { get; set; }

        public PetStoreContext() : base("Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;") { }

    }
}
