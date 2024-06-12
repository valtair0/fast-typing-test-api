using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TypingResultRequest_VM
    {
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public int Seconds { get; set; }

        public string CorrectWords { get; set; }
        public string WrongWords { get; set; }
        public string TypingExamId { get; set; }

    }
}
