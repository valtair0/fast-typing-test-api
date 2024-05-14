using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Application.Abstractions.Services.Authentications;
using Application.Abstractions.Token;
using Application.DTOs;
using Application.Exceptions;
using Application.Features.Commands.AppUser.LoginUser;
using Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly SignInManager<AppUser> _signInManager;
        readonly IUserService _userService;

        public AuthService(
            UserManager<AppUser> userManager,
            ITokenHandler tokenHandler,
            SignInManager<AppUser> signInManager
,
            IUserService userService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<TokenDTO> GoogleLoginAsync(string idToken, int tokenlifetime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>
                {
                    "845058675091-8bmcsajd60cro6kanfhaecr0vk4vmtg8.apps.googleusercontent.com"
                }
            };

            var payload = GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            var info = new UserLoginInfo("GOOGLE", payload.Result.Subject, "GOOGLE");

            AppUser user = await _userManager.FindByLoginAsync(
                info.LoginProvider,
                info.ProviderKey
            );

            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Result.Email);

                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = payload.Result.Email,
                        Email = payload.Result.Email,
                        NameSurname = payload.Result.Name,
                    };

                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(user, info);

                TokenDTO token = _tokenHandler.CreateAccessToken(tokenlifetime,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.AccessTokenExpiration, 10);
                return token;

            }
            else
            {
                throw new Exception("Invalid External Auth");
            }

            
           
        }

        public async Task<TokenDTO> LoginAsync(
            string UsernameOrEmail,
            string password,
            int tokenlifetime
        )
        {
            var user = await _userManager.FindByNameAsync(UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(UsernameOrEmail);
            }


            if (user == null)
                throw new DirectoryNotFoundException("Kullanıcı adı veya şifre hatalı");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false
            );

            if (result.Succeeded)
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(tokenlifetime, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.AccessTokenExpiration, 10);


                return token;
            }

            throw new AuthenticationErrorException();
        }

        public async Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken)
        {
           AppUser? user = _userManager.Users.FirstOrDefault(u=>u.RefreshToken==refreshToken);

            if (user!=null&&user?.RefreshTokenEndTime>DateTime.UtcNow)
            {
                TokenDTO token = _tokenHandler.CreateAccessToken(15,user);
                await _userService.UpdateRefreshToken(refreshToken, user, token.AccessTokenExpiration, 15);
                return token;
                
            }
            else
            {
            throw new NotFoundUserExcaption();

            }
        }
    }
}
