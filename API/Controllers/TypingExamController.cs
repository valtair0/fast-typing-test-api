using Application.Entities;
using Application.Repositories.Category;
using Application.Repositories.Language;
using Application.Repositories.TypingExam;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public TypingExamController(ITypingExamWriteRepository typingExamWriteRepository, ICategoryWriteRepository categoryWriteRepository, ILanguageWriteRepository languageWriteRepository)
        {
            _typingExamWriteRepository = typingExamWriteRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _languageWriteRepository = languageWriteRepository;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(VM_TypingExam model)
        {

            await _typingExamWriteRepository.AddAsync(
                new()
                {
                    Text = model.Text,
                    LanguageID = new Guid(model.LanguageID.ToString()),
                    CategoryID = new Guid(model.CategoryID.ToString()),
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

    }
}
