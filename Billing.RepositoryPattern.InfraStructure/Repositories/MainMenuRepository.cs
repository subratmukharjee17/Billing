using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Billing.RepositoryPattern.InfraStructure.Repositories
{
    public class MainMenuRepository : GenericRepository<MainMenuEntity>, IMainMenuRepository
    {
        public ICollection<MainMenuEntity> Products { get; set; } = new List<MainMenuEntity>();
        public MainMenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<ICollection<MainMenuEntity>> GetAll()
        {
            try
             {

                Products =  (from c in _dbContext.MainMenu
                               .Include(c => c.SubMenuList)
                               select c).ToList();
                return Products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
