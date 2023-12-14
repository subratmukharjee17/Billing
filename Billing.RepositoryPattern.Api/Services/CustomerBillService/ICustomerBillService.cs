using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.InfraStructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.CustomerBill
{
    public interface ICustomerBillService
    {

        public Task<List<CustomerBillEntity>> USP_GetBillDetails(int BIllingId);
   
    }
}
