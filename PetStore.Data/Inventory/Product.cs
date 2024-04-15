using PetStore.Data.Users;

namespace PetStore.Data.Inventory;

public class Product
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public Category Category { get; set; }
    public List<Supplier> Suppliers { get; set; }
    public float Price { get; set; }
    public PetType PetType { get; set; }
}