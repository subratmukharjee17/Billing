using Newtonsoft.Json;

namespace Billing.Presentation.Models
{
    public class MainMenu
    {
        public int MainMenuId { get; set; }
        public string? MainMenuName { get; set; }
        public int? MenuSortOrder { get; set; }
        public bool HideFlag { get; set; }
        public ICollection<SubMenu>? SubMenuList { get; set; }

    }
}
