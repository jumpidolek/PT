using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Service.Implementation;

namespace PetStore.Model.Models.Inventory;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public Category Category { get; set; }
    public float Price { get; set; }
    public PetType PetType { get; set; }
    
    public static void Add(Product c)
    {
        Task.Run(() => new ProductService(c.Id, c.Name, c.Description, c.Brand, (Service.API.Category)c.Category, c.Price, (Service.API.PetType)c.PetType).AddProduct());
    }
    public static Product Get(Guid id)
    {
        return Task.Run(() =>
        {
            var productService = ProductService.GetProduct(id);
            return new Product
            {
                Id = productService.Id,
                Name = productService.Name,
                Description = productService.Description,
                Brand = productService.Brand,
                Category = (Category)productService.Category,
                Price = productService.Price,
                PetType = (PetType)productService.PetType
            };
        }).Result;
    }
    public static List<Product> GetAll()
    {
        return Task.Run(() =>
        {
            var productServices = ProductService.GetProducts();
            return productServices.Select(productService => new Product
            {
                Id = productService.Id,
                Name = productService.Name,
                Description = productService.Description,
                Brand = productService.Brand,
                Category = (Category)productService.Category,
                Price = productService.Price,
                PetType = (PetType)productService.PetType
            }).ToList();
        }).Result;
    }
    public static void ChangeName(Guid id, string name)
    {
        Task.Run(() => ProductService.GetProduct(id).UpdateName(name));
    }
    public static void ChangeDescription(Guid id, string description)
    {
        Task.Run(() => ProductService.GetProduct(id).UpdateDescription(description));
    }
    public static void ChangeBrand(Guid id, string brand)
    {
        Task.Run(() => ProductService.GetProduct(id).UpdateBrand(brand));
    }
    public static void ChangeCategory(Guid id, Category category)
    {
        Task.Run(() => ProductService.GetProduct(id).UpdateCategory((Service.API.Category)category));
    }
    public static void ChangePrice(Guid id, float price)
    {
        Task.Run(() => ProductService.GetProduct(id).UpdatePrice(price));
    }
    public static void ChangePetType(Guid id, PetType petType)
    {
        Task.Run(() => ProductService.GetProduct(id).UpdatePetType((Service.API.PetType)petType));
    }
    public static void RemoveProduct(Guid id)
    {
        Task.Run(() => ProductService.GetProduct(id).DeleteProduct());
    }
}