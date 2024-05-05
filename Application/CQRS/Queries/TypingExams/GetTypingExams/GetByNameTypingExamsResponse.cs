using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.TypingExams.GetTypingExams
{
    public class GetByNameTypingExamsResponse
    {
      public IQueryable<VM_TypingExam> datas { get; set; }
    }
}
