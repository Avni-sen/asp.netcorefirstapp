﻿using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : ICategoryDal
    {
        public void Add(Category entity)
        {
            using (NorthwindContext context = new())
            {
                var addedCategory = context.Entry(entity);
                addedCategory.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (NorthwindContext context = new())
            {
                var deletedCategory = context.Entry(entity);
                deletedCategory.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (NorthwindContext context = new())
            {
                return context.Set<Category>().SingleOrDefault(filter);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (NorthwindContext context = new())
            {
                return filter != null ? context.Set<Category>().Where(filter).ToList() : context.Set<Category>().ToList();
            }
        }

        public void Update(Category entity)
        {
            using (NorthwindContext context = new())
            {
                var deletedCategory = context.Entry(entity);
                deletedCategory.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}