using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Difficulty
{
    public interface IDifficultyReadRepository : IReadRepository<Domain.Entities.Difficulty>
    {
        Task<Domain.Entities.Difficulty> GetByName(string name, bool tracking = true);

    }
}
