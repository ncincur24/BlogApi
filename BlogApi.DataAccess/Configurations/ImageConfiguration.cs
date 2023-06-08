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
    public class ImageConfiguration : EntityConfiguration<Image>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.Path).IsRequired();

            builder.HasMany(x=>x.Blogs).WithOne(x=>x.Image).HasForeignKey(x=>x.ImageId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
