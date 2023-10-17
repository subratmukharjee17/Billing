using Billing.RepositoryPattern.Model.Models;
using Billing.RepositoryPattern.Shared.DbEntities;

namespace Billing.RepositoryPattern.Api.Mappers.UserMapper
{
    public interface IUserMapper
    {
        UserEntity Mapp(User user);
        AddressEntity MappToUserAddress(User user);
        User Mapp(UserEntity userEntity, AddressEntity addressEntity);
    }
}
