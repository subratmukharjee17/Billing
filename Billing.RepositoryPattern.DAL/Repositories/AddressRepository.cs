using Billing.RepositoryPattern.DAL.DbContexts;
using Billing.RepositoryPattern.Shared.DbEntities;
using Billing.RepositoryPattern.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.DAL.Repositories
{
    public class AddressRepository : GenericRepository<AddressEntity>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public AddressEntity GetAddressById(int Id)
        {
            return _dbcontext.Address.Where(address => address.Id.Equals(Id)).FirstOrDefault(); ;
        }
    }
}
