using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    internal class InMemoryCategoryDal : ICategoryDal
    {
        List<Category> _categories;

        public InMemoryCategoryDal(List<Category> categories)
        {
            _categories = new List<Category> {
                new Category{CategoryName="Giyim",CategoryId=1},
                new Category{CategoryName="Teknoloji",CategoryId=2},
                    };
        }

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Delete(Category category)
        {
            Category categoryToDelete = null;
            categoryToDelete = _categories.FirstOrDefault(p => p.CategoryId == category.CategoryId);
            _categories.Remove(categoryToDelete);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategory(int categoryId)
        {
            return _categories.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void Update(Category category)
        {
            Category categoryToUpdate = null;
            categoryToUpdate = _categories.FirstOrDefault(p => p.CategoryId == category.CategoryId);
            categoryToUpdate.CategoryName = category.CategoryName;

        }
    }
}
