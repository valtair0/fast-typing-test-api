using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Category
{
    public interface ICategoryReadRepository : IReadRepository<Domain.Entities.Category>
    {
        Task<Domain.Entities.Category> GetByName(string name, bool tracking = true);
    }
}
