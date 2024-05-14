using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Application.Abstractions.Token;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler
        : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(
            GoogleLoginCommandRequest request,
            CancellationToken cancellationToken
        ) {

            var response = await _authService.GoogleLoginAsync(request.idToken, 15);

            return new()
            {
                Token = response

            };
        
        
        }
    }
}
