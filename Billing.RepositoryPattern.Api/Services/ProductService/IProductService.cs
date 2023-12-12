using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.ProductService
{
    public interface IProductService
    {
       public Task<IEnumerable<ProductsEntity>> GetAll();
        public Task AddProduct(ProductDto product);

        public Task<List<ProductsEntity>> GetProductNameWithId(int ProductId);


	}
}
