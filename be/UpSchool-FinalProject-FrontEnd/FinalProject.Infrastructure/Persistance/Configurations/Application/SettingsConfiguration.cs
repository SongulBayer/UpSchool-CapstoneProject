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
    public class SettingsConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {

            //Id
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.SendEmail).IsRequired(false);
            builder.Property(x=>x.SendNotification).IsRequired(false);

            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);

        }
    }
}
