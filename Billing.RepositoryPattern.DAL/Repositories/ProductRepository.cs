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
        //public async Task<List<ProductEntity>> GetAll()
        //{
        //    // var result = _dbContext.SubMenu.Where(x => x.MainMenuId.Equals(mainMenuId) && x.RoleId.Equals(roleId)).ToList();
        //  //  var result = _dbContext.Product.ToList();
        //  //  return await Task.FromResult(result);
        //}

    }
}
