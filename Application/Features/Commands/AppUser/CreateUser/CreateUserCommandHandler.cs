
using Application.Abstractions.Services;
using Application.DTOs.User;
using Application.Repositories.Oneversusone;
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
        readonly IUserService _userService;
        readonly IOneversusoneWriteRepository _oneversusoneWriteRepository;

        public CreateUserCommandHandler(IUserService userService, IOneversusoneWriteRepository oneversusoneWriteRepository)
        {
            _userService = userService;
            _oneversusoneWriteRepository = oneversusoneWriteRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

            CreateUserResponse response = await _userService.CreateUser(new DTOs.User.CreateUser()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                Username = request.Username,
            });

            if (response.Succeeded)
            {
                await _oneversusoneWriteRepository.AddAsync(
              new()
              {
                  ConnectionID = null,
                  Username = request.Username,
              }
          );

                await _oneversusoneWriteRepository.SaveAsync();
            }



            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };

            // throw new UserCreateFailedException();
        }
    }
}
