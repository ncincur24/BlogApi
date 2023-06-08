using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.DataAccess.Configurations
{
    public class RoleConfiguration : EntityConfiguration<Role>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);

            builder.HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.RoleUseCases).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
