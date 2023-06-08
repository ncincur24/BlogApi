using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.DataAccess
{
    public class BlogContext : DbContext
    {
        public BlogContext()
        {

        }
        public BlogContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<HashTagBlog>().HasKey(x => new { x.BlogId, x.HashTagId });
            modelBuilder.Entity<RoleUseCase>().HasKey(x => new { x.RoleId, x.UseCaseId});
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Data Source=nemanja\sqlexpress;Initial Catalog=Blog;Integrated Security=True;Pooling=False").UseLazyLoadingProxies();
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        e.UpdatedAt= DateTime.UtcNow;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HashTag> HashTags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<HashTagBlog> HashTagBlogs { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
    }
}
