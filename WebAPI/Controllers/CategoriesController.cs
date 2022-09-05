using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            //IProductService productService = new ProductManager(new EfProductDal());
            //ProductManager productManager = new ProductManager(new EfProductDal()); ile de aynı şekilde çalışır.
            //Swagger
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        //yukarıda operasyonları isimlendirdik.
        public IActionResult GetById(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
