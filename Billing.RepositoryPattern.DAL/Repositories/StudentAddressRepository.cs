using Billing.RepositoryPattern.DAL.DbContexts;
using Billing.RepositoryPattern.Shared.DbEntities;
using Billing.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.DAL.Repositories
{
    public class StudentAddressRepository : GenericRepository<StudentAddressEntity>, IStudentAddressRepository
    {
        public StudentAddressRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public StudentAddressEntity GetByStudentCode(string studentCode)
        {
            return _dbcontext.StudentAddress.Where(address => address.StudentCode.Equals(studentCode)).FirstOrDefault(); ;
        }
    }
}
