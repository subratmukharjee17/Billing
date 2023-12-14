using Billing.RepositoryPattern.Domain.DbEntities;

namespace Billing.RepositoryPattern.Domain.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<CustomersEntity>
    {
    }
}
