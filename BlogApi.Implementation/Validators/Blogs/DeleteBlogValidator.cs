using BlogApi.Application.UseCases.DTO;
using BlogApi.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators.Blogs
{
    public class DeleteBlogValidator : AbstractValidator<int>
    {
        private BlogContext context;

        public DeleteBlogValidator(BlogContext context)
        {
            this.context = context;
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x).NotEmpty().Must(x => context.Blogs.Any(y => y.Id == x)).WithMessage("This blog doesn't exist");
        }
    }
}
