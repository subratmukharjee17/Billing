using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<ProductsEntity>
    {
        //Task<List<SubMenuEntity>> GetAllSubMenusByMenuId(int MenuId, int RoleId);
    }
}
