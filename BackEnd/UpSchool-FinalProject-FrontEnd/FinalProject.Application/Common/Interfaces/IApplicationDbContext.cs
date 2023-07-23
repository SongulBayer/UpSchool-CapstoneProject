using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace FinalProject.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderEvent> OrderEvents { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        //Rollback Transation gibi herhalde
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //int dönmesinin sebebi etkilenen kayıt sayısını döner.
        int SaveChanges();
    }
}
