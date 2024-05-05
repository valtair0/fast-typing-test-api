using Application.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class TypingResult : BaseEntity
    {
        public int Wpm { get; set; }
        public int Accuracy { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public Guid TypingExamId { get; set; }
        public string Userid { get; set; }


    }
}
