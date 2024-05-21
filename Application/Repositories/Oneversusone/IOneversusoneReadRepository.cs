using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Oneversusone
{
    public interface IOneversusoneReadRepository : IReadRepository<Domain.Entities.Oneversusone>
    {
        Task<Domain.Entities.Oneversusone> GetByName(string name, bool tracking = true);
        Task<Domain.Entities.Oneversusone> GetByConnectionIdAsync(string connectionId, bool tracking = true);

    }
}
