using FinalProject.Application.Common.Interfaces;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinalProject.Infrastructure.Persistance.Configurations.Context
{
    public class ApplicationDbContext:DbContext,IApplicationDbContext
    {
        public DbSet<OrderEvent> OrderEvents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Account> Accounts { get ; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Ignores
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Role>();
            modelBuilder.Ignore<UserRole>();
            modelBuilder.Ignore<RoleClaim>();
            modelBuilder.Ignore<UserToken>();
            modelBuilder.Ignore<UserClaim>();
            modelBuilder.Ignore<UserLogin>();

            base.OnModelCreating(modelBuilder);
        }

    }
    
}
