using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("SalesDetails", Schema = "Product")]
    public class SalesDetailsEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SalesId")]
        public int SalesId { get; set; }

        [ForeignKey("ProductId")]
        [Required(ErrorMessage = "ProductId is required")]
        public int ProductId { get; set; }

        public virtual ProductsEntity Products  { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity{ get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Column(TypeName = "decimal(18, 2)")]     
        public decimal Amount { get; set; }
       
        public  DateTime SaleDate { get; set; }

        [ForeignKey("BillingId")]
        public int BillingId { get; set; }

        public virtual BillingInfoEntity BillingInfo { get; set; }
    }
}
