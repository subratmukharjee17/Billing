using Microsoft.EntityFrameworkCore;
using Billing.RepositoryPattern.Domain.DbEntities;

namespace Billing.RepositoryPattern.InfraStructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> Users
        {
            get;
            set;
        }
        public DbSet<AddressEntity> Address
        {
            get;
            set;
        }
        public DbSet<AuditableEntity> Auditable
        {
            get;
            set;
        }
    }
}
