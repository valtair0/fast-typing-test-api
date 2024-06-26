﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.TypingExams.CreateTypingExams
{
    public class CreateTypingExamsRequest : IRequest<CreateTypingExamsResponse>
    {

        public string Name { get; set; }
        public string Text { get; set; }

        public string Language { get; set; }

        public string Category { get; set; }

        public string Difficulty { get; set; }



    }
}
