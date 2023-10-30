using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Billing.RepositoryPattern.Api.Services.UserService;
using Billing.RepositoryPattern.Api.Dtos;
using System.Threading.Tasks;
using Billing.RepositoryPattern.Domain.DbEntities;

namespace Billing.RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetAllMenus")]
        public async Task<IEnumerable<MainMenuEntity>> GetAll()
          => await _menuService.GetAll();


        [HttpGet("GetAllSubMenusByIds")]
        public async Task<IEnumerable<SubMenuEntity>> GetSubMenusByMenuId(int mainMenuId, int roleId)
          => await _menuService.GetAllSubMenusByMenuId(mainMenuId, roleId);
    }
}
