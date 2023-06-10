using BlogApi.Application.UseCases.Commands.Blogs;
using BlogApi.Application.UseCases.DTO;
using BlogApi.DataAccess;
using BlogApi.DataAccess.Configurations;
using BlogApi.Implementation.UseCases;
using BlogApi.Implementation.Validators.Blogs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.Blogs
{
    public class DeleteBlogCommand : EfUseCase, IDeleteBlogCommand
    {
        private DeleteBlogValidator validator;
        public DeleteBlogCommand(BlogContext context, DeleteBlogValidator validator) : base(context)
        {
            this.validator = validator;
        }
        public int Id => 9;

        public string Name => "Soft delte blog";

        public string Description => "Soft delete blog using entity framework";

        public void Execute(int id)
        {
            validator.ValidateAndThrow(id);

            var blog = Context.Blogs.Find(id);
            blog.DeletedAt = DateTime.Now;
            blog.IsActive = false;

            Context.SaveChanges();
        }
    }
}
