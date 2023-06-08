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
    public class CategoryConfiguration : EntityConfiguration<Category>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(x => x.Blogs).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
