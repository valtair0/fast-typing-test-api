using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TypingExamRequestDTO
    {
        public string? Id { get; set; }

        public string Name { get; set; }
        public string[] Text { get; set; }

        public string Language { get; set; }

        public string Category { get; set; }

        public string Difficulty { get; set; }
    }
}
