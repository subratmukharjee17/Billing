using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.InfraStructure
{
    public class ProductRepository : GenericRepository<ProductsEntity>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

			
		}

		public async Task<List<ProductsEntity>> GetProductNameWithId(int ProductId)
		{
			var result = _dbContext.Product.Where(x => x.ProductId.Equals(ProductId)).ToList();
			return await Task.FromResult(result);
		}

	}
}
