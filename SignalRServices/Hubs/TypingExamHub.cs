using Application.Abstractions.Hubs;
using Application.Repositories.Language;
using Application.Repositories.Oneversusone;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServices.Hubs
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class TypingExamHub : Hub
    {
        //onconnection
        private readonly IOneversusoneReadRepository _oneversusoneReadRepository;
        private readonly IOneversusoneWriteRepository _oneversusoneWriteRepository;
        private readonly ITypingExamsHubService _typingExamsHubService;

        public TypingExamHub(IOneversusoneReadRepository oneversusoneReadRepository, IOneversusoneWriteRepository oneversusoneWriteRepository, ITypingExamsHubService typingExamsHubService)
        {
            _oneversusoneReadRepository = oneversusoneReadRepository;
            _oneversusoneWriteRepository = oneversusoneWriteRepository;
            _typingExamsHubService = typingExamsHubService;
        }

        public override async Task OnConnectedAsync()
        {
            Oneversusone response = await _oneversusoneReadRepository.GetByName(Context.User.Identity.Name);
            response.ConnectionID = Context.ConnectionId;
            _oneversusoneWriteRepository.Update(response);
            await _oneversusoneWriteRepository.SaveAsync();


            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                Oneversusone participant = await _oneversusoneReadRepository.GetByConnectionIdAsync(Context.ConnectionId);
                if (participant != null)
                {
                    participant.ConnectionID = null; // Bağlantı kimliğini temizle
                    _oneversusoneWriteRepository.Update(participant);
                    await _oneversusoneWriteRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                // Hata günlüğe kaydetme ve hata yönetimi
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task TypingExamDuelRequest(string username)
        {
            Oneversusone participant = await _oneversusoneReadRepository.GetByName(username);
            if (participant != null&&participant.ConnectionID!=null)
            {
                await _typingExamsHubService.AddUserToGroup(Context.ConnectionId, Context.ConnectionId);
                await _typingExamsHubService.AddUserToGroup(participant.ConnectionID, Context.ConnectionId);
            }
        }   
        public async Task SendTypingExam(string message)
        {
            await _typingExamsHubService.TypingExamAddedMessageAsync(message);
        }


    }
}
