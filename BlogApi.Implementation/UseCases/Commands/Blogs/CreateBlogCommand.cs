using BlogApi.Application;
using BlogApi.Application.Uploads;
using BlogApi.Application.UseCases.Commands.Blogs;
using BlogApi.Application.UseCases.DTO.Blogs;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using BlogApi.Implementation.Validators.Blogs;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Commands.Blogs
{
    public class CreateBlogCommand : EfUseCase, ICreateBlogCommand
    {
        private IApplicationActor actor;
        private CreateBlogValidator validator;
        private IBase64FileUploader uploader;
        public CreateBlogCommand(BlogContext context, CreateBlogValidator validator, IApplicationActor actor, IBase64FileUploader uploader) : base(context)
        {
            this.validator = validator;
            this.actor = actor;
            this.uploader = uploader;
        }

        public int Id => 8;

        public string Name => "Create blog";

        public string Description => "Create blog using entity framework";

        public void Execute(CreateBlogDTO request)
        {
            validator.ValidateAndThrow(request);

            //var filePath = "default.jpg";
            //if(request.Image!=null)
            //{
            //    filePath = uploader.Upload(request.Image, UploadType.Blog);
            //}

            //Context.Images.Add(new Image { Path = filePath });
            //Context.SaveChanges();

            Context.Add(new Blog
            {
                AuthorId = actor.Id,
                CategoryId = request.CategoryId,
                Content = request.Content,
                ImageId = 1,//Context.Images.Max(x => x.Id),
                Title = request.Title,
            });
            Context.SaveChanges();
        }
    }
}
