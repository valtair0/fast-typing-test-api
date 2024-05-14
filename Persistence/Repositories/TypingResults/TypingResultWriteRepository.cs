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
    public class TypingResultWriteRepository : WriteRepository<Domain.Entities.TypingResult>, ITypingResultWriteRepository
    {
        public TypingResultWriteRepository(FastTypingTestDbContext context) : base(context)
        {
        }
    }
}
