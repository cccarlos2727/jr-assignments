using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Models;

namespace WebApiAssignment.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetAll();

        public Product GetById(int id);
    }
}
