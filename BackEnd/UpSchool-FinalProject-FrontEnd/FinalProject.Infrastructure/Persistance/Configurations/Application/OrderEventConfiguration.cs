using FinalProject.Domain.Entities;
using FinalProject.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Persistance.Configurations.Application
{
    public class OrderEventConfiguration : IEntityTypeConfiguration<OrderEvent>
    {
        public void Configure(EntityTypeBuilder<OrderEvent> builder)
        {
            //Id
            builder.HasKey(e => e.Id);


            //Properties
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Status).HasConversion<int>();

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired(false);


            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);


            builder.ToTable("OrderEvents");

        }
    }
}
