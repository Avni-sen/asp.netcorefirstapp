using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (NorthwindContext context = new())
            {
                var result = from x in context.Products
                             join c in context.Categories
                             on x.CategoryId equals c.CategoryId
                             select new ProductDetailDto { ProductId = x.ProductId, ProductName = x.ProductName, CategoryName = c.CategoryName, UnitsInStock = x.UnitsInStock };

                return result.ToList();
            }
        }
    }
}
