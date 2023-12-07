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
    }
}
