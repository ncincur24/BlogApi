using BlogApi.Application.UseCases;
using BlogApi.Application.UseCases.DTO.Searches;
using BlogApi.Application.UseCases.DTO.Users;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.UseCases.Queries
{
    public class GetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public GetUsersQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Search users";

        public string Description => "Search users using entity framework";

        IEnumerable<GetUserDTO> IQuery<UserSearch, IEnumerable<GetUserDTO>>.Execute(UserSearch search)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.FullName.Contains(search.Keyword) || x.UserName.Contains(search.Keyword));
            }

            if (search.RoleId != null && Context.Role.Any(x => x.Id == search.RoleId))
            {
                query = query.Where(x => x.RoleId == search.RoleId);
            }

            return query.Select(x => new GetUserDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                DateJoined = x.CreatedAt,
                Email = x.Email,
                Role = x.Role.Name,
                UserName = x.UserName,
            }).ToList();
        }
    }
}
