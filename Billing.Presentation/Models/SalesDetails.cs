using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.Presentation.Models
{
    public class SalesDetails
    {
        public Int64 BillNo { get; set; }
        public Int16 ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}
