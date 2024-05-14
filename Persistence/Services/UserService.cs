using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Application.DTOs.User;
using Application.Exceptions;
using Application.Features.Commands.AppUser.CreateUser;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUser model)
        {

            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                NameSurname = model.NameSurname,
            }, model.Password);

            CreateUserResponse response = new CreateUserResponse() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarıyla eklendi";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += error.Description;
                }
            }

            return response;
        }

        public async Task UpdateRefreshToken(string refreshtoken, AppUser user,DateTime accessTokenDate, int addOnAccesTokenData)
        {
            if (user!= null) { 
                user.RefreshToken = refreshtoken;
                user.RefreshTokenEndTime = accessTokenDate.AddMinutes(addOnAccesTokenData);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new NotFoundUserExcaption();

            }

        }
    }
}