using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public interface IUserService
    {
        public Task<IEnumerable<UserEntity>> GetAllUsers();
        public Task AddUser(UserDto user);

        public Task AddRole(RoleDto role);

        public Task<IEnumerable<RolesEntity>> GetAllRoles();

        public Task<UserEntity> Login(string userName, string password);
    }
}
