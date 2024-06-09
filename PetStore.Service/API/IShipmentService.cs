using System;
using System.Collections.Generic;

namespace PetStore.Service.API;

public interface IShipmentService
{
    public Guid Id { get; set; }
    public List<IProductService> Products { get; set; }
    public ISupplierService Supplier { get; set; }
    
    public void AddShipment();
}