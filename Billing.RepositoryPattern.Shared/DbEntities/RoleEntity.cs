using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.Shared.DbEntities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Desription { get; set; }
        public bool IsActive { get; set; }

    }
}
