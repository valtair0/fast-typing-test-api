﻿
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<Entities.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id=Guid.NewGuid().ToString(),
                UserName = request.Username,
                Email = request.Email,
                NameSurname = request.NameSurname,
            }, request.Password);

            CreateUserCommandResponse response = new CreateUserCommandResponse() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                 response.Message = "Kullanıcı başarıyla eklendi";
            }
            else
            {
                foreach(var error  in result.Errors)
                {
                    response.Message += error.Description;  
                }
            }

            return response;
          // throw new UserCreateFailedException();
        }
    }
}
