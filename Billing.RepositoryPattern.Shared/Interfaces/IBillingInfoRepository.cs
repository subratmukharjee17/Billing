using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Domain.Interfaces
{
    public interface IBillingInfoRepository : IGenericRepository<BillingInfoEntity>
    {
		Task<int> GetMaxBillingIdAsync();
		Task<List<BillingInfoEntity>> GetFilteredBillingInfo(int BillId);
	}
}
