using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.InfraStructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.SalesService
{
    public interface ISalesService
    {
       public Task<IEnumerable<SalesDetailsEntity>> GetAll();
        public Task AddSales(SalesDto sales);

        public Task<string> AddCustomerAndBillingInfo(SalesDto sales);

		public Task<List<SalesDetailsEntity>> GetFilteredSales(int BillId);

        public Task<List<SalesDetailsEntity>> GetSalesDataByParameters(string fromdate, string todate, string period);

	}
}
