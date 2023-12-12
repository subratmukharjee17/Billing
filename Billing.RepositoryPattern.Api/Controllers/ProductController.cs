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

        [HttpPost("AddProduct")]
        public async Task AddProduct([FromBody] ProductDto product) =>
           await _productService.AddProduct(product);

        [HttpGet("GetAllProducts")]
        public async Task<IEnumerable<ProductsEntity>> GetAllProducts() =>
            await _productService.GetAll();


        //[HttpPost("AddSale")]
        //public async Task AddSales([FromBody] ProductDto Product) =>
        //    await _productService.AddProduct(Product);

		[HttpGet("GetProductNameWithId")]
		public async Task<List<ProductsEntity>> GetProductNameWithId(int ProductId) =>
		  await _productService.GetProductNameWithId(ProductId);
	}
}
