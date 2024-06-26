﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TypingResult : BaseEntity
    {
        public int Wpm { get; set; }
        public int Accuracy { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public string CorrectWords { get; set; }
        public string WrongWords { get; set; }
        public string TypingExamId { get; set; }
        public string Userid { get; set; }

        public int Seconds { get; set; }

    }
}
