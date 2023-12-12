using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Billing.RepositoryPattern.Api.Services.SalesService;
using Billing.RepositoryPattern.Api.Dtos;
using System.Threading.Tasks;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.InfraStructure.Repositories;
using Billing.RepositoryPattern.Api.Services.CustomerBill;

namespace Billing.RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBillController : ControllerBase
    {
        private readonly ICustomerBillService _customerBill;
        public CustomerBillController(ICustomerBillService customerBill)
        {
			_customerBill = customerBill;
        }      

		[HttpGet("GetBillDetails")]
		public async Task<List<CustomerBillEntity>> USP_GetBillDetails(int BillID) =>
			await _customerBill.USP_GetBillDetails(BillID);


	}
}
