using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("Customers", Schema = "Product")]
    public class CustomersEntity
    {
        [Key]
        [Column("CustomerId")]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNo { get; set; }
 
    }
}
