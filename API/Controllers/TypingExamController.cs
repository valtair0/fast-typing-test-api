using Application.CQRS.Queries.TypingExams.GetTypingExams;
using Application.Repositories.Category;
using Application.Repositories.Difficulty;
using Application.Repositories.Language;
using Application.Repositories.TypingExam;
using Application.Repositories.TypingExamm;
using Application.Repositories.TypinResult;
using Application.ViewModels;
using Domain.Entities;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Xml;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = "Admin")]
    public class TypingExamController : ControllerBase
    {

        private readonly ITypingExamWriteRepository _typingExamWriteRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly ILanguageWriteRepository _languageWriteRepository;
        private readonly ITypingExamReadRepository _typingExamReadRepository;
        private readonly ILanguageReadRepository _languageReadRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IDifficultyReadRepository _difficultyReadRepository;
        private readonly IDifficultyWriteRepository _difficultyWriteRepository;
        private readonly ITypingResultReadRepository _typingResultReadRepository;
        private readonly ITypingResultWriteRepository _typingResultWriteRepository;
        readonly UserManager<AppUser> _userManager;
        readonly IMediator _mediator;



        public TypingExamController(ITypingExamWriteRepository typingExamWriteRepository, ICategoryWriteRepository categoryWriteRepository, ILanguageWriteRepository languageWriteRepository, ITypingExamReadRepository typingExamReadRepository, ILanguageReadRepository languageReadRepository, ICategoryReadRepository categoryReadRepository, IDifficultyReadRepository difficultyReadRepository, IDifficultyWriteRepository difficultyWriteRepository, IMediator mediator, ITypingResultReadRepository typingResultReadRepository, ITypingResultWriteRepository typingResultWriteRepository, UserManager<AppUser> userManager)
        {
            _typingExamWriteRepository = typingExamWriteRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _languageWriteRepository = languageWriteRepository;
            _typingExamReadRepository = typingExamReadRepository;
            _languageReadRepository = languageReadRepository;
            _categoryReadRepository = categoryReadRepository;
            _difficultyReadRepository = difficultyReadRepository;
            _difficultyWriteRepository = difficultyWriteRepository;
            _mediator = mediator;
            _typingResultReadRepository = typingResultReadRepository;
            _typingResultWriteRepository = typingResultWriteRepository;
            _userManager = userManager;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(VM_TypingExam model)
        {
            var categoryName = await _categoryReadRepository.GetByName(model.Category);
            var languageName = await _languageReadRepository.GetByName(model.Language);
            var difficultyName = await _difficultyReadRepository.GetByName(model.Difficulty);


            if (categoryName == null || languageName == null || difficultyName == null)
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
                    Difficulty = difficultyName.Id.ToString(),
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
        public async Task<IActionResult> CreateDifficulty(VM_Difficulty model)
        {
            await _difficultyWriteRepository.AddAsync(
                   new()
                   {
                       Name = model.Name,
                   }
            );


            await _difficultyWriteRepository.SaveAsync();

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

                data = response.datas

            });

        }

        [Authorize(AuthenticationSchemes = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> SendResults([FromBody] TypingResultRequest_VM model)
        {
            var data = User.Identity.Name;



            var typingExam = await _typingExamReadRepository.GetByIdAsync(model.TypingExamId);

         
            var jsoncorrectwords = model.CorrectWords.Replace(",", "");

            var wpmcalulation = jsoncorrectwords.Length / 5;

            var accuracyCalculation = (model.CorrectCount / (double)(model.CorrectCount + model.WrongCount)) * 100;



            TypingResult typingResult = new()
            {
                TypingExamId = model.TypingExamId,
                Userid = data,
                Wpm = wpmcalulation,
                Accuracy = (int)accuracyCalculation,
                CorrectCount = model.CorrectCount,
                WrongCount = model.WrongCount,
                CorrectWords = model.CorrectWords,
                WrongWords = model.WrongWords,
                Seconds = model.Seconds
            };


            var test  =  await _typingResultWriteRepository.AddAsync(typingResult);

            var testo =  await _typingResultWriteRepository.SaveAsync();


            return Ok(typingResult.Id);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetResult([FromQuery] string id)
        {
            var data = await _typingResultReadRepository.GetByIdAsync(id);

            var user = _userManager.Users.FirstOrDefault(u => u.Id == data.Userid);

            var typingexam = await _typingExamReadRepository.GetByIdAsync(data.TypingExamId);

            var diffculty = await _difficultyReadRepository.GetByIdAsync(typingexam.Difficulty);

            var language = await _languageReadRepository.GetByIdAsync(typingexam.Language);



            TypingResultResponse response = new()
            {
                Wpm = data.Wpm,
                Accuracy = data.Accuracy,
                CorrectCount = data.CorrectCount,
                WrongCount = data.WrongCount,
                CorrectWords = data.CorrectWords,
                WrongWords = data.WrongWords,
                Username = user.UserName,
                Seconds = data.Seconds,
                Language = language.Name,
                Difficulty = diffculty.Name

            };


            return Ok(response);

        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetLeaderBoard()
        {
            var data =  _typingResultReadRepository.GetAll().OrderByDescending(x => x.Wpm).Take(10).ToList().Select(x => new TypingResultResponse()
            {
                Wpm = x.Wpm,
                Accuracy = x.Accuracy,
                CorrectCount = x.CorrectCount,
                WrongCount = x.WrongCount,
                CorrectWords = x.CorrectWords,
                WrongWords = x.WrongWords,
                Username = _userManager.Users.FirstOrDefault(u => u.Id == x.Userid).UserName,
                Seconds = x.Seconds,
                Language = _languageReadRepository.GetByIdAsync(_typingExamReadRepository.GetByIdAsync(x.TypingExamId).Result.Language).Result.Name,
                Difficulty = _difficultyReadRepository.GetByIdAsync(_typingExamReadRepository.GetByIdAsync(x.TypingExamId).Result.Difficulty).Result.Name
            });

            

            return Ok(
                data
                );

        }




    }
}
