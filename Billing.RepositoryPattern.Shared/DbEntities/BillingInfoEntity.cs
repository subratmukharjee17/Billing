using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System;
using System.Numerics;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("BillingInfo", Schema = "Product")]
    public class BillingInfoEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BillingId")]
        public int BillingId { get; set; }


        [ForeignKey("CustomerId")]
        [Required(ErrorMessage = "CustomerId is required")]
        public string CustomerId { get; set; }
        
        public virtual CustomersEntity Customers { get; set; }  

        [Required(ErrorMessage = "PaymentType is required")]
        public string PaymentType { get; set; }

        [Column(TypeName = "decimal(18, 4)")]

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        public string UserID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        

    }
}
