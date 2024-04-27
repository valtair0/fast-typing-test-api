using Application.CQRS.Queries.Category.GetByIdAsync;
using Application.CQRS.Queries.TypingExams.GetTypingExams;
using Application.Entities;
using Application.Repositories.Category;
using Application.Repositories.Language;
using Application.Repositories.TypingExam;
using Application.Repositories.TypingExamm;
using Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Xml;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TypingExamController : ControllerBase
    {

        private readonly ITypingExamWriteRepository _typingExamWriteRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly ITypingExamReadRepository _typingExamReadRepository;
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;

        readonly IMediator _mediator;

        public TypingExamController(ITypingExamWriteRepository typingExamWriteRepository, ICategoryWriteRepository categoryWriteRepository, ILanguageWriteRepository languageWriteRepository, ITypingExamReadRepository typingExamReadRepository, ILanguageReadRepository languageReadRepository, ICategoryReadRepository categoryReadRepository, IMediator mediator)
        {
            _typingExamWriteRepository = typingExamWriteRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _languageWriteRepository = languageWriteRepository;
            _typingExamReadRepository = typingExamReadRepository;
            _languageReadRepository = languageReadRepository;
            _categoryReadRepository = categoryReadRepository;
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(VM_TypingExam model)
        {
            var categoryName = await _categoryReadRepository.GetByName(model.Category);
            var languageName = await _languageReadRepository.GetByName(model.Language);

            if (categoryName == null || languageName == null)
            {
                return NotFound("Category or language not found in db");
            }


            await _typingExamWriteRepository.AddAsync(
                new()
                {
                    Text = model.Text,
                    Name = model.Name,
                    Language = languageName.Id.ToString(),
                    Category = categoryName.Id.ToString(),
                }
            );

            await _typingExamWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCategory(VM_Category model)
        {
            await _categoryWriteRepository.AddAsync(
                new()
                {

                    Name = model.Name,

                }
            );

            await _categoryWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateLanguage(VM_Language model)
        {
            await _languageWriteRepository.AddAsync(
                new()
                {
                    Name = model.Name,
                }
            );


            await _languageWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }


       


        [HttpGet("[action]")]
        public async Task<IActionResult> GetTypingExams([FromQuery] GetByNameTypingExamsRequest request)
        {

            //mediatr implementation
            var response = await _mediator.Send(request);

            return Ok(new
            {
                response.Name,
                response.Text,
                response.Language,
                response.Category

            });

        }





    }
}
