using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Linq;

namespace Billing.RepositoryPattern.InfraStructure
{
    public class CustomerRepository : GenericRepository<CustomersEntity>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
