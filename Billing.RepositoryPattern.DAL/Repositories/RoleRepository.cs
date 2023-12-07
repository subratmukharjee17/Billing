using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;

namespace Billing.RepositoryPattern.InfraStructure
{
    public class RoleRepository : GenericRepository<RolesEntity>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
