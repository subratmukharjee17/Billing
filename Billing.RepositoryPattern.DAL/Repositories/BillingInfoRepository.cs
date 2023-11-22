using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.InfraStructure.Repositories
{
    public class BillingInfoRepository : GenericRepository<BillingInfoEntity>, IBillingInfoRepository
    {
        public BillingInfoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }


        //public async Task<List<BillingInfoEntity>> GetAll()
        //{
        //   //// var result = _dbContext.SubMenu.Where(x => x.MainMenuId.Equals(mainMenuId) && x.RoleId.Equals(roleId)).ToList();
        //   //var result=_dbContext.BillingInfo.ToList();
        //   // return await Task.FromResult(result);
        //}

      
    }
}
