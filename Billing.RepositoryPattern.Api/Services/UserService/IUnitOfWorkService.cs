using Billing.RepositoryPattern.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public interface IUnitOfWorkService
    {
        int Save();
        IUserRepository User { get; set; }
        IAddressRepository Address { get; set; }
    }
}
