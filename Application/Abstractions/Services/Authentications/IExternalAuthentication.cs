using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<TokenDTO> GoogleLoginAsync(string idToken,int tokenlifetime);
    }
}
