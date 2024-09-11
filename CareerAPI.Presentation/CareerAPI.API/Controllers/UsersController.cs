using CareerAPI.Application.Features.Commands.AppUser.CreateUser;
using CareerAPI.Application.Features.Commands.AppUser.LoginUser;
using CareerAPI.Application.Features.Commands.AppUser.UpdateUser;
using CareerAPI.Application.Features.Queries.AppUser.GetAllUserQuery;
using CareerAPI.Application.Features.Queries.AppUser.GetUserRoleQuery;
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

        [HttpGet("role/{userName}")]
        public async Task<IActionResult> GetUserRole(string userName)
        {
            var query = new GetUserRoleQueryRequest(userName);
            var result = await _mediator.Send(query);

            return Ok(result);
        }


        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var query = new GetAllUserQueryRequest(userName);

            try
            {
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest request)
        {
           


            var result = await _mediator.Send(request);


            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
