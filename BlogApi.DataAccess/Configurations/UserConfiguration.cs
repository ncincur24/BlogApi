using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigurationRules(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(80);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(70);
            builder.Property(x => x.Password).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.UserName).IsUnique();

            builder.HasMany(x => x.Blogs).WithOne(x => x.User).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Comments).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
