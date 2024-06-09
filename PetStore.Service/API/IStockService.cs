using System;

namespace PetStore.Service.API;

public interface IStockService
{
    public Guid Id { get; }
    public IProductService Product { get; }
    public int Amount { get; set; }
    
    public void AddStock();
    public void UpdateStock();
    public void DeleteStock();
}