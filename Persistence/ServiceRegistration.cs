using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
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
                options=> options.UseNpgsql("User ID=postgres;Password=ov43Vk25klv2!;Host=localhost;Port=5432;Database=fasttypingtest;")
                );

            

        }

    }
}
