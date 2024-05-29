using System;
using System.Collections.Generic;
using PetStore.Model.Inventory;
using PetStore.Model.Users;

namespace PetStore.Model.Events;

public class Shipment
{
    public Guid Id { get; set; }
    public List<Product> Products { get; set; }
    public Supplier Supplier { get; set; }
}