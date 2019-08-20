using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.Repository.Repository;


namespace BusinessManagementSystem.BLL.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public bool AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }

        public bool UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }

        public bool DeleteCategory(Category category)
        {
            return _categoryRepository.DeleteCategory(category);
        }


        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryByID(Category category)
        {
            return _categoryRepository.GetCategoryByID(category);
        }

        public bool IsExistCategory(Category category)
        {
            return _categoryRepository.IsExistCategory(category);
        }

        public bool IsExistCategoryCode(Category category)
        {
            return _categoryRepository.IsExistCategoryCode(category);
        }
    }
}
