using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TypingExam :BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        public string Difficulty { get; set; }





    }
}
