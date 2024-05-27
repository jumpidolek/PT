using PetStore.Data.Model.Events;
using PetStore.Data.Model.Inventory;
using PetStore.Data.Model.Users;
using System.Data.Entity;

namespace PetStore.Data
{
    internal class PetStoreContext : DbContext
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

        // "Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;"

        // "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dymek\\source\\repos\\jumpidolek\\PT\\PetStore.Data\\Instrumention\\PetStore.mdf;Integrated Security=True"
    }
}
