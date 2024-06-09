using System;

namespace PetStore.Service.API;

public interface IProductService
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Brand { get; }
    public Category Category { get; }
    public float Price { get; }
    public PetType PetType { get; }

    public void AddProduct();
    public void UpdateName(string name);
    public void UpdateDescription(string description);
    public void UpdateBrand(string brand);
    public void UpdateCategory(Category category);
    public void UpdatePrice(float price);
    public void UpdatePetType(PetType petType);
    public void DeleteProduct();
}