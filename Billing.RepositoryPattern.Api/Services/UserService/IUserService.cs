using Billing.RepositoryPattern.Model.Models;
using System.Collections.Generic;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public interface IUserService
    {
        void Add(User user);
        User Login(string LoginName, string password);
        IEnumerable<User> GetAll();
        int GetLastUserId();
    }
}
