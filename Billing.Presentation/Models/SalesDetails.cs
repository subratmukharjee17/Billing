﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.Presentation.Models
{
    public class SalesDetails
    {
		public int SalesId { get; set; }
		public int ProductId { get; set; }
		public decimal Quantity { get; set; }
		public decimal Amount { get; set; }
		public DateTime SaleDate { get; set; }
		public int BillingId { get; set; }

		public string PaymentType { get; set; }
		public decimal Price { get; set; }
		public string UserID { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }

		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string PhoneNo { get; set; }
	}
}
