using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Queries
{
    public class GetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        public GetCategoriesQuery(BlogContext context) : base(context) {}

        public int Id => 1;

        public string Name => "Search categories";

        public string Description => "Search categories using Entity Framework";

        public IEnumerable<LookUpDTO> Execute(BaseSearch search)
        {
            var query = Context.Categories.AsQueryable();
            if(!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            return query.Select(x => new LookUpDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
