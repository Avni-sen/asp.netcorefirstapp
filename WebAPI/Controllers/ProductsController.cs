using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //ATTIRIBUTE :

    public class ProductsController : ControllerBase
    {
        //loosely coupled (gevşek bağımlılık)
        //naming convertion(isimlendirme standartı)
        //IoC Container --> Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //IProductService productService = new ProductManager(new EfProductDal());
            //ProductManager productManager = new ProductManager(new EfProductDal()); ile de aynı şekilde çalışır.
            var result = _productService.GetAll();
            return result.Data;
        }







    }
}
