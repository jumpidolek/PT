using System;

namespace PetStore.Service.API;

public interface IInvoiceService
{
    public Guid Id { get; }
    public ICustomerService Customer { get; }
    public IOrderService Order { get; }
    
    public void AddInvoice();
}