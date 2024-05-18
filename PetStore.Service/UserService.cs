using PetStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Service
{
    internal class UserService
    {
        private PetStoreDataContext _context = new PetStoreDataContext();

        #region employee

        public void AddEmployee(Employee employee)
        {
            _context.Employees.InsertOnSubmit(employee);
            _context.SubmitChanges();
        }

        public Employee GetEmployee(Guid id)
        {
            return (from emp in _context.Employees
                   where emp.Id == id
                   select emp).First();
        }
        public List<Employee> GetEmployees()
        {
            return (from emp in _context.Employees
                    select emp).ToList();
        }

        public void UpdateEmployeeSalary(Guid id, double salary)
        {
            Employee employee = GetEmployee(id);
            employee.Salary = salary;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeAddress(Guid id, string address)
        {
            Employee employee = GetEmployee(id);
            employee.Address = address;
            _context.SubmitChanges();
        }
        public void UpdateEmployeePosition(Guid id, string position)
        {
            Employee employee = GetEmployee(id);
            employee.Position = position;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeDepartment(Guid id, string department)
        {
            Employee employee = GetEmployee(id);
            employee.Department = department;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeEmail(Guid id, string email)
        {
            Employee employee = GetEmployee(id);
            employee.Email = email;
            _context.SubmitChanges();
        }
        public void UpdateEmployeePhone(Guid id, string phone)
        {
            Employee employee = GetEmployee(id);
            employee.Email = phone;
            _context.SubmitChanges();
        }

        public void RemoveEmployee(Guid id)
        {
            Employee employee = GetEmployee(id);
            _context.Employees.DeleteOnSubmit(employee);
            _context.SubmitChanges();
        }

        #endregion

        #region customer

        public void AddCustomer(Customer customer)
        {
            _context.Customers.InsertOnSubmit(customer);
            _context.SubmitChanges();
        }

        public Customer GetCustomer(Guid id)
        {
            return (from customer in _context.Customers
                    where customer.Id == id
                    select customer).First();
        }
        public List<Customer> GetCustomers()
        {
            return (from customer in _context.Customers
                   select customer).ToList();
        }

        public void UpdateCustomerAddress(Guid id, string address)
        {
            Customer customer = GetCustomer(id);
            customer.Address = address;
            _context.SubmitChanges();
        }
        public void UpdateCustomerDeliveryAddress(Guid id, string address)
        {
            Customer customer = GetCustomer(id);
            customer.DeliveryAddress = address;
            _context.SubmitChanges();
        }
        public void UpdateCustomerBillingInformation(Guid id, string billingInformation)
        {
            Customer customer = GetCustomer(id);
            customer.BillingInformation = billingInformation;
            _context.SubmitChanges();
        }
        public void UpdateCustomerEmail(Guid id, string email)
        {
            Customer customer = GetCustomer(id);
            customer.Email = email;
            _context.SubmitChanges();
        }
        public void UpdateCustomerPhone(Guid id, string phone)
        {
            Customer customer = GetCustomer(id);
            customer.Phone = phone;
            _context.SubmitChanges();
        }

        public void RemoveCustomer(Guid id)
        { 
            Customer customer = GetCustomer(id);
            _context.Customers.DeleteOnSubmit(customer);
            _context.SubmitChanges();
        }

        #endregion

        #region supplier

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.InsertOnSubmit(supplier);
            _context.SubmitChanges();
        }

        public Supplier GetSupplier(Guid id)
        {
            return (from sup in _context.Suppliers
                    where sup.Id == id
                    select sup).First();
        }
        public List<Supplier> GetSuppliers()
        {
            return (from sup in _context.Suppliers
                    select sup).ToList();
        }

        public void UpdateSupplierEmail(Guid id, string email)
        {
            Supplier supplier = GetSupplier(id);
            supplier.Email = email;
            _context.SubmitChanges();
        }
        public void UpdateSupplierPhone(Guid id, string phone)
        {
            Supplier supplier = GetSupplier(id);
            supplier.Phone = phone;
            _context.SubmitChanges();
        }
        public void UpdateSupplierAddress(Guid id, string address)
        {
            Supplier supplier = GetSupplier(id);
            supplier.Address = address;
            _context.SubmitChanges();
        }

        public void RemoveSupplier(Guid id) 
        {
            Supplier supplier = GetSupplier(id);
            _context.Suppliers.DeleteOnSubmit(supplier);
            _context.SubmitChanges();
        }

        #endregion

    }
}
