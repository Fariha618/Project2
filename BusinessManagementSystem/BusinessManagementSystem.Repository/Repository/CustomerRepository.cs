using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.DatabaseContext.DatabaseContext;


namespace BusinessManagementSystem.Repository.Repository
{
    public class CustomerRepository
    {
        BusinessDbContext db = new BusinessDbContext();

        public bool AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);

            int isExecuted = 0;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;

        }

        public bool UpdateCustomer(Customer customer)
        {
            int isExecuted = 0;

            db.Entry(customer).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCustomer(Customer customer)
        {
            int isExecuted = 0;
            Customer aCustomer = db.Customers.FirstOrDefault(c => c.ID == customer.ID);

            db.Customers.Remove(aCustomer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }

        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer GetCustomerByID(Customer customer)
        {
            Customer acustomer = db.Customers.FirstOrDefault(c => c.ID == customer.ID);
            return acustomer;
        }

        public bool IsExistCustomer(Customer customer)
        {
            if (db.Customers.Any(c => c.Name == customer.Name && c.ID != customer.ID))
            {
                return true;
            }

            return false;
        }

        public bool IsExistCustomerCode(Customer customer)
        {
            if (db.Customers.Any(c => c.Code == customer.Code && c.ID != customer.ID))
            {
                return true;
            }

            return false;
        }

        public bool IsExistEmail(Customer customer)
        {
            if (db.Customers.Any(c => c.Email == customer.Email && c.ID != customer.ID))
            {
                return true;
            }

            return false;
        }

        public bool IsExistContact(Customer customer)
        {
            if (db.Customers.Any(c => c.Contact == customer.Contact && c.ID != customer.ID))
            {
                return true;
            }

            return false;
        }
    }
}
