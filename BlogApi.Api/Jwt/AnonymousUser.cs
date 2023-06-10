using BlogApi.Application;

namespace BlogApi.Api.Jwt
{
    public class AnonymousUser : IApplicationActor
    {
        public int Id => 0;
        public string Email => "anonymous@test.com";
        public string Username => "Anonymous";
        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,15 };
    }
}
