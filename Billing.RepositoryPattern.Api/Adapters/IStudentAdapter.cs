using Billing.RepositoryPattern.Api.Models;
using Billing.RepositoryPattern.Shared.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Adapters
{
    public interface IStudentAdapter
    {
        StudentEntity Adapt(Student student);
        StudentAddressEntity AdaptToStudentAddress(Student student);
        StudentSportEntity AdaptToStudentSport(Student student);
        Student Adapt(StudentEntity studentEntity, StudentAddressEntity studentAddressEntity, StudentSportEntity studentSportEntity);
    }
}
