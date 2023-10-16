using Billing.RepositoryPattern.Api.Models;
using System.Collections.Generic;

namespace Billing.RepositoryPattern.Api.Services
{
    public interface IUserService
    {
        void Add(User user);
        User Login(string LoginName, string password);
        IEnumerable<User> GetAll();
        int GetLastUserId();
    }
}
