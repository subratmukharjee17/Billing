using Billing.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services
{
    public interface IUnitOfWorkService
    {
        int Save();
        IStudentRepository Student { get; set; }
        IStudentAddressRepository StudentAddress { get; set; }
        IStudentSportRepository StudentSport { get; set; }

        IUserRepository User { get; set; }
        IAddressRepository Address { get; set; }
    }
}
