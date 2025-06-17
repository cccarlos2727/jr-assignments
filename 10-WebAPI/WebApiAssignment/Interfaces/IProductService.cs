using Microsoft.AspNetCore.Mvc;

namespace WebApiAssignment.Interfaces
{
    public interface IProductService
    {
        public JsonResult GetAll();

        public JsonResult GetById(int id);
    }
}
