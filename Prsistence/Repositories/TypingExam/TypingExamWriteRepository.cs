using Application.Entities;
using Application.Repositories.TypingExam;
using Application.Repositories.TypingExamm;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prsistence.Repositories.TypingTest
{
    public class TypingExamWriteRepository : WriteRepository<TypingExam>, ITypingExamWriteRepository
    {
        public TypingExamWriteRepository(FastTypingTestDbContext context) : base(context)
        {
        }
    }
}
