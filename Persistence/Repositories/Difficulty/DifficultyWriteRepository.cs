using Application.Repositories.Difficulty;
using Persistence.Contexts;
using Prsistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Difficulty
{
    public class DifficultyWriteRepository : WriteRepository<Domain.Entities.Difficulty>, IDifficultyWriteRepository
    {
        public DifficultyWriteRepository(FastTypingTestDbContext context) : base(context)
        {
        }
    }
}
