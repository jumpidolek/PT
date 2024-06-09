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
    PetType petType)
    : IProductService
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public string Description { get; } = description;
    public string Brand { get; } = brand;
    public Category Category { get; } = category;
    public float Price { get; } = price;
    public PetType PetType { get; } = petType;

    private readonly PetStoreDataContext _context = new();
    
    public void AddProduct()
    {
        _context.Products.InsertOnSubmit(new Product
        {
            Id = id,
            Name = name,
            Description = description,
            Brand = brand,
            Category = (int)category,
            Price = price,
            PetType = (int)petType
        });
        _context.SubmitChanges();
    }
    public void UpdateName(string name)
    {
    var product = _context.Products.First(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Name = name;
        _context.SubmitChanges();
    }
    public void UpdateDescription(string description)
    {
        var product = (from p in _context.Products
            where p.Id == id
            select p).First();
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Description = description;
        _context.SubmitChanges();
    }
    public void UpdateBrand(string brand)
    {
        var product = _context.Products.First(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Brand = brand;
        _context.SubmitChanges();
    }
    public void UpdateCategory(Category category)
    {
        var product = _context.Products.First(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Category = (int)category;
        _context.SubmitChanges();
    }
    public void UpdatePrice(float price)
    {
        var product = _context.Products.First(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.Price = price;
        _context.SubmitChanges();
    }
    public void UpdatePetType(PetType petType)
    {
        var product = _context.Products.First(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        product.PetType = (int)petType;
        _context.SubmitChanges();
    }
    public void DeleteProduct()
    {
        var product = _context.Products.First(p => p.Id == id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        _context.Products.DeleteOnSubmit(product);
        _context.SubmitChanges();
    }
    
    public static List<IProductService> GetProducts()
    {
        var context = new PetStoreDataContext();
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
                (PetType)product.PetType));
        }
        return productServices;
    }
    public static IProductService GetProduct(Guid id)
    {
        var context = new PetStoreDataContext();
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
            (PetType)product.PetType);
    }
}