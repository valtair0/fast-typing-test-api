using Application.Repositories.Oneversusone;
using Application.Repositories.TypingExamm;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Prsistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Oneversusone
{
    public class OneversusoneReadRepository : ReadRepository<Domain.Entities.Oneversusone>, IOneversusoneReadRepository
    {
        public OneversusoneReadRepository(FastTypingTestDbContext context) : base(context)
        {
        }

        public Task<Domain.Entities.Oneversusone> GetByConnectionIdAsync(string connectionId, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query.FirstOrDefaultAsync(x => x.ConnectionID == connectionId);

        }

        public async Task<Domain.Entities.Oneversusone> GetByName(string name, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(x => x.Username == name);
        }

       
    }
}
