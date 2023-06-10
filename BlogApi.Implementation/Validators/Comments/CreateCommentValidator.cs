using BlogApi.Application.UseCases.DTO.Comments;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Validators.Comments
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDTO>
    {
        private BlogContext context;
        public CreateCommentValidator(BlogContext context) 
        { 
            this.context = context;
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Content).Cascade(CascadeMode.Stop).NotEmpty().MaximumLength(300);
            RuleFor(x => x.BlogId).NotEmpty().Must(x => Exists(x, context.Blogs)).WithMessage("This blog doesnt exists");
            RuleFor(x => x.ParentId).Must(x => x == null || Exists(x, context.Comments)).WithMessage("This parrent comment doesn't exists");

        }
        private bool Exists<T>(int? id, DbSet<T> entity) where T : Entity
        {
            return entity.Any(x => x.Id == id);
        }
    }
}
