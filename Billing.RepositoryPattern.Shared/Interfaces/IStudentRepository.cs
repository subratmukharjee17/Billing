using Billing.RepositoryPattern.Shared.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Shared.Interfaces
{
    public interface IStudentRepository : IGenericRepository<StudentEntity>
    {
        StudentEntity GetByStudentCode(string studentCode);
    }
}
