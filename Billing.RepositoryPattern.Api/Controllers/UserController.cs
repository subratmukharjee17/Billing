using Microsoft.AspNetCore.Mvc;
using Billing.RepositoryPattern.Api.Models;
using System.Collections.Generic;
using Billing.RepositoryPattern.Api.Services;

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

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet("{Login}")]
        public User Login(string loginName, string password)
        {

            return _userService.Login(loginName, password);
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] User user)
        {
            int userId = _userService.GetLastUserId();
            user.UserId = 100 + userId;
            _userService.Add(user);
        }
    }
}
