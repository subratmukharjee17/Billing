using Billing.RepositoryPattern.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services
{
    public interface IStudentService
    {
        void Add(Student student);
        Student GetByStudentCode(string studentCode);
        IEnumerable<Student> GetAll();
    }
}
