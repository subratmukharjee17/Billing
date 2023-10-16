using Billing.RepositoryPattern.Api.Adapters;
using Billing.RepositoryPattern.Api.Models;
using Billing.RepositoryPattern.Shared.DbEntities;
using System.Collections.Generic;

namespace Billing.RepositoryPattern.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserAdapter _userAdapter;
        private readonly IUnitOfWorkService _unitOfWorkService;
        public UserService(IUnitOfWorkService unitOfWorkService, IUserAdapter userAdapter)
        {
            _unitOfWorkService = unitOfWorkService;
            _userAdapter = userAdapter;
        }

        public void Add(User user)
        {
            if (Validate(user))
            {
                _unitOfWorkService.User.Add(_userAdapter.Adapt(user));
                _unitOfWorkService.Address.Add(_userAdapter.AdaptToUserAddress(user));

                _unitOfWorkService.Save();
            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> listUser = new List<User>();
            foreach (UserEntity userEntity in _unitOfWorkService.User.GetAll())
            {
                listUser.Add(_userAdapter.Adapt(userEntity,
                    _unitOfWorkService.Address.GetById(userEntity.Id)));
            }
            return listUser;
        }

        public User Login(string loginName, string password)
        {
            UserEntity studentEntity = _unitOfWorkService.User.Login(loginName, password);
            return _userAdapter.Adapt(studentEntity, new AddressEntity());
        }

        public int GetLastUserId() =>
            _unitOfWorkService.User.GetLastUserId();

        public void Remove(User user)
        {
            _unitOfWorkService.User.Remove(_userAdapter.Adapt(user));
            _unitOfWorkService.Save();
        }

        public bool Validate(User user)
        {
            //Validate Students Data
            return true;
        }
    }
}
