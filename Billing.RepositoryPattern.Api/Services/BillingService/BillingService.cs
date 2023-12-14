using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billing.RepositoryPattern.InfraStructure.UnitOfWork;
using System.Linq;
using System;
using Billing.RepositoryPattern.InfraStructure.Repositories;

namespace Billing.RepositoryPattern.Api.Services.BillingService
{
    public class BillingService : IBillingService
    {
        public IUnitOfWork _unitOfWork;
        public BillingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddBillingInfo(BillingInfoDto billingDto)
        {

            var billing = new BillingInfoEntity
            {
              // BillingId = billingDto.BillingId,
                CreatedDate=DateTime.Now,
                CustomerId = billingDto.CustomerId,
                UserID = billingDto.UserID,
               CreatedBy= billingDto.CreatedBy,
               PaymentType = billingDto.PaymentType,

            };
          
            _unitOfWork.BillingInfoRepository.Add(billing);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<BillingInfoEntity>> GetAll()
            => await _unitOfWork.BillingInfoRepository.GetAllAsync();

		public async Task<int> GetMaxBillingId()
		{
			return await _unitOfWork.BillingInfoRepository.GetMaxBillingIdAsync();
		}

		public async Task<List<BillingInfoEntity>> GetFilteredBillingInfo(int BillId)
            => await _unitOfWork.BillingInfoRepository.GetFilteredBillingInfo(BillId);
	}
}
