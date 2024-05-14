using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<TokenDTO> LoginAsync(string UsernameOrEmail, string password,int tokenlifetime);

        Task<TokenDTO> RefreshTokenLoginAsync(string refreshToken);
    }
}
