using Billing.RepositoryPattern.Domain.DbEntities;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
       Task<UserEntity> Login(string username, string password);
    }
}
