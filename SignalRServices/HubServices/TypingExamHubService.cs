using Application.Abstractions.Hubs;
using Microsoft.AspNetCore.SignalR;
using SignalRServices.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServices.HubServices
{
    public class TypingExamHubService : ITypingExamsHubService
    {
        readonly IHubContext<TypingExamHub> _context;

        public TypingExamHubService(IHubContext<TypingExamHub> context)
        {
            _context = context;
        }
     


        public async Task TypingExamAddedMessageAsync(string message)
        {
            await _context.Clients.All.SendAsync("reciveTypingExam", message);
        }

        public async Task AddUserToGroup(string connectionId, string groupname)
        {
            await _context.Groups.AddToGroupAsync(connectionId, groupname);


        }
    }
}
