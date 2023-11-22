using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("Products", Schema = "Product")]
    public class ProductsEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ProductId")]
        public int ProductId { get; set; }

        public string ProductCode { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; }
       
        [Column(TypeName = "decimal(18, 4)")]

        [Required(ErrorMessage = "ProductPrice is required")]
        public decimal Price { get; set; }
     
        public bool IsActive { get; set; }

     
    }
}
