using System.ComponentModel.DataAnnotations.Schema;

namespace Billing.Presentation.Models
{
	public class CustomerBillViewModel
	{
		public Int32 BillingId { get; set; }

		public DateTime SaleDate { get; set; }

		public string PaymentType { get; set; }

		public string ProductName { get; set; }

		public decimal Quantity { get; set; }

		public decimal Amount { get; set; }

		public decimal Price { get; set; }
	}
}
