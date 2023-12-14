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

namespace Billing.RepositoryPattern.Api.Services.SalesService
{
    public class SalesService :ISalesService
    {
        public IUnitOfWork _unitOfWork;
        public SalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task<string> AddCustomerAndBillingInfo(SalesDto salesDetails)
		{
			var customer = new CustomersEntity
			{
				CustomerId = salesDetails.CustomerId,
				CustomerName = salesDetails.CustomerName,
				PhoneNo = salesDetails.PhoneNo
			};

			_unitOfWork.CustomerRepository.Add(customer);
			await _unitOfWork.CommitAsync();

			var billing = new BillingInfoEntity
			{
				//BillingId = salesDetails.BillingId,
				UserID = salesDetails.UserID,
				CustomerId = customer.CustomerId,
				PaymentType = salesDetails.PaymentType,
				Price = salesDetails.Price,
				CreatedBy = salesDetails.CreatedBy,
				CreatedDate = DateTime.Now
			};

			_unitOfWork.BillingInfoRepository.Add(billing);
			await _unitOfWork.CommitAsync();

			// Retrieve the generated BillingId from the database
			var generatedBillingId = billing.BillingId;

			var jsonResult = JsonConvert.SerializeObject(generatedBillingId);
			return jsonResult;
		}

		public async Task AddSales(SalesDto salesDetails)
		{
			var sales = new SalesDetailsEntity
			{
				SaleDate = DateTime.Now,
				BillingId = salesDetails.BillingId,
				ProductId = salesDetails.ProductId,
				Quantity = salesDetails.Quantity,
				Amount = salesDetails.Amount
			};

			_unitOfWork.SalesDetailsRepository.Add(sales);
			await _unitOfWork.CommitAsync();
		}
		

        public async Task<IEnumerable<SalesDetailsEntity>> GetAll()
            => await _unitOfWork.SalesDetailsRepository.GetAllAsync();


		public async Task<List<SalesDetailsEntity>> GetFilteredSales(int BillId)
			=> await _unitOfWork.SalesDetailsRepository.GetFilteredSales(BillId);

		public async Task<List<SalesDetailsEntity>> GetSalesDataByParameters(string fromdate, string todate, string period)
            => await _unitOfWork.SalesDetailsRepository.GetSalesDataByParameters(fromdate, todate, period);

	}
}
