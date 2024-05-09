
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        public TokenDTO Token { get; set; }

    }

    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public TokenDTO Token { get; set; }
    }

    public class LoginUserFailCommandResponse : LoginUserCommandResponse
    {
        public string ErrorMessage { get; set; }
        
    }
}
