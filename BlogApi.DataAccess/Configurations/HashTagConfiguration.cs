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
    public class HashTagConfiguration : EntityConfiguration<HashTag>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<HashTag> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Blogs).WithOne(x => x.HashTag).HasForeignKey(x => x.HashTagId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
