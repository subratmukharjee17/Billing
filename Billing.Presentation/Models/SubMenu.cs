using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.Presentation.Models
{
    public class SubMenu
    {
        public int SubMenuId { get; set; }
        public string? SubMenuName { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public int MainMenuId { get; set; }
        public int RoleId { get; set; }
        public int? SubMenuSortOrder { get; set; }
        public bool HideFlag { get; set; }
    }
}
