using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.InfraStructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.BillingService
{
    public interface IBillingService
    {
      public Task<IEnumerable<BillingInfoEntity>> GetAll();
       public Task AddBillingInfo(BillingInfoDto billinfo);

		public  Task<int> GetMaxBillingId();

        public  Task<List<BillingInfoEntity>> GetFilteredBillingInfo(int BillId);

	}
}
