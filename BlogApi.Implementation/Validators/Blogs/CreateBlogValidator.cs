using BlogApi.Application.UseCases.DTO.Blogs;
using BlogApi.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators.Blogs
{
    public class CreateBlogValidator : AbstractValidator<CreateBlogDTO>
    {
        private BlogContext context;
        public CreateBlogValidator(BlogContext context)
        {
            this.context = context;

            RuleFor(x => x.Content).NotEmpty().MaximumLength(60);       
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty().Must(x => context.Categories.Any(y => y.Id == x)).WithMessage("This category doesn't exist");      
        }
    }
}
