using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.Repository.Repository;

namespace BusinessManagementSystem.BLL.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public bool AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplier);
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            return _supplierRepository.DeleteSupplier(supplier);
        }


        public List<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAllSuppliers();
        }

        public Supplier GetSupplierByID(Supplier supplier)
        {
            return _supplierRepository.GetSupplierByID(supplier);
        }

        public bool IsExistSupplier(Supplier supplier)
        {
            return _supplierRepository.IsExistSupplier(supplier);
        }

        public bool IsExistSupplierCode(Supplier supplier)
        {
            return _supplierRepository.IsExistSupplierCode(supplier);
        }

        public bool IsExistEmail(Supplier supplier)
        {
            return _supplierRepository.IsExistEmail(supplier);
        }

        public bool IsExistContact(Supplier supplier)
        {
            return _supplierRepository.IsExistContact(supplier);
        }
    }
}
