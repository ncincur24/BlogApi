using BlogApi.Application.UseCases.Commands.Blogs;
using BlogApi.Application.UseCases.Commands.Comments;
using BlogApi.DataAccess;
using BlogApi.Implementation.Validators.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.Comments
{
    public class DeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {
        private DeleteCommentValidator validator;
        public DeleteCommentCommand(BlogContext context, DeleteCommentValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 10;

        public string Name => "Soft delete comment";

        public string Description => "Soft deleting comment using entity framework";

        public void Execute(int id)
        {
            validator.ValidateAndThrow(id);

            var comment = Context.Comments.Find(id);
            comment.DeletedAt = DateTime.Now;
            comment.IsActive = false;

            Context.SaveChanges();
        }
    }
}
