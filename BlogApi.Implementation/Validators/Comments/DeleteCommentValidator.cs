using BlogApi.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators.Comments
{
    public class DeleteCommentValidator : AbstractValidator<int>
    {
        private BlogContext context;

        public DeleteCommentValidator(BlogContext context)
        {
            this.context = context;
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x).NotEmpty().Must(x => context.Comments.Any(y => y.Id == x)).WithMessage("This comment doesn't exist");
        }
    }
}
