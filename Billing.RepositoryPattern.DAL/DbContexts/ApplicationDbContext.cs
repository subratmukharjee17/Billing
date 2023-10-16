using Microsoft.EntityFrameworkCore;
using Billing.RepositoryPattern.Shared.DbEntities;

namespace Billing.RepositoryPattern.DAL.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
    }
}
