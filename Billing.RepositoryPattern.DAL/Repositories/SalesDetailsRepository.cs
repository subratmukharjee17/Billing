using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.InfraStructure.Repositories
{
    public class SalesDetailsRepository : GenericRepository<SalesDetailsEntity>, ISalesDetailsRepository
    {
        public SalesDetailsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task<List<SubMenuEntity>> GetAllSubMenusByMenuId(int mainMenuId, int roleId)
        //{
        //   var result = _dbContext.SubMenu.Where(x =>x.MainMenuId.Equals(mainMenuId) && x.RoleId.Equals(roleId)).ToList();
        //    return await Task.FromResult(result);
        //}

        public async Task<List<SalesDetailsEntity>> GetAll()
        {
           // var result = _dbContext.SubMenu.Where(x => x.MainMenuId.Equals(mainMenuId) && x.RoleId.Equals(roleId)).ToList();
           var result=_dbContext.SalesDetails.ToList();
            return await Task.FromResult(result);
        }

        //public async Task<List<SubMenuEntity>> GetFilteredSales(string fromdate, string todate,string period)
        //{
        //    var result = _dbContext.SalesDetails.Where(x => x.MainMenuId.Equals(mainMenuId) && x.RoleId.Equals(roleId)).ToList();
        //    return await Task.FromResult(result);
        //}
    }
}
