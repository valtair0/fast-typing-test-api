using Application.Entities.Identity;
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

namespace Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContext<FastTypingTestDbContext>(
                options => options.UseNpgsql("User ID=postgres;Password=ov43Vk25klv2!;Host=localhost;Port=5432;Database=fasttypingtest;")
                );

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<FastTypingTestDbContext>();




            services.AddScoped<ITypingExamReadRepository, TypingExamReadRepository>();
            services.AddScoped<ITypingExamWriteRepository, TypingExamWriteRepository>();


            services.AddScoped<ITypingResultReadRepository, TypingResultReadRepository>();
            services.AddScoped<ITypingResultWriteRepository, TypingResultWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository > ();
            services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();

        }

    }
}
