using BlogApi.Application.UseCases.DTO.Blogs;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators.Blogs
{
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogDTO>
    {
        private BlogContext context;

        public UpdateBlogValidator(BlogContext context)
        {
            this.context = context;

            RuleFor(x => x.Id).NotEmpty().Must(x => Exists(x, context.Blogs)).WithMessage("This blog doesn't exist");
            RuleFor(x => x.Content).MaximumLength(60);
            RuleFor(x => x.CategoryId).Must(x => x == null || Exists(x, context.Categories)).WithMessage("This category doesn't exist");
        }
        private bool Exists<T>(int? id, DbSet<T> entity) where T : Entity
        {
            return entity.Any(x => x.Id == id);
        }
    }
}
