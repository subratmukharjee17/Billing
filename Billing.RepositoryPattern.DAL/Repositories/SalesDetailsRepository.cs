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

        public async Task<List<SalesDetailsEntity>> GetAll(string fromdate, string todate, string period)
        {
            List<SalesDetailsEntity> result=null;

            if (!string.IsNullOrEmpty(fromdate) && !string.IsNullOrEmpty(todate) && !string.IsNullOrEmpty(period))
            {
                if (period == "Weekly")
                {
                    // Filter by a weekly range based on 'fromdate' and 'todate'
                    // Example: result = _dbContext.SalesDetails.Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate).ToList();
                }
                else if (period == "Monthly")
                {
                    // Filter by a monthly range based on 'fromdate' and 'todate'
                    // Example: result = _dbContext.SalesDetails.Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate).ToList();
                }
                else if (period == "Daily")
                {
                    // Filter by a daily range based on 'fromdate' and 'todate'
                    // Example: result = _dbContext.SalesDetails.Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate).ToList();
                }
                else
                {
                    // Handle invalid period input if necessary
                    // For instance, return an error or throw an exception
                }
            }
            else
            {
                // Fetch all data if parameters are null or empty
                result = _dbContext.SalesDetails.ToList();
            }

            return await Task.FromResult(result);
        }


        //public async Task<List<SubMenuEntity>> GetFilteredSales(string fromdate, string todate,string period)
        //{
        //    var result = _dbContext.SalesDetails.Where(x => x.MainMenuId.Equals(mainMenuId) && x.RoleId.Equals(roleId)).ToList();
        //    return await Task.FromResult(result);
        //}
    }
}
