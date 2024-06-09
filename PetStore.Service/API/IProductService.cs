using System;

namespace PetStore.Service.API;

public interface IProductService
{
    public Guid Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public Category Category { get; set; }
    public float Price { get; set; }
    public PetType PetType { get; set; }

    public void AddProduct();
    public void UpdateProduct();
    public void DeleteProduct();
}