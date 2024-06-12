using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TypingResultResponse
    {
        public int Wpm { get; set; }
        public int Accuracy { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public string CorrectWords { get; set; }
        public string WrongWords { get; set; }
        public string Language { get; set; }
        public string Difficulty { get; set; }
        public string Username { get; set; }
        public int Seconds { get; set; }
    }
}
