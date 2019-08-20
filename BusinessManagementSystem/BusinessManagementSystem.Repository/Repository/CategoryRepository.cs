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
    public class CategoryRepository
    {

        BusinessDbContext db = new BusinessDbContext();

        public bool AddCategory(Category category)
        {
            db.Categories.Add(category);

            int isExecuted = 0;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;

        }

        public bool UpdateCategory(Category category)
        {
            int isExecuted = 0;

            db.Entry(category).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCategory(Category category)
        {
            int isExecuted = 0;
            Category aCategory = db.Categories.FirstOrDefault(c => c.ID == category.ID);

            db.Categories.Remove(aCategory);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }


            return false;
        }

        public List<Category> GetAllCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryByID(Category category)
        {
            Category acategory = db.Categories.FirstOrDefault(c => c.ID == category.ID);
            return acategory;
        }

        public bool IsExistCategory(Category category)
        {
            if (db.Categories.Any(c => c.Name == category.Name && c.ID != category.ID))
            {
                return true;
            }

            return false;
        }

        public bool IsExistCategoryCode(Category category)
        {
            if (db.Categories.Any(c => c.Code == category.Code && c.ID != category.ID))
            {
                return true;
            }

            return false;
        }


    }
}
