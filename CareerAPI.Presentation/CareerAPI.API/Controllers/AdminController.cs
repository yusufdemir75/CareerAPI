using CareerAPI.Application.Features.Commands.AppUser.CreateAdmin;
using CareerAPI.Application.Features.Commands.AppUser.CreateUser;
using CareerAPI.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminCommandRequest createAdminCommandRequest )
        {
            CreateAdminCommandResponse response = await _mediator.Send(createAdminCommandRequest);
            return Ok(response);
        }

       

    }
}
