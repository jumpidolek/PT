namespace PetStore.Model.Inventory
{
    public class Product
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Brand { get; set; }
        
        public Category Category { get; set; }
        
        public float Price { get; set; }
        
        public PetType PetType { get; set; }
    }
}