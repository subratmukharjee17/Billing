using Billing.RepositoryPattern.InfraStructure.Repositories;
using Billing.RepositoryPattern.Domain.Interfaces;
using Billing.RepositoryPattern.Domain.UnitOfWork;
using System.Threading.Tasks;
using Billing.RepositoryPattern.Domain.DbEntities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Billing.RepositoryPattern.InfraStructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IMainMenuRepository _mainMenuRepository;
        private ISubMenuRepository _subMenuRepository;
        private ISalesDetailsRepository _salesDetailsRepository;
        private IProductRepository _productRepository;
        private IBillingInfoRepository _billingInfoRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_dbContext);
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                return _roleRepository = _roleRepository ?? new RoleRepository(_dbContext);
            }
        }

        public IMainMenuRepository MainRepository
        {
            get
            {
                return _mainMenuRepository = _mainMenuRepository ?? new MainMenuRepository(_dbContext);
            }
        }

        public ISubMenuRepository SubMenuRepository
        {
            get
            {
                return _subMenuRepository = _subMenuRepository ?? new SubMenuRepository(_dbContext);
            }
        }

        public ISalesDetailsRepository SalesDetailsRepository
        {
            get
            {
                return _salesDetailsRepository = _salesDetailsRepository ?? new SalesDetailsRepository(_dbContext);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_dbContext);
            }
        }

        public IBillingInfoRepository BillingInfoRepository
        {
            get
            {
                return _billingInfoRepository = _billingInfoRepository ?? new BillingInfoRepository(_dbContext);
            }
        }
        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
