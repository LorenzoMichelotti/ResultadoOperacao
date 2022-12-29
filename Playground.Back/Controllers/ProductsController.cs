using Microsoft.AspNetCore.Mvc;
using Playground.Domain;

namespace Playground.Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet(Name = "GetProductsByIds")]
        public List<Product> GetProductsByIds([FromQuery] ProductFilter filter)
        {
            List<Product> inventory = new List<Product>()
            {
                new() { Id = 1, Name = "PC da Xuxa" },
                new() { Id = 2, Name = "Leonardo" },
                new() { Id = 3, Name = "Adriano" },
            };

            List<Product> result = inventory.FindAll(w => filter.Ids.Contains(w.Id));

            return result;
        }

        public class ProductFilter
        {
            public List<int> Ids { get; set; }
            public ProductFilter()
            {
                Ids = new();
            }
        }

        [HttpGet(Name = "SimpleGetProductsByIds")]
        public List<Product> SimpleGetProductsByIds([FromQuery] SimpleProductFilter filter)
        {
            List<Product> inventory = new List<Product>()
            {
                new() { Id = 1, Name = "PC da Xuxa" },
                new() { Id = 2, Name = "Leonardo" },
                new() { Id = 3, Name = "Adriano" },
            };

            List<Product> result = inventory.FindAll(w => filter.Ids.Split(',').Contains(w.Id.ToString()));

            return result;
        }
    }

    public class SimpleProductFilter
    {
        public string? Ids { get; set; }
    }
}