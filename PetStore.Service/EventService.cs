using System;
using System.Collections.Generic;
using System.Linq;
using PetStore.Data.Model.Events;

using static PetStore.Service.Conversions.ToDbObjectConverter;
using static PetStore.Service.Conversions.ToModelObjectConverter;

namespace PetStore.Service
{
    public class EventService
    {
        private readonly Data.PetStoreDataContext _context;
        public EventService(Data.PetStoreDataContext context) { _context = context; }

        #region order

        public void AddOrder(Order order)
        {
            _context.Orders.InsertOnSubmit(ToDb(order));
            _context.SubmitChanges();
        }
        
        public Order GetOrder(Guid id)
        {
            return ToModel((from ord in _context.Orders
                   where ord.Id == id
                   select ord).First());
        }
        public List<Order> GetOrders()
        {
            return (from ord in _context.Orders
                    select ord).AsEnumerable().Select(ToModel).ToList();
        }

        #endregion

        #region invoice

        public void AddInvoice(Invoice invoice)
        {
            _context.Invoices.InsertOnSubmit(ToDb(invoice));
            _context.SubmitChanges();
        }
        
        public Invoice GetInvoice(Guid id)
        {
            return ToModel((from inv in _context.Invoices
                   where inv.Id == id
                   select inv).First());
        }
        public List<Invoice> GetInvoices()
        {
            return (from inv in _context.Invoices
                    select inv).AsEnumerable().Select(ToModel).ToList();
        }

        #endregion

        #region shipment

        public void AddShipment(Shipment shipment)
        {
            _context.Shipments.InsertOnSubmit(ToDb(shipment));
            _context.SubmitChanges();
        }
        
        public Shipment GetShipment(Guid id)
        {
            return ToModel((from ship in _context.Shipments
                   where ship.Id == id
                   select ship).First());
        }
        public List<Shipment> GetShipments()
        {
            return (from ship in _context.Shipments
                select ship).AsEnumerable().Select(ToModel).ToList();
        }

        #endregion
    }
}