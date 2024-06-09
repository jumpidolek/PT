using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class ProductService(
    Guid id,
    string name,
    string description,
    string brand,
    Category category,
    float price,
    PetType petType,
    string connectionString)
    : IProductService
{
    public Guid Id { get; } = id;
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public string Brand { get; set; } = brand;
    public Category Category { get; set; } = category;
    public float Price { get; set; } = price;
    public PetType PetType { get; set; } = petType;

    private readonly PetStoreDataContext _context = new(connectionString);
    
    public void AddProduct()
    {
        _context.Products.InsertOnSubmit(new Product
        {
            Id = Id,
            Name = Name,
            Description = Description,
            Brand = Brand,
            Category = (int)Category,
            Price = Price,
            PetType = (int)PetType
        });
        _context.SubmitChanges();
    }
    public void UpdateProduct()
    {
        var product = _context.Products.First(p => p.Id == Id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Name = Name;
        product.Description = Description;
        product.Brand = Brand;
        product.Category = (int)Category;
        product.Price = Price;
        product.PetType = (int)PetType;
        _context.SubmitChanges();
    }
    public void DeleteProduct()
    {
        var product = _context.Products.First(p => p.Id == Id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        _context.Products.DeleteOnSubmit(product);
        _context.SubmitChanges();
    }
    
    public static List<IProductService> GetProducts(string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
        var productServices = new List<IProductService>();
        foreach (var product in context.Products)
        {
            productServices.Add(new ProductService(
                product.Id,
                product.Name,
                product.Description,
                product.Brand,
                (Category)product.Category,
                product.Price,
                (PetType)product.PetType,
                connectionString));
        }
        return productServices;
    }
    public static IProductService GetProduct(Guid id, string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
        var product = context.Products.First(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        return new ProductService(
            product.Id,
            product.Name,
            product.Description,
            product.Brand,
            (Category)product.Category,
            product.Price,
            (PetType)product.PetType,
            connectionString);
    }
}