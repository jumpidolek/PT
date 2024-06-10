using PetStore.Service.Implementation;

namespace PetStore.Model.Models.Users;

public class Customer
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    #region functions

    public static void Add(Customer c, string connectionString)
    {
        Task.Run(() =>
            new CustomerService(c.Id, c.Email, c.Phone, c.Address, c.FirstName, c.LastName, c.DateOfBirth, connectionString).AddCustomer()
            );
    }
        
    public static Customer Get(Guid id, string connectionString)
    {
        return Task.Run(() =>
        {
            var customerService = CustomerService.GetCustomer(id, connectionString);
            return new Customer
            {
                Id = customerService.Id,
                FirstName = customerService.FirstName,
                LastName = customerService.LastName,
                DateOfBirth = customerService.DateOfBirth,
                Email = customerService.Email,
                Phone = customerService.Phone,
                Address = customerService.Address
            };
        }).Result;
    }
    public static List<Customer> GetAll(string connectionString)
    {
        return Task.Run(() =>
        {
            var customerServices = CustomerService.GetCustomers(connectionString);
            return customerServices.Select(customerService => new Customer
            {
                Id = customerService.Id,
                FirstName = customerService.FirstName,
                LastName = customerService.LastName,
                DateOfBirth = customerService.DateOfBirth,
                Email = customerService.Email,
                Phone = customerService.Phone,
                Address = customerService.Address
            }).ToList();
        }).Result;
    }

    public static void Change(Customer c, string connectionString)
    {
        Task.Run(() =>
        {
            var customerService = CustomerService.GetCustomer(c.Id, connectionString);
            customerService.Address = c.Address;
            customerService.Phone = c.Phone;
            customerService.UpdateCustomer();
        });
    }
    public static void Remove(Guid id, string connectionString)
    {
        Task.Run(() => CustomerService.GetCustomer(id, connectionString).DeleteCustomer());
    }
    
    #endregion
}