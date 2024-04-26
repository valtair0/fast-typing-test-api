using Application.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities
{
    public class TypingExam :BaseEntity
    {
        public string Text { get; set; }

        public Guid LanguageID { get; set; }

        public Guid CategoryID { get; set; }






    }
}
