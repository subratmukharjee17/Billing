﻿using Billing.RepositoryPattern.Api.Dtos;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.InfraStructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Api.Services.SalesService
{
    public interface ISalesService
    {
       public Task<IEnumerable<SalesDetailsEntity>> GetAll();
        public Task AddSales(SalesDto sales);

        public Task AddCustomerAndBillingInfo(SalesDto sales);
   
    }
}
