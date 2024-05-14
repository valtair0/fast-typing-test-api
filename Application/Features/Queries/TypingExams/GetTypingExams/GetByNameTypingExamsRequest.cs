using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.TypingExams.GetTypingExams
{
    public class GetByNameTypingExamsRequest :IRequest<GetByNameTypingExamsResponse>
    {
        public string Language { get; set; }

        public string Category { get; set; }

        public string? Name { get; set; }

        public string Difficulty { get; set; }
    }
}
