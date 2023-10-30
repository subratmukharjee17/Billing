using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Billing.RepositoryPattern.Domain.Interfaces;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public class MenuService : IMenuService
    {
        public IUnitOfWork _unitOfWork;
        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MainMenuEntity>> GetAll()
            => await _unitOfWork.MainRepository.GetAllAsync();

        public async Task<IEnumerable<SubMenuEntity>> GetAllSubMenusByMenuId(int MainMenuId, int RoleId)
            => await _unitOfWork.SubMenuRepository.GetAllSubMenusByMenuId(MainMenuId, RoleId);
    }
}
