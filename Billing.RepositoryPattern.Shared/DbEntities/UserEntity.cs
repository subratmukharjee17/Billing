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
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "EmailId is required")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public virtual RolesEntity Roles { get; set; }
        public bool IsActive { get; set; }
        public bool IsAuthenticated { get; set; }
        [ForeignKey("AuditId")]
        public int AuditId { get; set; }
        public virtual AuditableEntity Auditable { get; set; }
    }
}
