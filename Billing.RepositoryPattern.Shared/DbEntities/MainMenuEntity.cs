using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Billing.RepositoryPattern.Domain.DbEntities
{
    [Table("MainMenu", Schema = "Admin")]
    public class MainMenuEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("MainMenuId")]
        public int MainMenuId { get; set; }
        public string MainMenuName { get; set; }
    }
}
