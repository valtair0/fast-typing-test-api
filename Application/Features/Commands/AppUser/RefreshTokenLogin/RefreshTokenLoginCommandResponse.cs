using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.AppUser.RefreshToken
{
    public class RefreshTokenLoginCommandResponse
    {
        public TokenDTO Token { get; set; }

    }
}
