using Billing.RepositoryPattern.Api.Mappers.UserMapper;
using Billing.RepositoryPattern.Model.Models;
using Billing.RepositoryPattern.Shared.DbEntities;
using System.Collections.Generic;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserMapper _userMapper;
        private readonly IUnitOfWorkService _unitOfWorkService;
        public UserService(IUnitOfWorkService unitOfWorkService, IUserMapper userMapper)
        {
            _unitOfWorkService = unitOfWorkService;
            _userMapper = userMapper;
        }

        public void Add(User user)
        {
            if (Validate(user))
            {
                _unitOfWorkService.User.Add(_userMapper.Mapp(user));
                _unitOfWorkService.Address.Add(_userMapper.MappToUserAddress(user));

                _unitOfWorkService.Save();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> listUser = new List<User>();
            foreach (UserEntity userEntity in _unitOfWorkService.User.GetAll())
            {
                listUser.Add(_userMapper.Mapp(userEntity,
                    _unitOfWorkService.Address.GetById(userEntity.Id)));
            }
            return listUser;
        }

        public User Login(string loginName, string password)
        {
            UserEntity studentEntity = _unitOfWorkService.User.Login(loginName, password);
            return _userMapper.Mapp(studentEntity, new AddressEntity());
        }

        public int GetLastUserId() =>
            _unitOfWorkService.User.GetLastUserId();

        public void Remove(User user)
        {
            _unitOfWorkService.User.Remove(_userMapper.Mapp(user));
            _unitOfWorkService.Save();
        }

        public bool Validate(User user)
        {
            //Validate Students Data
            return true;
        }
    }
}
