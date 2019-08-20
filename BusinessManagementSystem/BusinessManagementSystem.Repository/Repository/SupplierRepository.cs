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
    public class SupplierRepository
    {
        BusinessDbContext db = new BusinessDbContext();

        public bool AddSupplier(Supplier supplier)
        {
            db.Suppliers.Add(supplier);

            int isExecuted = 0;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;

        }

        public bool UpdateSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            db.Entry(supplier).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            int isExecuted = 0;
            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.ID == supplier.ID);

            db.Suppliers.Remove(aSupplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }

        public List<Supplier> GetAllSuppliers()
        {
            return db.Suppliers.ToList();
        }

        public Supplier GetSupplierByID(Supplier supplier)
        {
            Supplier asupplier = db.Suppliers.FirstOrDefault(c => c.ID == supplier.ID);
            return asupplier;
        }

        public bool IsExistSupplier(Supplier supplier)
        {
            if (db.Suppliers.Any(c => c.Name == supplier.Name && c.ID != supplier.ID))
            {
                return true;
            }

            return false;
        }

        public bool IsExistSupplierCode(Supplier supplier)
        {
            if (db.Suppliers.Any(c => c.Code == supplier.Code && c.ID != supplier.ID))
            {
                return true;
            }

            return false;
        }

        public bool IsExistEmail(Supplier supplier)
        {
            if (db.Suppliers.Any(c => c.Email == supplier.Email && c.ID != supplier.ID))
            {
                return true;
            }

            return false;
        }

        public bool IsExistContact(Supplier supplier)
        {
            if (db.Suppliers.Any(c => c.Contact == supplier.Contact && c.ID != supplier.ID))
            {
                return true;
            }

            return false;
        }
    }
}
