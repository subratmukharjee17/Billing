using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Domain.Interfaces
{
    public interface ICustomerBillRepository : IGenericRepository<CustomerBillEntity>
    {
		//Task<List<SubMenuEntity>> GetAllSubMenusByMenuId(int MenuId, int RoleId);
		 Task<List<CustomerBillEntity>> USP_GetBillDetails(int BIllingId);
	}
}
