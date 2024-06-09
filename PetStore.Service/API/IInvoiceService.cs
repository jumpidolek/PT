using System;

namespace PetStore.Service.API;

public interface IInvoiceService
{
    public Guid Id { get; set; }
    public ICustomerService Customer { get; set; }
    public IOrderService Order { get; set; }
    
    public void AddInvoice();
}