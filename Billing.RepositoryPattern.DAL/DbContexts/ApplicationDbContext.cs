﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<RolesEntity> Roles
        {
            get;
            set;
        }

        public DbSet<AuditableEntity> Auditable
        {
            get;
            set;
        }
        public DbSet<MainMenuEntity> MainMenu
        {
            get;
            set;
        }
        public DbSet<SubMenuEntity> SubMenu
        {
            get;
            set;
        }
        public DbSet<SalesDetailsEntity> SalesDetails 
        {
            get;
            set;
        }
        public DbSet<ProductsEntity> Product
        {
            get;
            set;
        }
        public DbSet<BillingInfoEntity> BillingInfo
        {
            get;
            set;
        }
       
    }
}
