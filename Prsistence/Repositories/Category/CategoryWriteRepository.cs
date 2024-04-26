using Application.Repositories.Category;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prsistence.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Application.Entities.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(FastTypingTestDbContext context) : base(context)
        {
        }
    }
}
