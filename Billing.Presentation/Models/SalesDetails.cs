using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.Presentation.Models
{
    public class SalesDetails
    {
        public int BillNo { get; set; }
        public DateTime? SaleDate { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public Int64 CustomerPhNo { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductWeight { get; set; }
        public decimal ProductRate { get; set; }
        public decimal Amount { get; set; }
    }
}
