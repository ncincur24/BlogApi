using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Blogs;
using BlogApi.Application.UseCases.DTO.Comments;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Queries
{
    public class GetSingleBlogQuery : EfUseCase, IGetSingleBlogQuery
    {
        public GetSingleBlogQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Get single blog";

        public string Description => "Get single blog using Entity Framework";

        public SingleBlogDTO Execute(int id)
        {
            var blog = Context.Blogs.Find(id);
            return new SingleBlogDTO
            {
                Id = id,
                Author = blog.User.FullName,
                Category = blog.Category.Name,
                Content = blog.Content,
                DatePosted = blog.CreatedAt,
                Title = blog.Title,
                NumberOfComments = blog.Comments.Count,
                Comments = blog.Comments.Any() ? blog.Comments.Select(x => new CommentDTO
                {
                    Comment = x.Content,
                    CommentedAt = x.CreatedAt,
                    CommentedBy = x.User.FullName,
                    Id = x.Id,
                    Replies = x.ChildComment.Any() ? x.ChildComment.Select(y => new CommentDTO
                    {
                        Id = y.Id,
                        Comment = y.Content,
                        CommentedAt = y.CreatedAt,
                        CommentedBy = y.User.FullName
                    }).ToList() : null

                }).ToList() : null,
                HashTags = blog.HasTags.Any() ? blog.HasTags.Select(x => new LookUpDTO
                {
                    Id = x.HashTagId,
                    Name = x.HashTag.Name
                }).ToList() : null
            };
        }
    }
}
