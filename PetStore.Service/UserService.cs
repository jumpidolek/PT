using PetStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void UpdateEmployeeSalary(Guid id, double salary)
        {
            Employee employee = (from emp in _context.Employees
                                 where emp.Id == id
                                 select emp).First();
            employee.Salary = salary;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeAddress(Guid id, string address)
        {
            Employee employee = (from emp in _context.Employees
                                 where emp.Id == id
                                 select emp).First();
            employee.Address = address;
            _context.SubmitChanges();
        }
        public void UpdateEmployeePosition(Guid id, string position)
        {
            Employee employee = (from emp in _context.Employees
                                 where emp.Id == id
                                 select emp).First();
            employee.Position = position;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeDepartment(Guid id, string department)
        {
            Employee employee = (from emp in _context.Employees
                                 where emp.Id == id
                                 select emp).First();
            employee.Department = department;
            _context.SubmitChanges();
        }
        public void UpdateEmployeeEmail(Guid id, string email)
        {
            Employee employee = (from emp in _context.Employees
                                 where emp.Id == id
                                 select emp).First();
            employee.Email = email;
            _context.SubmitChanges();
        }
        public void UpdateEmployeePhone(Guid id, string phone)
        {
            Employee employee = (from emp in _context.Employees
                                 where emp.Id == id
                                 select emp).First();
            employee.Email = phone;
            _context.SubmitChanges();
        }

        public void RemoveEmployee(Guid id)
        {
            Employee employee = (from emp in _context.Employees
                                where emp.Id == id
                                select emp).First();
            _context.Employees.DeleteOnSubmit(employee);
            _context.SubmitChanges();
        }

        #endregion

    }
}
