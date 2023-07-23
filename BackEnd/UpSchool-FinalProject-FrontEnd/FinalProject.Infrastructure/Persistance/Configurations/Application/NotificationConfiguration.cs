using FinalProject.Domain.Entities;
using FinalProject.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Persistance.Configurations.Application
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            //Id
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Description).IsRequired();
            builder.Property(x=>x.Title).IsRequired();

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired(false);

            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);

            builder.ToTable("Notifications");
        }
    }
}
