﻿using Billing.RepositoryPattern.DAL.DbContexts;
using Billing.RepositoryPattern.Shared.Interfaces;

namespace Billing.RepositoryPattern.Api.Services.UserService
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWorkService(ApplicationDbContext dbContext, IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _dbContext = dbContext;
            User = userRepository;
            Address = addressRepository;
        }

        public IUserRepository User { get; set; }
        public IAddressRepository Address { get; set; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}