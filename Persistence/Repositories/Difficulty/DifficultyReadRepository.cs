using Application.Repositories.Difficulty;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Prsistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Difficulty
{
    public class DifficultyReadRepository: ReadRepository<Domain.Entities.Difficulty>,IDifficultyReadRepository 
    {
        public DifficultyReadRepository(FastTypingTestDbContext context) : base(context)
        {
        }

        public async Task<Domain.Entities.Difficulty> GetByName(string name, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
