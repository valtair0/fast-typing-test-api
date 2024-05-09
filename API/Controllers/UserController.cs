﻿using Application.Features.Commands.AppUser.CreateUser;
using Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _mediator;


        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {   
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
        
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
        
            return Ok(response);
        }
            
    }
}