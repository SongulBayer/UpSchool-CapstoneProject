using FinalProject.Domain.Entities;
using FinalProject.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Persistance.Configurations.Application
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {

            //Id
            builder.HasKey(x => x.Id);

            // Title
            builder.Property(x => x.Title).IsRequired(false);
            builder.Property(x => x.Title).HasMaxLength(150);
            builder.HasIndex(x => x.Title);

            //builder.HasIndex(x => new {x.Title,x.UserName });

            // UserName
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.UserName).HasMaxLength(100);

            // Password
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(1000);

            // Url
            builder.Property(x => x.Url).IsRequired(false);
            builder.Property(x => x.Url).HasMaxLength(1000);

            // IsFavourite
            builder.Property(x => x.IsFavourite).IsRequired(false);

            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);



            //builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);

            builder.ToTable("Accounts");
        }
    }
}
