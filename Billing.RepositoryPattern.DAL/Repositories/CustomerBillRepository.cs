using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Billing.RepositoryPattern.InfraStructure.Repositories
{
    public class CustomerBillRepository : GenericRepository<CustomerBillEntity>, ICustomerBillRepository
	{
		public CustomerBillRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }       

		public async Task<List<CustomerBillEntity>> USP_GetBillDetails(int billingid)
		{
			var parameter = new SqlParameter("@billingid", billingid);

			List<CustomerBillEntity> billdata = await _dbContext.CustomerBill
				.FromSqlRaw("EXEC USP_GetBillDetails @billingid", parameter)
				.ToListAsync();

			return billdata;
		}


	}
}
