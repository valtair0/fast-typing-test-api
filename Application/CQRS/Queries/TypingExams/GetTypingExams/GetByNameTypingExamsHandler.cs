using Application.Entities;
using Application.Repositories.Category;
using Application.Repositories.Language;
using Application.Repositories.TypingExamm;
using Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.TypingExams.GetTypingExams
{
    public class GetByNameTypingExamsHandler : IRequestHandler<GetByNameTypingExamsRequest, GetByNameTypingExamsResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ILanguageReadRepository _languageReadRepository;
        readonly ITypingExamReadRepository _typingExamReadRepository;

        public GetByNameTypingExamsHandler(ICategoryReadRepository categoryReadRepository, ILanguageReadRepository languageReadRepository, ITypingExamReadRepository typingExamReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _languageReadRepository = languageReadRepository;
            _typingExamReadRepository = typingExamReadRepository;
        }

        public async Task<GetByNameTypingExamsResponse> Handle(GetByNameTypingExamsRequest request, CancellationToken cancellationToken)
        {
            var categoryName = await _categoryReadRepository.GetByName(request.Category);
            var languageName = await _languageReadRepository.GetByName(request.Language);


            var typingExams = _typingExamReadRepository.GetAll().Where(x => x.Category == categoryName.Id.ToString() && x.Language == languageName.Id.ToString()).Select(x => new VM_TypingExam
            {
                Name = x.Name,
                Text = x.Text,
                Language = languageName.Name,
                Category = categoryName.Name,
            });


            if (typingExams.Any())
            {


                return new()
                {
                    Name = typingExams.FirstOrDefault().Name,

                    Text = typingExams.FirstOrDefault().Text,

                    Category = typingExams.FirstOrDefault().Category,

                    Language = typingExams.FirstOrDefault().Language

                };
            }
            else
            {

               throw new Exception("No typing exams found for specified criteria");
               
            }
        }
    }
}
