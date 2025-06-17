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

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);            

        }

    }
}
