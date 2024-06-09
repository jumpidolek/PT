using System;
using System.Collections.Generic;

namespace PetStore.Service.API;

public interface IShipmentService
{
    public Guid Id { get; }
    public List<IProductService> Products { get; }
    public ISupplierService Supplier { get; }
    
    public void AddShipment();
}