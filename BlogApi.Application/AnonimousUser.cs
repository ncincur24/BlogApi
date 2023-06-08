using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application
{
    public class AnonimousUser : IApplicationActor
    {
        public int Id => 0;
        public string Email => "anonymous@test.com";
        public string Username => "Anonymous";
        public IEnumerable<int> AllowedUseCases => new List<int> { 17 };
    }
}
