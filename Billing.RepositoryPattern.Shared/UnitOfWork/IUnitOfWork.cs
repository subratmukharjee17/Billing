using Billing.RepositoryPattern.Domain.Interfaces;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IAddressRepository AddressRepository { get; }
        IMainMenuRepository MainRepository { get; }
        ISubMenuRepository SubMenuRepository { get; }

        ISalesDetailsRepository SalesDetailsRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
