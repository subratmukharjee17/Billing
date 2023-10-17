using Billing.RepositoryPattern.Shared.DbEntities;
using Billing.RepositoryPattern.Model.Models;

namespace Billing.RepositoryPattern.Api.Mappers.UserMapper
{
    public class UserMapper : IUserMapper
    {
        public UserEntity Mapp(User user)
        {
            return new UserEntity()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LoginName = user.LoginName,
                EmailId = user.EmailId,
                Password = user.Password,
                Dob = user.Dob,
                Gender = user.Gender,
                RoleId = user.RoleId,
            };
        }

        public AddressEntity MappToUserAddress(User user)
        {
            return new AddressEntity()
            {
                UserId = user.UserId,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                LandMark = user.LandMark,
                City = user.City,
                State = user.State,
                Country = user.Country,
                ZipCode = user.ZipCode,
                IsActive = true
            };
        }

        public User Mapp(UserEntity userEntity, AddressEntity addressEntity)
        {
            return new User()
            {
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                LoginName = userEntity.LoginName,
                EmailId = userEntity.EmailId,
                Password = userEntity.Password,
                Dob = userEntity.Dob,
                Gender = userEntity.Gender,
                RoleId = userEntity.RoleId,
                UserId = userEntity.UserId,
                AddressLine1 = addressEntity.AddressLine1,
                AddressLine2 = addressEntity.AddressLine2,
                City = addressEntity.City
            };
        }
    }
}
