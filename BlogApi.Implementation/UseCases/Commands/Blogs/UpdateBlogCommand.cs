using BlogApi.Application.UseCases.Commands.Blogs;
using BlogApi.Application.UseCases.DTO.Blogs;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using BlogApi.Implementation.Validators.Blogs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.Blogs
{
    public class UpdateBlogCommand : EfUseCase, IUpdateBlogCommand
    {
        private UpdateBlogValidator validator;
        public UpdateBlogCommand(BlogContext context, UpdateBlogValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 11;

        public string Name => "Editing blog";

        public string Description => "Editing blog using entity framework";

        public void Execute(UpdateBlogDTO request)
        {
            validator.ValidateAndThrow(request);

            var blog = Context.Blogs.Find(request.Id);

            if (!string.IsNullOrEmpty(request.Title))
            {
                blog.Title=request.Title;
            }

            if (!string.IsNullOrEmpty(request.Content))
            {
                blog.Title=request.Title;
            }

            if(request.CategoryId != null)
            {
                blog.CategoryId = (int)request.CategoryId;
            }
            Context.SaveChanges();
        }
    }
}
