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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<UserEntity>> GetAll() =>
            await _userService.GetAll();


        [HttpPost("AddUser")]
        public async Task AddUser([FromBody] UserDto user) =>
            await _userService.AddUser(user);

        [HttpGet("Login")]
        public async Task<UserEntity> Login(string userName, string password) =>
            await _userService.Login(userName, password);
    }
}
