using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Billing.RepositoryPattern.InfraStructure.Repositories
{
    public class MainMenuRepository : GenericRepository<MainMenuEntity>, IMainMenuRepository
    {
        public MainMenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
