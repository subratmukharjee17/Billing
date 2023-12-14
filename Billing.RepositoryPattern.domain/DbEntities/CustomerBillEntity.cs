using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System;
using System.Numerics;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    
    public class CustomerBillEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Int32 BillingId { get; set; }

		public DateTime SaleDate { get; set; }

		public string PaymentType { get; set; }

		public string ProductName { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal Quantity { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Amount { get; set; }
		[Column(TypeName = "decimal(18, 4)")]
		public decimal Price { get; set; }


	}
}
