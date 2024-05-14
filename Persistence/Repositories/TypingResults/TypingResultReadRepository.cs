using Application.Repositories.TypingExamm;
using Application.Repositories.TypinResult;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prsistence.Repositories.TypingResults
{
    public class TypingResultReadRepository : ReadRepository<Domain.Entities.TypingResult>, ITypingResultReadRepository
    {
        public TypingResultReadRepository(FastTypingTestDbContext context) : base(context)
        {
        }
    }
}
