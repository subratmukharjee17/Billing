using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billing.RepositoryPattern.InfraStructure.UnitOfWork;
using System.Linq;

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
            int count = _unitOfWork.AddressRepository.GetAll().Count();

            var address = new AddressEntity
            {
                AddressLine1 = userDto.AddressLine1,
                AddressLine2 = userDto.AddressLine2,
                LandMark = userDto.LandMark,
                City = userDto.City,
                State = userDto.State,
                Country = userDto.Country,
                ZipCode = userDto.ZipCode,
            };

            var user = new UserEntity
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserName = userDto.UserName,
                EmailId = userDto.EmailId,
                PhoneNumber = userDto.PhoneNumber,
                Password = userDto.Password,
                ConfirmPassword = userDto.ConfirmPassword,
                Dob = userDto.Dob,
                Gender = userDto.Gender,
                AddressId = count + 1,
                RoleId = 1,
                AuditId =1,
            };

            //_unitOfWork.AddressRepository.Add(address);
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
            => await _unitOfWork.UserRepository.GetAllAsync();

        public async Task<UserEntity> Login(string userName, string password) =>
           await _unitOfWork.UserRepository.Login(userName, password);
    }
}
