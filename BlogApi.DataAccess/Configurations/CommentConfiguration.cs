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
    public class CommentConfiguration : EntityConfiguration<Comment>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Content).IsRequired().HasMaxLength(150);

            builder.HasMany(x => x.ChildComment).WithOne(x => x.ParentComment).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
