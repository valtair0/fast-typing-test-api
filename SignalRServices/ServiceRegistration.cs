using Application.Abstractions.Hubs;
using Microsoft.Extensions.DependencyInjection;
using SignalRServices.HubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServices
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {

            services.AddTransient<ITypingExamsHubService, TypingExamHubService>();
            services.AddSignalR();

        }
    }
}
