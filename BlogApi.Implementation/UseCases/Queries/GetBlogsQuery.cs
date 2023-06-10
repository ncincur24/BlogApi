using BlogApi.Application.UseCases;
using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Blogs;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using BlogApi.Domain.Entities;
using BlogApi.Implementation.Extensions;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Queries
{
    public class GetBlogsQuery : EfUseCase, IGetBlogsQuery
    {
        public GetBlogsQuery(BlogContext context) : base(context)
        {
        }
        public int Id => 1;

        public string Name => "Search blogs";

        public string Description => "Search blogs using Entity Framework";

        public PageRespondedDTO<BlogDTO> Execute(BlogSearch search)
        {
            var query = Context.Blogs.Include(x => x.User).Include(x => x.HasTags).Include(x => x.Comments).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.Contains(search.Keyword));
            }

            if (search.Categories is not null && search.Categories.Count() > 0)
            {
                query = query.Where(x => search.Categories.Contains(x.CategoryId));
            }

            if (search.NumberOfComments is not null && search.NumberOfComments > 0)
            {
                query = query.Where(x => x.Comments.Count > search.NumberOfComments);
            }

            return query.ToPagedResponse<Blog, BlogDTO>(search, x => new BlogDTO
            {
                Title = x.Title,
                Category = x.Category.Name,
                DatePosted = x.CreatedAt,
                NumberOfComments = x.Comments.Count,
                Id = x.Id,
                HashTags = x.HasTags.Select(y => new LookUpDTO
                {
                    Id = y.HashTagId,
                    Name = y.HashTag.Name
                }).ToList()
            });
        }
    }
}
