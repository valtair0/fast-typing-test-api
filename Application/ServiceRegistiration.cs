using Application.Abstractions.Token;
using Application.Services.Tokens;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistiration));
            services.AddScoped<ITokenHandler, TokenHandler>();

        }
    }
}
