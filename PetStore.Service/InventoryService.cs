using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Model.Inventory;
using static PetStore.Service.Conversions.ToDbObjectConverter;
using static PetStore.Service.Conversions.ToModelObjectConverter;

namespace PetStore.Service
{
    public class InventoryService
    {
        private readonly Data.PetStoreDataContext _context;
        public InventoryService(Data.PetStoreDataContext context) { _context = context; }

        #region product

        public void AddProduct(Product product)
        {
            _context.Products.InsertOnSubmit(ToDb(product));
            _context.SubmitChanges();
            
            AddProductStock(product.Id);
        }

        public Product GetProduct(Guid id)
        {
            return ToModel((from p in _context.Products 
                where p.Id == id
                select p).First());
        }
        public List<Product> GetProducts()
        {
            return (from p in _context.Products
                select p).AsEnumerable().Select(ToModel).ToList();
        }

        public void UpdateProductDescription(Guid id, string description)
        {
            var product = (from p in _context.Products
                where p.Id == id
                select p).First();
            product.Description = description;
            _context.SubmitChanges();
        }
        public void UpdateProductCategory(Guid id, Category category)
        {
            var product = (from p in _context.Products 
                where p.Id == id
                select p).First();
            product.Category = (int)category;
            _context.SubmitChanges();
        }
        public void UpdateProductPrice(Guid id, float price)
        {
            var product = (from p in _context.Products 
                where p.Id == id
                select p).First();
            product.Price = price;
            _context.SubmitChanges();
        }
        public void UpdateProductPetType(Guid id, PetType petType)
        {
            var product = (from p in _context.Products 
                where p.Id == id
                select p).First();
            product.PetType = (int)petType;
            _context.SubmitChanges();
        }
        
        public void RemoveProduct(Guid id)
        {
            var product = (from p in _context.Products 
                where p.Id == id
                select p).First();
            _context.Products.DeleteOnSubmit(product);
            _context.SubmitChanges();
            
            RemoveProductStock(id);
        }
        
        #endregion

        #region stock

        public void AddProductStock(Guid productId)
        {
            var stock = new Data.CurrentStock
            {
                Product = (from p in _context.Products 
                    where p.Id == productId
                    select p).First(),
                Amount = 0
            };
            _context.CurrentStocks.InsertOnSubmit(stock);
            _context.SubmitChanges();
        }
        
        public CurrentStock GetProductStock(Guid productId)
        {
            return ToModel((from stock in _context.CurrentStocks
                    where stock.Product.Id == productId
                    select stock).First());
        }
        public List<CurrentStock> GetProductStocks()
        {
            return (from stock in _context.CurrentStocks
                    select stock).AsEnumerable().Select(ToModel).ToList();
        }
        
        public void UpdateProductStockAddAmount(Guid productId, int amount)
        {
            var stock = (from st in _context.CurrentStocks
                where st.Product.Id == productId
                select st).First();
            stock.Amount += amount;
            _context.SubmitChanges();
        }
        public void UpdateProductStockRemoveAmount(Guid productId, int amount)
        {
            var stock = (from st in _context.CurrentStocks
                where st.Product.Id == productId
                select st).First();
            stock.Amount -= amount;
            _context.SubmitChanges();
        }
        
        public void RemoveProductStock(Guid productId)
        {
            var stock = (from st in _context.CurrentStocks
                where st.Product.Id == productId
                select st).First();
            _context.CurrentStocks.DeleteOnSubmit(stock);
            _context.SubmitChanges();
        }

        #endregion
    }
}