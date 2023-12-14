using Billing.RepositoryPattern.Domain.Interfaces;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IMainMenuRepository MainRepository { get; }
        ISubMenuRepository SubMenuRepository { get; }
        ISalesDetailsRepository SalesDetailsRepository { get; }
        IProductRepository ProductRepository { get; }
        IBillingInfoRepository BillingInfoRepository { get; }
        ICustomerRepository CustomerRepository { get; }

        ICustomerBillRepository CustomerBillRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
