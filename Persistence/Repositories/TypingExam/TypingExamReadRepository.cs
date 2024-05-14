using Domain.Entities;
using Application.Repositories.TypingExamm;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prsistence.Repositories.TypingTest
{
    public class TypingExamReadRepository : ReadRepository<TypingExam>, ITypingExamReadRepository
    {
        public TypingExamReadRepository(FastTypingTestDbContext context) : base(context)
        {
        }
    }
}
