using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUser(UserDto userDto)
        {
            var user = new UserEntity
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                EmailId = userDto.EmailId,
                PhoneNumber = userDto.PhoneNumber,
                Password = userDto.Password,
                ConfirmPassword = userDto.ConfirmPassword,
                RoleId = string.IsNullOrEmpty(userDto?.UserRoleId.ToString()) ? 1 : userDto.UserRoleId,
                AuditId = 1,
            };

            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddRole(RoleDto roleDto)
        {
            var role = new RolesEntity
            {
                RoleName = roleDto.RoleName,
                Desription = roleDto.Desription,
                IsActive = roleDto.IsActive,
            };

            _unitOfWork.RoleRepository.Add(role);
            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<UserEntity>> GetAllUsers()
            => await _unitOfWork.UserRepository.GetAllAsync();

        public async Task<IEnumerable<RolesEntity>> GetAllRoles()
           => await _unitOfWork.RoleRepository.GetAllAsync();

        public async Task<UserEntity> Login(string userName, string password) =>
           await _unitOfWork.UserRepository.Login(userName, password);
    }
}
