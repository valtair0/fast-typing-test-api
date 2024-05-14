using Domain.Entities.Identity;
using Application.Repositories.Category;
using Application.Repositories.Language;
using Application.Repositories.TypingExam;
using Application.Repositories.TypingExamm;
using Application.Repositories.TypinResult;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Prsistence.Repositories.Category;
using Prsistence.Repositories.Language;
using Prsistence.Repositories.TypingResults;
using Prsistence.Repositories.TypingTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.Difficulty;
using Persistence.Repositories.Difficulty;
using Application.Abstractions.Services;
using Application.Abstractions.Services.Authentications;
using Persistence.Services;

namespace Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<FastTypingTestDbContext>(
                options => options.UseNpgsql(Configuration.ConnectionString)
                );

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;

                options.Password.RequiredLength = 8;

                options.Password.RequireDigit = false;

                options.Password.RequireLowercase = false;

                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<FastTypingTestDbContext>();




            services.AddScoped<ITypingExamReadRepository, TypingExamReadRepository>();
            services.AddScoped<ITypingExamWriteRepository, TypingExamWriteRepository>();


            services.AddScoped<ITypingResultReadRepository, TypingResultReadRepository>();
            services.AddScoped<ITypingResultWriteRepository, TypingResultWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository > ();
            services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();

            services.AddScoped<IDifficultyReadRepository, DifficultyReadRepository>();
            services.AddScoped<IDifficultyWriteRepository, DifficultyWriteRepository>();

            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAuthService,AuthService>();


        }

    }
}
