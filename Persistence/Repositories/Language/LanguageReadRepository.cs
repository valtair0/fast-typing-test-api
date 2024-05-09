using Application.Repositories.Language;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prsistence.Repositories.Language
{
    public class LanguageReadRepository : ReadRepository<Application.Entities.Language>, ILanguageReadRepository
    {
        public LanguageReadRepository(FastTypingTestDbContext context) : base(context)
        {
        }

        public async Task<Application.Entities.Language> GetByName(string name, bool tracking = true)
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
