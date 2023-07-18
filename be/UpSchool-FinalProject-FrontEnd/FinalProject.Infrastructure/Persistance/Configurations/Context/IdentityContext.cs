using FinalProject.Domain.Entities;
using FinalProject.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinalProject.Infrastructure.Persistance.Configurations.Context
{
    //string->userid
    public class IdentityContext:IdentityDbContext<User,Role,string,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Ignores
            modelBuilder.Ignore<Account>();
            modelBuilder.Ignore<Product>();
        //Bu satırı ignore etme 
            //modelBuilder.Ignore<Order>();
            modelBuilder.Ignore<OrderEvent>();
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Setting>();

    //        modelBuilder.Entity<Order>()
    //.HasOne<User>()
    //.WithMany()
    //.HasForeignKey(x => x.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
