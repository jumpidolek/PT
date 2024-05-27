using PetStore.Data.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PetStore.Service.Conversions;

using static PetStore.Service.Conversions.ToDbObjectConverter;
using static PetStore.Service.Conversions.ToModelObjectConverter;

namespace PetStore.Service
{
    public class UserService
    {
        private readonly Data.PetStoreDataContext _context;
        public UserService(Data.PetStoreDataContext context) { _context = context; }

        #region employee

        public void AddEmployee(Employee employee)
        {
            _context.Employees.InsertOnSubmit(ToDb(employee));
            _context.SubmitChanges();
        }

        public Employee GetEmployee(Guid id)
        {
            return ToModel((from emp in _context.Employees
                   where emp.Id == id
                   select emp).First());
        }
        public List<Employee> GetEmployees()
        {
            return (from emp in _context.Employees
                    select emp).AsEnumerable().Select(ToModel).ToList();
        }

        public void UpdateEmployeeSalary(Guid id, double salary)
        {
            var employee = (from emp in _context.Employees
                where emp.Id == id
                select emp).First();
            employee.Salary = salary;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeAddress(Guid id, string address)
        {
            var employee = (from emp in _context.Employees
                where emp.Id == id
                select emp).First();
            employee.Address = address;
            _context.SubmitChanges();
        }
        public void UpdateEmployeePosition(Guid id, string position)
        {
            var employee = (from emp in _context.Employees
                where emp.Id == id
                select emp).First();
            employee.Position = position;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeDepartment(Guid id, string department)
        {
            var employee = (from emp in _context.Employees
                where emp.Id == id
                select emp).First();
            employee.Department = department;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeEmail(Guid id, string email)
        {
            var employee = (from emp in _context.Employees
                where emp.Id == id
                select emp).First();
            employee.Email = email;
            _context.SubmitChanges();
        }
        public void UpdateEmployeePhone(Guid id, string phone)
        {
            var employee = (from emp in _context.Employees
                where emp.Id == id
                select emp).First();
            employee.Email = phone;
            _context.SubmitChanges();
        }

        public void RemoveEmployee(Guid id)
        {
            var employee = (from emp in _context.Employees
                where emp.Id == id
                select emp).First();
            _context.Employees.DeleteOnSubmit(employee);
            _context.SubmitChanges();
        }

        #endregion

        #region customer

        public void AddCustomer(Customer customer)
        {
            _context.Customers.InsertOnSubmit(ToDb(customer));
            _context.SubmitChanges();
        }

        public Customer GetCustomer(Guid id)
        {
            return ToModel((from customer in _context.Customers
                    where customer.Id == id
                    select customer).First());
        }
        public List<Customer> GetCustomers()
        {
            return (from customer in _context.Customers
                select customer).AsEnumerable().Select(ToModel).ToList();
        }

        public void UpdateCustomerAddress(Guid id, string address)
        {
            var customer = (from cust in _context.Customers
                where cust.Id == id
                select cust).First();
            customer.Address = address;
            _context.SubmitChanges();
        }
        public void UpdateCustomerDeliveryAddress(Guid id, string address)
        {
            var customer = (from cust in _context.Customers
                where cust.Id == id
                select cust).First();
            customer.DeliveryAddress = address;
            _context.SubmitChanges();
        }
        public void UpdateCustomerBillingInformation(Guid id, string billingInformation)
        {
            var customer = (from cust in _context.Customers
                where cust.Id == id
                select cust).First();
            customer.BillingInformation = billingInformation;
            _context.SubmitChanges();
        }
        public void UpdateCustomerPhone(Guid id, string phone)
        {
            var customer = (from cust in _context.Customers
                where cust.Id == id
                select cust).First();
            customer.Phone = phone;
            _context.SubmitChanges();
        }

        public void RemoveCustomer(Guid id)
        { 
            var customer = (from cust in _context.Customers
                where cust.Id == id
                select cust).First();
            _context.Customers.DeleteOnSubmit(customer);
            _context.SubmitChanges();
        }

        #endregion

        #region supplier

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.InsertOnSubmit(ToDb(supplier));
            _context.SubmitChanges();
        }

        public Supplier GetSupplier(Guid id)
        {
            return ToModel((from sup in _context.Suppliers
                    where sup.Id == id
                    select sup).First());
        }
        public List<Supplier> GetSuppliers()
        {

            return (from sup in _context.Suppliers
                select sup).AsEnumerable().Select(ToModel).ToList();
        }

        public void UpdateSupplierEmail(Guid id, string email)
        {
            var supplier = (from sup in _context.Suppliers
                where sup.Id == id
                select sup).First();
            supplier.Email = email;
            _context.SubmitChanges();
        }
        public void UpdateSupplierPhone(Guid id, string phone)
        {
            var supplier = (from sup in _context.Suppliers
                where sup.Id == id
                select sup).First();
            supplier.Phone = phone;
            _context.SubmitChanges();
        }
        public void UpdateSupplierAddress(Guid id, string address)
        {
            var supplier = (from sup in _context.Suppliers
                where sup.Id == id
                select sup).First();
            supplier.Address = address;
            _context.SubmitChanges();
        }
        public void UpdateSupplierName(Guid id, string name)
        {
            var supplier = (from sup in _context.Suppliers
                where sup.Id == id
                select sup).First();
            supplier.Name = name;
            _context.SubmitChanges();
        }

        public void RemoveSupplier(Guid id) 
        {
            var supplier = (from sup in _context.Suppliers
                where sup.Id == id
                select sup).First();
            _context.Suppliers.DeleteOnSubmit(supplier);
            _context.SubmitChanges();
        }

        #endregion

    }
}
