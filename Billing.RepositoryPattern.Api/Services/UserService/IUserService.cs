using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public interface IUserService
    {
        public Task<IEnumerable<UserEntity>> GetAll();
        public Task AddUser(UserDto user);
        public Task<UserEntity> Login(string userName, string password);
    }
}
