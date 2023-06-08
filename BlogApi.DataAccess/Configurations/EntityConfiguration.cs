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
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");
            ConfigurationRules(builder);
        }
        protected abstract void ConfigurationRules(EntityTypeBuilder<T> builder);
    }
}
