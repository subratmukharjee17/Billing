
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("Roles", Schema = "Admin")]
    public class RoleEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RoleId")]
        [DefaultValue(null)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Desription { get; set; }
        public bool IsActive { get; set; }

    }
}
