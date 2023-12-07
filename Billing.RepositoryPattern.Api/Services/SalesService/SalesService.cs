using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billing.RepositoryPattern.InfraStructure.UnitOfWork;
using System.Linq;
using System;
using Billing.RepositoryPattern.InfraStructure.Repositories;

namespace Billing.RepositoryPattern.Api.Services.SalesService
{
    public class SalesService :ISalesService
    {
        public IUnitOfWork _unitOfWork;
        public SalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task AddCustomerAndBillingInfo(SalesDto salesDetails)
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
				BillingId = salesDetails.BillingId,
				UserID = salesDetails.UserID,
				CustomerId = Convert.ToString(customer.CustomerId),
				PaymentType = salesDetails.PaymentType,
				Price = salesDetails.Price,
				CreatedBy = salesDetails.CreatedBy,
				CreatedDate = DateTime.Now
			};

			_unitOfWork.BillingInfoRepository.Add(billing);
			await _unitOfWork.CommitAsync();
		}

		public async Task AddSales(SalesDto salesDetails)
		{
			var sales = new SalesDetailsEntity
			{
				SaleDate = salesDetails.SaleDate,
				BillingId = salesDetails.BillingId,
				ProductId = salesDetails.ProductId,
				Quantity = salesDetails.Quantity,
				Amount = salesDetails.Amount
			};

			_unitOfWork.SalesDetailsRepository.Add(sales);
			await _unitOfWork.CommitAsync();
		}
		//public async Task AddSales(SalesDto salesDto)
  //      {
		//	var customer = new CustomersEntity
		//	{
		//		CustomerId = salesDto.CustomerId,
		//		CustomerName = salesDto.CustomerName,
		//		PhoneNo = salesDto.PhoneNo
		//	};

		//	_unitOfWork.CustomerRepository.Add(customer);
		//	await _unitOfWork.CommitAsync();
		//	var Billing = new BillingInfoEntity
		//	{
		//		BillingId = salesDto.BillingId,
		//		UserID = salesDto.UserID,
		//		CustomerId = Convert.ToString(customer.CustomerId), // Convert.ToString(salesDto.CustomerId),
		//		PaymentType = salesDto.PaymentType,
		//		Price = salesDto.Price,
		//		CreatedBy = salesDto.CreatedBy,
		//		CreatedDate = DateTime.Now
		//	};
		//	_unitOfWork.BillingInfoRepository.Add(Billing);
		//	await _unitOfWork.CommitAsync();

		//	//may be multipul entries will come for salesdetails
		//	var sales = new SalesDetailsEntity
  //          {
  //              //  SalesId=salesDto.SalesId,
  //              SaleDate = salesDto.SaleDate,
  //              BillingId = Billing.BillingId,//salesDto.BillingId,
  //              ProductId = salesDto.ProductId,
  //              Quantity = salesDto.Quantity,
  //              Amount = salesDto.Amount

  //          };
			
		//	_unitOfWork.SalesDetailsRepository.Add(sales);

		//	//foreach (var salesEntry in salesDto)
		//	//{
		//	//	var sales = new SalesDetailsEntity
		//	//	{
		//	//		SaleDate = salesDto.SaleDate,
		//	//		BillingId = salesDto.BillingId,
		//	//		ProductId = salesEntry.ProductId,
		//	//		Quantity = salesEntry.Quantity,
		//	//		Amount = salesEntry.Amount
		//	//	};

		//	//	_unitOfWork.SalesDetailsRepository.Add(sales);
		//	//}

		//	await _unitOfWork.CommitAsync();
  //      }

        public async Task<IEnumerable<SalesDetailsEntity>> GetAll()
            => await _unitOfWork.SalesDetailsRepository.GetAllAsync();

     
    }
}
