using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("SubMenu", Schema = "Admin")]
    public class SubMenuEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SubMenuId")]
        [Required(ErrorMessage = "Sub menu id is required")]
        public int SubMenuId { get; set; }
        [Required(ErrorMessage = "Sub menu is required")]
        public string SubMenuName { get; set; }
        [Required(ErrorMessage = "Controller name is required")]
        public string ControllerName { get; set; }
        [Required(ErrorMessage = "Action name is required")]
        public string ActionName { get; set; }
        public int? SubMenuSortOrder { get; set; }
        public bool HideFlag { get; set; }
        [ForeignKey("MainMenuId")]
        public int MainMenuId { get; set; }
        public virtual MainMenuEntity MainMenu { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public virtual RolesEntity Roles { get; set; }
    }
}
