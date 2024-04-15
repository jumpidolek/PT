using PetStore.Data.Inventory;
using PetStore.Data.Users;

namespace PetStore.Data.Events;

public class Shipment
{
    public Guid Id { get; init; }
    public Dictionary<Product, int> Products { get; set; }
    public Supplier Supplier { get; set; }
}