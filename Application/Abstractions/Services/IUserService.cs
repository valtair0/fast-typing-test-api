using Application.DTOs.User;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateUser(CreateUser model);

        Task UpdateRefreshToken(string refreshtoken,AppUser user,DateTime accessTokenDate,int addOnAccesTokenData);
    }
}