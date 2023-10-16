using Billing.RepositoryPattern.DAL.DbContexts;
using Billing.RepositoryPattern.Shared.DbEntities;
using Billing.RepositoryPattern.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.DAL.Repositories
{
    public class RoleRepository : GenericRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public List<RoleEntity> GetAll()
        {
            return _dbcontext.Roles.ToList(); ;
        }
    }
}
