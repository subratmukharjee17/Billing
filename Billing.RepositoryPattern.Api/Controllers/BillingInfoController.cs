using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Billing.RepositoryPattern.Api.Services.SalesService;
using Billing.RepositoryPattern.Api.Dtos;
using System.Threading.Tasks;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.InfraStructure.Repositories;
using Billing.RepositoryPattern.Api.Services.BillingService;

namespace Billing.RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingInfoController : ControllerBase
    {
        private readonly IBillingService _billingService;
        public BillingInfoController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<BillingInfoEntity>> GetAll() =>
            await _billingService.GetAll();


        [HttpPost("AddBillingInfo")]
        public async Task AddBillingInfo([FromBody] BillingInfoDto billingInfo) =>
            await _billingService.AddBillingInfo(billingInfo);

  
    }
}
