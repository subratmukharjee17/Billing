using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billing.RepositoryPattern.InfraStructure.UnitOfWork;
using System.Linq;
using System;

namespace Billing.RepositoryPattern.Api.Services.ProductService
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProduct(ProductDto productDto)
        {

            var product = new ProductsEntity
            {
              ProductName= productDto.ProductName,
              Price= productDto.Price,
              ProductCode= productDto.ProductCode,
              IsActive= productDto.IsActive
            };
         
            _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ProductsEntity>> GetAll()
            => await _unitOfWork.ProductRepository.GetAllAsync();

    }
}
