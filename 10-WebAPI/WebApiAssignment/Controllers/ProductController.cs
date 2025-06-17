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
            var product = this._productService.GetAll();
            return new JsonResult(product);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var product = this._productService.GetById(id);
            if(product == null)
            {
                return NotFound(new { Message = "Product not found" });
            }
            return Ok(product);
        }

    }
}
