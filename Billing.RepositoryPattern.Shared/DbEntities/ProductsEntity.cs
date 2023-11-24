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

        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }
       
        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        public float Price { get; set; }
     
        public bool IsActive { get; set; }

     
    }
}
