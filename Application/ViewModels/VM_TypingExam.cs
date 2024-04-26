using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class VM_TypingExam
    {
        public string Text { get; set; }

        public Guid LanguageID { get; set; }

        public Guid CategoryID { get; set; }
    }
}
