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

        public async Task AddSales(SalesDto salesDto)
        {

            var sales = new SalesDetailsEntity
            {
              //  SalesId=salesDto.SalesId,
                SaleDate=salesDto.SaleDate,
                BillingId = salesDto.BillingId,
                ProductId = salesDto.ProductId,
                Quantity = salesDto.Quantity,
                Amount = salesDto.Amount

            };
          
            _unitOfWork.SalesDetailsRepository.Add(sales);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<SalesDetailsEntity>> GetAll()
            => await _unitOfWork.SalesDetailsRepository.GetAllAsync();

        //public async Task<UserEntity> Login(string userName, string password) =>
        //   await _unitOfWork.UserRepository.Login(userName, password);
    }
}
