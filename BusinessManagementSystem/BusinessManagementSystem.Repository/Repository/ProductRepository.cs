using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.DatabaseContext.DatabaseContext;

namespace BusinessManagementSystem.Repository.Repository
{
    public class ProductRepository
    {
        BusinessDbContext db = new BusinessDbContext();

        public bool AddProduct(Product product)
        {
            db.Products.Add(product);

            int isExecuted = 0;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;

        }

        public bool UpdateProduct(Product product)
        {
            int isExecuted = 0;

            db.Entry(product).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteProduct(Product product)
        {
            int isExecuted = 0;
            Product aProduct = db.Products.FirstOrDefault(c => c.ID == product.ID);

            db.Products.Remove(aProduct);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }

        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductByID(Product product)
        {
            Product aproduct = db.Products.FirstOrDefault(c => c.ID == product.ID);
            return aproduct;
        }

        public bool IsExistProduct(Product product)
        {
            if (db.Products.Any(c => c.Name == product.Name && c.ID != product.ID))
            {
                return true;
            }

            return false;
        }

        public bool IsExistProductCode(Product product)
        {
            if (db.Products.Any(c => c.Code == product.Code && c.ID != product.ID))
            {
                return true;
            }

            return false;
        }
    }
}
