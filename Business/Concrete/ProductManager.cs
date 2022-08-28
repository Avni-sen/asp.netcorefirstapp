using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business code
            if (product.ProductName.Length < 2)
            {
                //magic string bunları burada yazmak sıkıntı olabilir buna çözüm için business katmanında constants(sabitler) klasörü oluşturduk.
                //artık hatalarımızı ya da vermemiz gereken mesajları Messages üzerinden kontrol edebiliriz.
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product); 
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 16)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

            //iş kodları varsa onlar yazılır.
            //bir iş sınıfı başka sınıfları newlemez!!
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProductListedByCategoryId);
        }

        public IDataResult<Product> GetById(int productId) 
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId) , Messages.ProductListedById);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min), Messages.ProductListedByUnitPrice);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos(), Messages.ProductDetailsDtos);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessDataResult<Product>(Messages.ProductUpdated);
        }
    }
}
