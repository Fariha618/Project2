using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessManagementSystem.BLL.BLL;
using BusinessManagementSystem.Models;
using BusinessManagementSystem.Models.Models;


namespace BusinessManagementSystem.Controllers
{
    public class BusinessController : Controller
    {        
        CategoryManager _categoryManager = new CategoryManager();
        private Category _category = new Category();

        ProductManager _productManager = new ProductManager();
        private Product _product = new Product();

        CustomerManager _customerManager = new CustomerManager();
        private Customer _customer = new Customer();

        SupplierManager _supplierManager = new SupplierManager();
        private Supplier _supplier = new Supplier();


        // GET: Business
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryManager.IsExistCategoryCode(category))
                {
                    ViewBag.codeExist = "Category Code Already Exists!";
                }
                else if (_categoryManager.IsExistCategory(category))
                {
                    ViewBag.nameExist = "Category Already Exists!";
                }
                else
                {

                    if (_categoryManager.AddCategory(category))
                    {
                        ViewBag.SuccessMsg = "Saved";
                    }
                    else
                    {
                        ViewBag.FailMsg = "Failed";
                    }

                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateCategory(int Id)
        {
            _category.ID = Id;
            var category = _categoryManager.GetCategoryByID(_category);

            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {

            if (ModelState.IsValid)
            {
                if (_categoryManager.IsExistCategoryCode(category))
                {
                    ViewBag.codeExist = "Category Code Already Exists!";
                }
                else if (_categoryManager.IsExistCategory(category))
                {
                    ViewBag.nameExist = "Category Already Exists!";
                }
                else
                {

                    if (_categoryManager.UpdateCategory(category))
                    {
                        ViewBag.SuccessMsg = "Updated";
                    }
                    else
                    {
                        ViewBag.FailMsg = "Failed";
                    }
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View(category);
        }

        
        public ActionResult DeleteCategory(int Id)
        {
            _category.ID = Id;
            var category = _categoryManager.GetCategoryByID(_category);

            if (ModelState.IsValid)
            {
                if (_categoryManager.DeleteCategory(category))
                {
                    TempData["message"] = "Deleted";
                }
                else
                {
                    TempData["message"] = "Failed";
                }
            }
            else
            {
                TempData["message"] = "Validation Error";
            }

            return RedirectToAction("ShowCategory");
        }

       

        public ActionResult ShowCategory(Category category)
        {
            var categories = _categoryManager.GetAllCategories();

            if (category.Code != null)
            {
                categories = categories.Where(c => c.Code.ToLower().Contains(category.Code.ToLower())).ToList();
            }
            if (category.Name != null)
            {
                categories = categories.Where(c => c.Name.ToLower().Contains(category.Name.ToLower())).ToList();
            }
            
            category.Categories = categories;
          

            return View(category);
        }

        // <---------PRODUCT MODULE ----------> //

        [HttpGet]
        public ActionResult AddProduct()
        {
            Product product = new Product();

            product.CategorySelectListItems = _categoryManager.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();

            return View(product);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                if (_productManager.IsExistProductCode(product))
                {
                    ViewBag.codeExist = "Product Code Already Exists!";
                }
                else if (_productManager.IsExistProduct(product))
                {
                    ViewBag.nameExist = "Product Already Exists!";
                }
                else
                {
                    if (_productManager.AddProduct(product))
                    {
                        ViewBag.SuccessMsg = "Saved";
                    }
                    else
                    {
                        ViewBag.FailMsg = "Failed";
                    }
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            product.CategorySelectListItems = _categoryManager.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();

            return View(product);
        }

        [HttpGet]
        public ActionResult UpdateProduct(int Id)
        {
            _product.ID = Id;
            var product = _productManager.GetProductByID(_product);

            product.CategorySelectListItems = _categoryManager.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();

            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                if (_productManager.IsExistProductCode(product))
                {
                    ViewBag.codeExist = "Product Code Already Exists!";
                }
                else if (_productManager.IsExistProduct(product))
                {
                    ViewBag.nameExist = "Product Already Exists!";
                }
                else
                {
                    if (_productManager.UpdateProduct(product))
                    {
                        ViewBag.SuccessMsg = "Updated";
                    }
                    else
                    {
                        ViewBag.FailMsg = "Failed";
                    }
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            product.CategorySelectListItems = _categoryManager.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();

            return View(product);
        }


        public ActionResult DeleteProduct(int Id)
        {
            _product.ID = Id;
            var product = _productManager.GetProductByID(_product);

            if (ModelState.IsValid)
            {
                if (_productManager.DeleteProduct(product))
                {
                    TempData["message"] = "Deleted";
                }
                else
                {
                    TempData["message"] = "Failed";
                }
            }
            else
            {
                TempData["message"] = "Validation Error";
            }

            return RedirectToAction("ShowProduct");
        }



        public ActionResult ShowProduct(Product product)
        {
            var products = _productManager.GetAllProducts();           

            if (product.Code != null)
            {
                products = products.Where(c => c.Code.ToLower().Contains(product.Code.ToLower())).ToList();
            }
            if (product.Name != null)
            {
                products = products.Where(c => c.Name.ToLower().Contains(product.Name.ToLower())).ToList();
            }
            if (product.CategorySelectListItems != null)
            {
                products = products.Where(c => c.CategorySelectListItems == product.CategorySelectListItems).ToList();
            }             
            if (product.Reorder_Level > 0)
            {
                products = products.Where(c => c.Reorder_Level == product.Reorder_Level).ToList();
            }


            product.Products = products;

            product.CategorySelectListItems = _categoryManager.GetAllCategories().Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();

            return View(product);
        }


        // <---------Customer MODULE ----------> //

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_customerManager.IsExistCustomerCode(customer))
                {
                    ViewBag.codeExist = "Customer Code Already Exists!";
                }
                else if (_customerManager.IsExistCustomer(customer))
                {
                    ViewBag.nameExist = "Customer Already Exists!";
                }
                else if (_customerManager.IsExistEmail(customer))
                {
                    ViewBag.emailExist = "Email Already Exists!";
                }
                else if (_customerManager.IsExistContact(customer))
                {
                    ViewBag.contactExist = "Contact Already Exists!";
                }
                else
                {

                    if (_customerManager.AddCustomer(customer))
                    {
                        ViewBag.SuccessMsg = "Saved";
                    }
                    else
                    {
                        ViewBag.FailMsg = "Failed";
                    }

                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateCustomer(int Id)
        {
            _customer.ID = Id;
            var customer = _customerManager.GetCustomerByID(_customer);

            return View(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {

            if (ModelState.IsValid)
            {
                if (_customerManager.IsExistCustomerCode(customer))
                {
                    ViewBag.codeExist = "Customer Code Already Exists!";
                }
                else if (_customerManager.IsExistCustomer(customer))
                {
                    ViewBag.nameExist = "Customer Already Exists!";
                }
                else if (_customerManager.IsExistEmail(customer))
                {
                    ViewBag.emailExist = "Email Already Exists!";
                }
                else if (_customerManager.IsExistContact(customer))
                {
                    ViewBag.contactExist = "Contact Already Exists!";
                }
                else
                {

                    if (_customerManager.UpdateCustomer(customer))
                    {
                        ViewBag.SuccessMsg = "Updated";
                    }
                    else
                    {
                        ViewBag.FailMsg = "Failed";
                    }
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View(customer);
        }


        public ActionResult DeleteCustomer(int Id)
        {
            _customer.ID = Id;
            var customer = _customerManager.GetCustomerByID(_customer);

            if (ModelState.IsValid)
            {
                if (_customerManager.DeleteCustomer(customer))
                {
                    TempData["message"] = "Deleted";
                }
                else
                {
                    TempData["message"] = "Failed";
                }
            }
            else
            {
                TempData["message"] = "Validation Error";
            }

            return RedirectToAction("ShowCustomer");
        }



        public ActionResult ShowCustomer(Customer customer)
        {
            var customers = _customerManager.GetAllCustomers();

            if (customer.Code != null)
            {
                customers = customers.Where(c => c.Code.ToLower().Contains(customer.Code.ToLower())).ToList();
            }
            if (customer.Name != null)
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower())).ToList();
            }
            if (customer.Address != null)
            {
                customers = customers.Where(c => c.Address.ToLower().Contains(customer.Address.ToLower())).ToList();
            }
            if (customer.Email != null)
            {
                customers = customers.Where(c => c.Email.ToLower().Contains(customer.Email.ToLower())).ToList();
            }
            if (customer.Contact != null)
            {
                customers = customers.Where(c => c.Contact.ToLower().Contains(customer.Contact.ToLower())).ToList();
            }

            customer.Customers = customers;


            return View(customer);
        }


        // <---------Supplier MODULE ----------> //

        [HttpGet]
        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (_supplierManager.IsExistSupplierCode(supplier))
                {
                    ViewBag.codeExist = "Supplier Code Already Exists!";
                }
                else if (_supplierManager.IsExistSupplier(supplier))
                {
                    ViewBag.nameExist = "Supplier Already Exists!";
                }
                else if (_supplierManager.IsExistEmail(supplier))
                {
                    ViewBag.emailExist = "Email Already Exists!";
                }
                else if (_supplierManager.IsExistContact(supplier))
                {
                    ViewBag.contactExist = "Contact Already Exists!";
                }
                else
                {

                    if (_supplierManager.AddSupplier(supplier))
                    {
                        ViewBag.SuccessMsg = "Saved";
                    }
                    else
                    {
                        ViewBag.FailMsg = "Failed";
                    }

                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View();
        }

        [HttpGet]
        public ActionResult UpdateSupplier(int Id)
        {
            _supplier.ID = Id;
            var supplier = _supplierManager.GetSupplierByID(_supplier);

            return View(supplier);
        }

        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {

            if (ModelState.IsValid)
            {
                if (_supplierManager.IsExistSupplierCode(supplier))
                {
                    ViewBag.codeExist = "Supplier Code Already Exists!";
                }
                else if (_supplierManager.IsExistSupplier(supplier))
                {
                    ViewBag.nameExist = "Supplier Already Exists!";
                }
                else if (_supplierManager.IsExistEmail(supplier))
                {
                    ViewBag.emailExist = "Email Already Exists!";
                }
                else if (_supplierManager.IsExistContact(supplier))
                {
                    ViewBag.contactExist = "Contact Already Exists!";
                }
                else
                {

                    if (_supplierManager.UpdateSupplier(supplier))
                    {
                        ViewBag.SuccessMsg = "Updated";
                    }
                    else
                    {
                        ViewBag.FailMsg = "Failed";
                    }
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View(supplier);
        }


        public ActionResult DeleteSupplier(int Id)
        {
            _supplier.ID = Id;
            var supplier = _supplierManager.GetSupplierByID(_supplier);

            if (ModelState.IsValid)
            {
                if (_supplierManager.DeleteSupplier(supplier))
                {
                    TempData["message"] = "Deleted";
                }
                else
                {
                    TempData["message"] = "Failed";
                }
            }
            else
            {
                TempData["message"] = "Validation Error";
            }

            return RedirectToAction("ShowSupplier");
        }



        public ActionResult ShowSupplier(Supplier supplier)
        {
            var suppliers = _supplierManager.GetAllSuppliers();

            if (supplier.Code != null)
            {
                suppliers = suppliers.Where(c => c.Code.ToLower().Contains(supplier.Code.ToLower())).ToList();
            }
            if (supplier.Name != null)
            {
                suppliers = suppliers.Where(c => c.Name.ToLower().Contains(supplier.Name.ToLower())).ToList();
            }
            if (supplier.Address != null)
            {
                suppliers = suppliers.Where(c => c.Address.ToLower().Contains(supplier.Address.ToLower())).ToList();
            }
            if (supplier.Email != null)
            {
                suppliers = suppliers.Where(c => c.Email.ToLower().Contains(supplier.Email.ToLower())).ToList();
            }
            if (supplier.Contact != null)
            {
                suppliers = suppliers.Where(c => c.Contact.ToLower().Contains(supplier.Contact.ToLower())).ToList();
            }

            supplier.Suppliers = suppliers;


            return View(supplier);
        }


    }
}