using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.Repository.Repository;

namespace BusinessManagementSystem.BLL.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        public bool DeleteCustomer(Customer customer)
        {
            return _customerRepository.DeleteCustomer(customer);
        }


        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerByID(Customer customer)
        {
            return _customerRepository.GetCustomerByID(customer);
        }

        public bool IsExistCustomer(Customer customer)
        {
            return _customerRepository.IsExistCustomer(customer);
        }

        public bool IsExistCustomerCode(Customer customer)
        {
            return _customerRepository.IsExistCustomerCode(customer);
        }

        public bool IsExistEmail(Customer customer)
        {
            return _customerRepository.IsExistEmail(customer);
        }

        public bool IsExistContact(Customer customer)
        {
            return _customerRepository.IsExistContact(customer);
        }

    }
}
