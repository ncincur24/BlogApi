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
    public class BlogConfiguration : EntityConfiguration<Blog>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Content).IsRequired();

            builder.HasIndex(x => x.Title);

            builder.HasMany(x => x.HasTags).WithOne(x => x.Blog).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
