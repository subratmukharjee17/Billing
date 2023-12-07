using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("MainMenu", Schema = "Admin")]
    public class MainMenuEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MainMenuId")]
        public int MainMenuId { get; set; }
        public string MainMenuName { get; set; }
        public int? MenuSortOrder { get; set; }
        public bool HideFlag { get; set; }
        public virtual ICollection<SubMenuEntity> SubMenuList { get; set; }
    }
}
