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
    
    public static void Add(Product c, string connectionString)
    {
        Task.Run(() => new ProductService(c.Id, c.Name, c.Description, c.Brand, (Service.API.Category)c.Category, c.Price, (Service.API.PetType)c.PetType, connectionString).AddProduct());
    }
    public static Product Get(Guid id, string connectionString)
    {
        return Task.Run(() =>
        {
            var productService = ProductService.GetProduct(id, connectionString);
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
    public static List<Product> GetAll(string connectionString)
    {
        return Task.Run(() =>
        {
            var productServices = ProductService.GetProducts(connectionString);
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

    public static void Change(Product p, string connectionString)
    {
        Task.Run(() =>
        {
            var product = ProductService.GetProduct(p.Id, connectionString);
            product.Name = p.Name;
            product.Description = p.Description;
            product.Brand = p.Brand;
            product.Category = (Service.API.Category)p.Category;
            product.Price = p.Price;
            product.PetType = (Service.API.PetType)p.PetType;
            product.UpdateProduct();
        });
    }
    public static void RemoveProduct(Guid id, string connectionString)
    {
        Task.Run(() => ProductService.GetProduct(id, connectionString).DeleteProduct());
    }
}