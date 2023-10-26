using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("Users", Schema = "Admin")]
    public class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId")]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public virtual AddressEntity Address { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public virtual RoleEntity Roles { get; set; }
        public bool IsActive { get; set; }
        public bool IsAuthenticated { get; set; }
        [ForeignKey("AuditId")]
        public int AuditId { get; set; }
        public virtual AuditableEntity Auditable { get; set; }
    }
}
