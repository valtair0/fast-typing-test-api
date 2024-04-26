using Application.Repositories.Language;
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
    }
}
