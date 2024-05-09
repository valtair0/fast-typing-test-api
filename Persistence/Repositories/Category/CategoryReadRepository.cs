using Application.Repositories.Category;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prsistence.Repositories.Category
{
    public class CategoryReadRepository : ReadRepository<Application.Entities.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(FastTypingTestDbContext context) : base(context)
        {
        }

        public async Task<Application.Entities.Category> GetByName(string name, bool tracking = true)
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
