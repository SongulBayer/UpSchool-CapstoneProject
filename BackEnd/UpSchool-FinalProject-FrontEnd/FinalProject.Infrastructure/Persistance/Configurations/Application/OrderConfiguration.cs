using FinalProject.Domain.Entities;
using FinalProject.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Persistance.Configurations.Application
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Id
            builder.HasKey(x => x.Id);

            //Properties
            builder.Property(x=>x.RequestedAmount).IsRequired();
            builder.Property(x=>x.TotalFoundedAmount).IsRequired();
            builder.Property(x=>x.ProductCrowlType).IsRequired();
            builder.Property(x => x.ProductCrowlType).HasConversion<int>();

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired(false);



            //Relationships
            builder.HasMany<Product>(x => x.Products).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasMany<OrderEvent>(x => x.OrderEvents).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);


            builder.ToTable("Orders");

        }
    }
}
