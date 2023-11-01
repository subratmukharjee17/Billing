using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("SalesDetails", Schema = "Admin")]
    public class SalesDetailsEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("BillNo")]
        public int BillNo { get; set; }

        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "CustomerName is required")]
        public string CustomerAddress { get; set; }
        public Int64 CustomerPhNo { get; set; }
        [Required(ErrorMessage = "CustomerPhNo is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "ProductName is required")]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductWeight { get; set; }
        [Required(ErrorMessage = "ProductWeight is required")]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductRate { get; set; }
        [Required(ErrorMessage = "ProductRate is required")]


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        
    
    }
}
