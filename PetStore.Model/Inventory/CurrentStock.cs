namespace PetStore.Model.Inventory
{
    public class CurrentStock
    {
        public Guid Id { get; set; }
        
        public Product Product { get; set; }
        
        public int Amount { get; set; }
    }
}
