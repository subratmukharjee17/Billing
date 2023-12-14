using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.InfraStructure.Repositories
{
    public class SubMenuRepository : GenericRepository<SubMenuEntity>, ISubMenuRepository
    {
        public SubMenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<SubMenuEntity>> GetAllSubMenusByMenuId(int mainMenuId, int roleId)
        {
           var result = _dbContext.SubMenu.Where(x =>x.MainMenuId.Equals(mainMenuId) && x.RoleId.Equals(roleId)).ToList();
            return await Task.FromResult(result);
        }
    }
}
