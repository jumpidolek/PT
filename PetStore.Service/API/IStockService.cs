using System;

namespace PetStore.Service.API;

public interface IStockService
{
    public Guid Id { get; set; }
    public IProductService Product { get; set; }
    public int Amount { get; set; }
    
    public void AddStock();
    
    public void UpdateAmount(int amount);
    
    public void DeleteStock();
}