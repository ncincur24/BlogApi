using BlogApi.Application.UseCases.DTO;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Queries
{
    public class GetHashTagsQuery : EfUseCase, IGetHashTagsQuery
    {
        public GetHashTagsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Search hash tags";

        public string Description => "Searching hash tags using Entity Framework";

        public IEnumerable<LookUpDTO> Execute(BaseSearch search)
        {
            var query = Context.HashTags.Where(x => x.IsActive).AsQueryable();
            if(!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword));
            }
            return query.Select(x => new LookUpDTO
            {
                Name = x.Name,
                Id = x.Id,
            }).ToList();
        }
    }
}
