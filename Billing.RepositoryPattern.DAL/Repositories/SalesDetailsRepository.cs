using Billing.RepositoryPattern.InfraStructure;
using Billing.RepositoryPattern.Domain.DbEntities;
using Billing.RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Globalization;

namespace Billing.RepositoryPattern.InfraStructure.Repositories
{
    public class SalesDetailsRepository : GenericRepository<SalesDetailsEntity>, ISalesDetailsRepository
    {
        public SalesDetailsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<SalesDetailsEntity>> GetAll()
        {
           // var result = _dbContext.SubMenu.Where(x => x.MainMenuId.Equals(mainMenuId) && x.RoleId.Equals(roleId)).ToList();
           var result=_dbContext.SalesDetails.ToList();
            return await Task.FromResult(result);
        }



		public async Task<List<SalesDetailsEntity>> GetSalesDataByParameters(string fromdate, string todate, string period)
		{
			List<SalesDetailsEntity> result = null;

			if (!string.IsNullOrEmpty(fromdate) && !string.IsNullOrEmpty(todate))
			{
				//DateTime fromDate = DateTime.ParseExact(fromdate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
				//DateTime toDate = DateTime.ParseExact(todate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

				DateTime fromDate = DateTime.ParseExact(fromdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
				DateTime toDate = DateTime.ParseExact(todate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

				result = _dbContext.SalesDetails
					.Where(s => s.SaleDate >= fromDate && s.SaleDate <= toDate)
					.ToList();

			}
			else
			{
				DateTime fromDate1 = DateTime.Today.Date;
                DateTime toDate1 = DateTime.Today.Date;

				if (!string.IsNullOrEmpty(period))
				{
					if (period.ToLower() == "weekly")
					{
                       // toDate1 = fromDate1.AddDays(6 - (int)fromDate1.DayOfWeek).Date;
                        toDate1 = fromDate1.AddDays(-(int)fromDate1.DayOfWeek).Date;
                    }
					else if (period.ToLower() == "monthly")
					{
                        toDate1 = new DateTime(fromDate1.Year, fromDate1.Month, 1).Date;
                        // Adjust toDate to the end of the month
                      //  toDate1 = new DateTime(fromDate1.Year, fromDate1.Month, DateTime.DaysInMonth(fromDate1.Year, fromDate1.Month));
					}
					else if (period.ToLower() == "daily")
					{
						fromDate1 = fromDate1;
                        toDate1 = toDate1;
                    }
					else
					{
						// Handle invalid period input if necessary
						// For instance, return an error or throw an exception
						throw new ArgumentException("Invalid period specified");
					}
				}

				result = _dbContext.SalesDetails
					.Where(s => s.SaleDate <= fromDate1 && s.SaleDate >= toDate1)
					.ToList();
			}

			return await Task.FromResult(result);
		}



		public async Task<List<SalesDetailsEntity>> GetFilteredSales(int BillId)
        {
            var result = _dbContext.SalesDetails.Where(x => x.BillingId.Equals(BillId)).ToList();
            return await Task.FromResult(result);
        }


    }
}
