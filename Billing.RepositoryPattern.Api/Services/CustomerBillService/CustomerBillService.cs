using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billing.RepositoryPattern.InfraStructure.UnitOfWork;
using System.Linq;
using System;
using Billing.RepositoryPattern.InfraStructure.Repositories;
using Newtonsoft.Json;

namespace Billing.RepositoryPattern.Api.Services.CustomerBill
{
    public class CustomerBillService :ICustomerBillService
    {
        public IUnitOfWork _unitOfWork; 
        public CustomerBillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }		

        public async Task<List<CustomerBillEntity>> USP_GetBillDetails(int billingId)
            => await _unitOfWork.CustomerBillRepository.USP_GetBillDetails(billingId);

     
    }
}
