using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.Presentation.Models
{
    public class BillingInfo
    {
        public Int64 BillNo { get; set; }
        public string CustomerName { get; set; }
        public Int64 CustomerPhNo { get; set; }
        public string PaymentType { get; set; }
        public string UserID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
