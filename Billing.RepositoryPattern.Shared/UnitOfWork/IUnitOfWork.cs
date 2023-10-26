using Billing.RepositoryPattern.Domain.Interfaces;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAddressRepository AddressRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
