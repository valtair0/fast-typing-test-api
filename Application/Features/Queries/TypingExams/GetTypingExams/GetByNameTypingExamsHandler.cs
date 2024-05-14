using Domain.Entities;
using Application.Repositories.Category;
using Application.Repositories.Language;
using Application.Repositories.TypingExamm;
using Application.ViewModels;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Repositories.Difficulty;

namespace Application.CQRS.Queries.TypingExams.GetTypingExams
{
    public class GetByNameTypingExamsHandler : IRequestHandler<GetByNameTypingExamsRequest, GetByNameTypingExamsResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ILanguageReadRepository _languageReadRepository;
        readonly ITypingExamReadRepository _typingExamReadRepository;
        readonly IDifficultyReadRepository _difficultyReadRepository;

        public GetByNameTypingExamsHandler(ICategoryReadRepository categoryReadRepository, ILanguageReadRepository languageReadRepository, ITypingExamReadRepository typingExamReadRepository, IDifficultyReadRepository difficultyReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _languageReadRepository = languageReadRepository;
            _typingExamReadRepository = typingExamReadRepository;
            _difficultyReadRepository = difficultyReadRepository;
        }

        public async Task<GetByNameTypingExamsResponse> Handle(GetByNameTypingExamsRequest request, CancellationToken cancellationToken)
        {
            var categoryName = await _categoryReadRepository.GetByName(request.Category);
            var languageName = await _languageReadRepository.GetByName(request.Language);
            var difficultyName = await _difficultyReadRepository.GetByName(request.Difficulty);


            var typingExams = _typingExamReadRepository.GetAll().Where(x => x.Category == categoryName.Id.ToString() && x.Language == languageName.Id.ToString() && x.Difficulty == difficultyName.Id.ToString() ).Select(x => new TypingExamRequestDTO
            {
                Name = x.Name,
                Text = JsonConvert.DeserializeObject<string[]>(x.Text),
                Language = languageName.Name,
                Category = categoryName.Name,
                Difficulty = difficultyName.Name
            });

           

            if (request.Name != null)
            {
                typingExams = typingExams.Where(x => x.Name == request.Name);
            }



            if (typingExams.Any())
            {
                return new GetByNameTypingExamsResponse()
                {
                    datas = typingExams
                };
            }


            throw new Exception("No typing exams found for specified criteria");

        }
    }
}
