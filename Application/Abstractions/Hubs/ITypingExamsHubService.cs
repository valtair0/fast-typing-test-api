using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Hubs
{
    public interface ITypingExamsHubService
    {
        Task TypingExamAddedMessageAsync(string message);
        Task AddUserToGroup(string connectionId,string groupname);

        Task AddUserToOnlineGroup(string connectionId);

        Task ListOnlineUsers();

    }
}
