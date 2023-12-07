using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public interface IMenuService
    {
        public Task<ICollection<MainMenuEntity>> GetAll();
        public Task<IEnumerable<SubMenuEntity>> GetAllSubMenusByMenuId(int mainMenuId, int roleId);
    }
}
