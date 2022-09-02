using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
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
        //EKLEYEMEYİZ!!!
        //ICategoryDal _categoryDal;
        //fakat service ekleyebiliriz
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            //bir entitymanager kendisi hariç başka dal ı enjekte edemez!!!!!!!!!!!!!!
            _categoryService = categoryService;
        }


        //claim --> yetkilendirme...
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))] //typeof ile validator type verdik.
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            //business code(iş gereksinimlerimize uygunluk)
            //validation(min kaç karakter max kaç karakter gibi doğrulamalar.)
            //iki kod türü birbirine karıştırılıyor bunları karıştırmamamız lazım.


            //Aynı isimde ürün eklenemez
            //iş katmanında bir örnek ürün kaydı yapılırken kategoriye 10 üründen fazlası eklenemez.
            //mevcut kategori sayısı 15 i geçtiyse sisteme yeni ürün eklenemez.

            //polymorphism --> çok biçimlilik.
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product), CheckIfProductNameExists(product), CheckIfCategoryCount());
            //buradaki result kurala uymayanlar demek eğer kurala uymayan varsa onu fonk. geri döndürsün eğer yoksa ekleme işlemini gerçekleştirsin.
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheAspect]
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

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId), Messages.ProductListedById);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min), Messages.ProductListedByUnitPrice);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos(), Messages.ProductDetailsDtos);
        }


        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product).Success)
            {
                _productDal.Update(product);
                return new SuccessResult(Messages.ProductUpdated);
            }
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);

        }


        private IResult CheckIfProductCountOfCategoryCorrect(Product product)
        {
            //selcet count(*) from Products where categoryId=1 i çalıştırır.Gidip tüm verileri çekmez.
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }


        private IResult CheckIfProductNameExists(Product product)
        {
            //aynı ürün isminden olan varsa eklenemez.any ile böyle bir data var mı yok mu onu kontrol ettik.
            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadySave);
            }
            return new SuccessResult();
        }


        private IResult CheckIfCategoryCount()
        {
            //aynı ürün isminden olan varsa eklenemez.any ile böyle bir data var mı yok mu onu kontrol ettik.
            var result = _categoryService.GetAll().Data.Count();
            if (result > 15)
            {
                return new ErrorResult(Messages.CategoryCounteExceeded);
            }
            return new SuccessResult();
        }
    }
}
