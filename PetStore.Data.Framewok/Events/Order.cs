﻿using PetStore.Data.Inventory;
using System;
using System.Collections.Generic;

namespace PetStore.Data.Events
{
    public class Order
    {
        public Guid Id { get; set; }
        public Dictionary<Product, int> Products { get; set; }
        public string PromoCode { get; set; }
        public float ShippingCost { get; set; }
        public float Total { get; set; }
    }
}