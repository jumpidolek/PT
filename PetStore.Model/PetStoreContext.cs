using System.Data.Entity;
using PetStore.Model.Events;
using PetStore.Model.Inventory;
using PetStore.Model.Users;

namespace PetStore.Model
{
    internal class PetStoreContext()
        : DbContext("Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;")
    {
        private DbSet<Customer>? Customers { get; set; }
        private DbSet<Employee>? Employees { get; set; }
        private DbSet<Supplier>? Suppliers { get; set; }
        private DbSet<Product>? Products { get; set; }
        private DbSet<CurrentStock>? Stocks { get; set; }
        private DbSet<Shipment>? Shipments { get; set; }
        private DbSet<Order>? Orders { get; set; }
        private DbSet<Invoice>? Invoices { get; set; }

        // "Server=localhost\\SQLEXPRESS;Database=PetStore;Trusted_Connection=True;"

        // "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Dymek\\source\\repos\\jumpidolek\\PT\\PetStore.Data\\Instrumention\\PetStore.mdf;Integrated Security=True"
    }
}
