using Application.Repositories.Category;
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
    }
}
