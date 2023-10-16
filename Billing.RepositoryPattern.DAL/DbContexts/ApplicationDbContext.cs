using Microsoft.EntityFrameworkCore;
using Billing.RepositoryPattern.Shared.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.RepositoryPattern.DAL.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentSportEntity> StudentSport { get; set; }
        public DbSet<StudentAddressEntity> StudentAddress { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
    }
}
