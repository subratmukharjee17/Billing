using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("Address", Schema = "Admin")]
    public class AddressEntity
    {
        [Key]
        [Column("AddressId")]
        [DefaultValue(null)]
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public string AuditId { get; set; }
        public bool IsActive { get; set; }
    }
}
