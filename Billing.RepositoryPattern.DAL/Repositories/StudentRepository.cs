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
    public class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public StudentEntity GetByStudentCode(string studentCode)
        {
            return _dbcontext.Students.Where(student => student.StudentCode.Equals(studentCode)).FirstOrDefault();
        }
    }
}
