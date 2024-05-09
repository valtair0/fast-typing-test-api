using Application.Abstractions.Token;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly UserManager<Entities.Identity.AppUser> userManager;
        readonly SignInManager<Entities.Identity.AppUser> signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<Entities.Identity.AppUser> userManager, SignInManager<Entities.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {

            var user = await userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await userManager.FindByEmailAsync(request.UsernameOrEmail);
            

            if (user == null)
                throw new DirectoryNotFoundException("Kullanıcı adı veya şifre hatalı");
            

            SignInResult result = await signInManager.CheckPasswordSignInAsync(user, request.password, false);

            if (result.Succeeded)
            {
               TokenDTO token = _tokenHandler.CreateAccessToken(15);

                return new LoginUserSuccessCommandResponse() { Token = token };


            }


            return new LoginUserFailCommandResponse() { ErrorMessage = "Kullanıcı adı veya şifre hatalı" };





        }
    }
}
