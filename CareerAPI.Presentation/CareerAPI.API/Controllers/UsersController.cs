using CareerAPI.Application.Features.Commands.AppUser.CreateUser;
using CareerAPI.Application.Features.Commands.AppUser.LoginUser;
using CareerAPI.Application.Features.Queries.GetProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CareerAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {

        readonly IMediator _mediator;
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public  UsersController(IMediator mediator, UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            this._mediator = mediator;
            this._userManager = userManager;
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

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var query = new GetUserProfileQueryRequest();
            var profile = await _mediator.Send(query);
            return Ok(profile);
        }

    }
}
