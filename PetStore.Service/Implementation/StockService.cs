using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Data;
using PetStore.Service.API;

namespace PetStore.Service.Implementation;

public class StockService(Guid id, IProductService product, int amount, string connectionString) : IStockService
{
    public Guid Id { get; } = id;
    public IProductService Product { get; } = product;
    public int Amount { get; set; } = amount;

    private readonly PetStoreDataContext _context = new(connectionString);
    
    public void AddStock()
    {
        var product = _context.Products.First(p => p.Id == Product.Id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        _context.CurrentStocks.InsertOnSubmit(new CurrentStock
        {
            Id = Id,
            Product = product,
            Amount = Amount
        });
        _context.SubmitChanges();
    }
    public void UpdateStock()
    {
        var stock = _context.CurrentStocks.First(s => s.Id == Id);
        if (stock == null)
        {
            throw new Exception("Stock not found");
        }
        stock.Amount = Amount;
        _context.SubmitChanges();
    }
    public void DeleteStock()
    {
        var stock = _context.CurrentStocks.First(s => s.Id == Id);
        if (stock == null)
        {
            throw new Exception("Stock not found");
        }
        _context.CurrentStocks.DeleteOnSubmit(stock);
        _context.SubmitChanges();
    }
    
    public static List<IStockService> GetAllStocks(string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
        var stocks = new List<IStockService>();
        foreach (var stock in context.CurrentStocks)
        {
            stocks.Add(new StockService(
                stock.Id, 
                new ProductService(
                    stock.Product.Id, 
                    stock.Product.Name, 
                    stock.Product.Description, 
                    stock.Product.Brand, 
                    (Category)stock.Product.Category,
                    stock.Product.Price, 
                    (PetType)stock.Product.PetType,
                    connectionString), 
                stock.Amount,
                connectionString));
        }
        return stocks;
    }
    public static IStockService GetStock(Guid productId, string connectionString)
    {
        var context = new PetStoreDataContext(connectionString);
        var stock = context.CurrentStocks.First(s => s.Product.Id == productId);
        if (stock == null)
        {
            throw new Exception("Stock not found");
        }
        return new StockService(
            stock.Id, 
            new ProductService(
                stock.Product.Id, 
                stock.Product.Name, 
                stock.Product.Description, 
                stock.Product.Brand, 
                (Category)stock.Product.Category,
                stock.Product.Price, 
                (PetType)stock.Product.PetType,
                connectionString), 
            stock.Amount,
            connectionString);
    }
}