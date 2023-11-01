using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.SalesService
{
    public interface ISalesService
    {
       public Task<IEnumerable<SalesDetailsEntity>> GetAll();
        public Task AddSales(SalesDto sales);
     //   public Task<UserEntity> Login(string userName, string password);
    }
}
