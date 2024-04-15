using PetStore.Data.Inventory;

namespace PetStore.Data.Events;

public class Order
{
    public Dictionary<Product, int> Products { get; set; }
    public string PromoCode { get; set; }
    public float ShippingCost { get; set; }
    public float Total { get; set; }
}