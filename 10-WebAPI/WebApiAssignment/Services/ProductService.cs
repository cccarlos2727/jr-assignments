using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Interfaces;
using WebApiAssignment.Models;

namespace WebApiAssignment.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Keyboard", Price = 45.99M },
            new Product { Id = 2, Name = "Mouse", Price = 19.99M },
            new Product { Id = 3, Name = "Monitor", Price = 150.00M }
        };

        public JsonResult GetAll()
        {
            return new JsonResult(_products);
        }

        public JsonResult GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return new JsonResult(new { Message = "Product not found" }) { StatusCode = 404 };
            }
            return new JsonResult(product);

        }

    }
}
