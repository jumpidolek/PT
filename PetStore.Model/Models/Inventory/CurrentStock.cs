using PetStore.Service.Implementation;

namespace PetStore.Model.Models.Inventory;

public class CurrentStock
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public int Amount { get; set; }
    
    public static void Add(CurrentStock c, string connectionString)
    {
        Task.Run(() => new StockService(c.Id, new ProductService(c.Product.Id, c.Product.Name, c.Product.Description, c.Product.Brand, (Service.API.Category)c.Product.Category, c.Product.Price, (Service.API.PetType)c.Product.PetType, connectionString), c.Amount, connectionString).AddStock());
    }
    public static CurrentStock Get(Guid productId, string connectionString)
    {
        return Task.Run(() =>
        {
            var stockService = StockService.GetStock(productId, connectionString);
            return new CurrentStock
            {
                Id = stockService.Id,
                Product = new Product
                {
                    Id = stockService.Product.Id,
                    Name = stockService.Product.Name,
                    Description = stockService.Product.Description,
                    Brand = stockService.Product.Brand,
                    Category = (Category)stockService.Product.Category,
                    Price = stockService.Product.Price,
                    PetType = (PetType)stockService.Product.PetType
                },
                Amount = stockService.Amount
            };
        }).Result;
    }
    public static List<CurrentStock> GetAll(string connectionString)
    {
        return Task.Run(() =>
        {
            var stockServices = StockService.GetAllStocks(connectionString);
            return stockServices.Select(stockService => new CurrentStock
            {
                Id = stockService.Id,
                Product = new Product
                {
                    Id = stockService.Product.Id,
                    Name = stockService.Product.Name,
                    Description = stockService.Product.Description,
                    Brand = stockService.Product.Brand,
                    Category = (Category)stockService.Product.Category,
                    Price = stockService.Product.Price,
                    PetType = (PetType)stockService.Product.PetType
                },
                Amount = stockService.Amount
            }).ToList();
        }).Result;
    }
    public static void Change(CurrentStock c, string connectionString)
    {
        Task.Run(() =>
        {
            var stock = StockService.GetStock(c.Product.Id, connectionString);
            stock.Amount = c.Amount;
            stock.UpdateStock();
        });
    }
    public static void Remove(Guid productId, string connectionString)
    {
        Task.Run(() => StockService.GetStock(productId, connectionString).DeleteStock());
    }
}