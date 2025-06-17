using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Interfaces;

namespace WebApiAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            return this._productService.GetAll();
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            return this._productService.GetById(id);
        }

    }
}
