using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Linq;

namespace Billing.RepositoryPattern.InfraStructure
{
    public class AddressRepository : GenericRepository<AddressEntity>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
