using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Language
{
    public interface ILanguageReadRepository : IReadRepository<Domain.Entities.Language>
    {
        Task<Domain.Entities.Language> GetByName(string name, bool tracking = true);

    }
}
