using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Billing.RepositoryPattern.Api.Services.SalesService;
using Billing.RepositoryPattern.Api.Dtos;
using System.Threading.Tasks;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Api.Services.ProductService;

namespace Billing.RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProductsEntity>> GetAll() =>
            await _productService.GetAll();


        [HttpPost("AddProduct")]
        public async Task AddSales([FromBody] ProductDto Product) =>
            await _productService.AddProduct(Product);


    }
}
