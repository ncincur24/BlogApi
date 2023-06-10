using BlogApi.Application.Logging;
using BlogApi.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private readonly BlogContext _context;
        public EfUseCaseLogger(BlogContext context)
        {
            _context = context;
        }

        public void Add(UseCaseLogEntry entry)
        {
            _context.UseCaseLogs.Add(new Domain.Entities.UseCaseLog
            {
                Actor = entry.Actor,
                ActorId = entry.ActorId,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                UseCaseName = entry.UseCaseName,
                CreatedAt = DateTime.UtcNow
            });

            _context.SaveChanges();
        }
    }
}
