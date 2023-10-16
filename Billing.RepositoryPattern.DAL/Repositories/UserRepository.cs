using Billing.RepositoryPattern.DAL.DbContexts;
using Billing.RepositoryPattern.Shared.DbEntities;
using Billing.RepositoryPattern.Shared.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.DAL.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public UserEntity Login(string userName, string password)
        {
            return _dbcontext.Users.Where(user => user.FirstName.Equals(userName) && user.Password.Equals(password)).FirstOrDefault();
        }

        public int GetLastUserId()
        {
            var results = _dbcontext.Users.OrderByDescending(x => x.Id).FirstOrDefault();
            return results is null ? 1 : results.Id + 1;
        }
    }
}
