using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.Repository.Repository;

namespace BusinessManagementSystem.BLL.BLL
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();

        public bool AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }

        public bool DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductByID(Product product)
        {
            return _productRepository.GetProductByID(product);
        }

        public bool IsExistProduct(Product product)
        {
            return _productRepository.IsExistProduct(product);
        }

        public bool IsExistProductCode(Product product)
        {
            return _productRepository.IsExistProductCode(product);
        }
    }
}
