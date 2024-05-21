using Application.Repositories.Oneversusone;
using Application.Repositories.TypingExam;
using Domain.Entities;
using Persistence.Contexts;
using Prsistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Oneversusone
{
    public class OneversusoneWriteRepository : WriteRepository<Domain.Entities.Oneversusone>, IOneversusoneWriteRepository
    {
        public OneversusoneWriteRepository(FastTypingTestDbContext context) : base(context)
        {
        }
    }
}
