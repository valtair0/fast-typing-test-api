using Application.Abstractions.Hubs;
using Application.CQRS.Queries.TypingExams.GetTypingExams;
using Application.Repositories.Category;
using Application.Repositories.Difficulty;
using Application.Repositories.Language;
using Application.Repositories.TypingExam;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.TypingExams.CreateTypingExams
{
    public class CreateTypingExamsHandler : IRequestHandler<CreateTypingExamsRequest, CreateTypingExamsResponse>
    {

        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ILanguageReadRepository _languageReadRepository;
        readonly IDifficultyReadRepository _difficultyReadRepository;
        readonly ITypingExamWriteRepository _typingExamWriteRepository;
        readonly ILogger<CreateTypingExamsHandler> _logger;

        public CreateTypingExamsHandler(ICategoryReadRepository categoryReadRepository, ILanguageReadRepository languageReadRepository, IDifficultyReadRepository difficultyReadRepository, ITypingExamWriteRepository typingExamWriteRepository, ILogger<CreateTypingExamsHandler> logger)
        {
            _categoryReadRepository = categoryReadRepository;
            _languageReadRepository = languageReadRepository;
            _difficultyReadRepository = difficultyReadRepository;
            _typingExamWriteRepository = typingExamWriteRepository;
            _logger = logger;
        }

        public async Task<CreateTypingExamsResponse> Handle(CreateTypingExamsRequest request, CancellationToken cancellationToken)
        {
            var categoryName = await _categoryReadRepository.GetByName(request.Category);
            var languageName = await _languageReadRepository.GetByName(request.Language);
            var difficultyName = await _difficultyReadRepository.GetByName(request.Difficulty);


            if (categoryName == null || languageName == null || difficultyName == null)
            {
                return new CreateTypingExamsResponse()
                {
                    Message = "Category or language not found in db"
                };
            }


            await _typingExamWriteRepository.AddAsync(
                new()
                {
                    Text = request.Text,
                    Name = request.Name,
                    Language = languageName.Id.ToString(),
                    Category = categoryName.Id.ToString(),
                    Difficulty = difficultyName.Id.ToString(),
                }
            );

            await _typingExamWriteRepository.SaveAsync();
            _logger.LogInformation("Typing Exam Eklendi");
            return new CreateTypingExamsResponse() { Message = "Typing exam created successfully" };
        }
    }
}
