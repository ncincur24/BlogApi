using BlogApi.Application;
using BlogApi.Application.UseCases.Commands.Comments;
using BlogApi.Application.UseCases.DTO.Comments;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using BlogApi.Implementation.Validators.Categories;
using BlogApi.Implementation.Validators.Comments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.Comments
{
    public class CreateCommentCommand : EfUseCase, ICreateCommentCommand
    {
        private CreateCommentValidator validator;
        private readonly IApplicationActor actor;
        public CreateCommentCommand(BlogContext context, CreateCommentValidator validator, IApplicationActor actor) : base(context)
        {
            this.validator = validator;
            this.actor = actor;
        }
        public int Id => 7;

        public string Name => "Post comment";

        public string Description => "Post comment using entity framework";

        public void Execute(CreateCommentDTO request)
        {
            validator.ValidateAndThrow(request);

            Context.Add(new Comment
            {
                BlogId = request.BlogId,
                UserId = actor.Id,
                Content = request.Content,
                ParentId = request.ParentId
            });
            Context.SaveChanges();
        }
    }
}
