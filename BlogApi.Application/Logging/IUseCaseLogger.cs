using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Logging
{
    public interface IUseCaseLogger
    {
        void Add(UseCaseLogEntry entry);
    }
}
