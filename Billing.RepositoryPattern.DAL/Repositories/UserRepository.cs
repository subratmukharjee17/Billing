using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.InfraStructure
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<UserEntity> Login(string username, string passWord)
        {
            try
            {
                var userInfo = (from user in _dbContext.Users
                                where user.UserName == username && user.Password == passWord
                                select user).FirstOrDefaultAsync();
                return await userInfo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
