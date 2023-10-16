using Billing.RepositoryPattern.Api.Models;
using Billing.RepositoryPattern.Shared.DbEntities;

namespace Billing.RepositoryPattern.Api.Adapters
{
    public interface IUserAdapter
    {
        UserEntity Adapt(User user);
        AddressEntity AdaptToUserAddress(User user);
        User Adapt(UserEntity userEntity, AddressEntity addressEntity);
    }
}
