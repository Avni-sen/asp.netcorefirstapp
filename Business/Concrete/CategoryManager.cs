using Business.Abstract;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [CacheAspect]
        public IDataResult<List<Category>> GetAll()
        {

            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p => p.CategoryId == id), Messages.CategoryListedById);

        }
    }
}
