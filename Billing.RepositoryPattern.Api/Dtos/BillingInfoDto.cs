using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.RepositoryPattern.Api.Dtos
{
    public class BillingInfoDto
    {
        public int BillingId { get; set; }
        public string CustomerId { get; set; }
        public string PaymentType { get; set; }
        public decimal Price { get; set; }
        public string UserID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
