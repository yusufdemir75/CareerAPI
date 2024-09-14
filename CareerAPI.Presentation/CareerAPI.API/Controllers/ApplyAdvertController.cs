using CareerAPI.Application.Features.Commands.Advert.CreateAdvert;
using CareerAPI.Application.Features.Commands.ApplyAdvert.CreateApplyAdvert;
using CareerAPI.Application.Features.Queries.Advert.GetAdvert;
using CareerAPI.Application.Features.Queries.ApplyAdvert.GetAllApplyAdvertQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyAdvertController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplyAdvertController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplyAdvert(CreateApplyAdvertCommandRequest createApplyAdvertCommandRequest)
        {
            CreateApplyAdvertCommandResponse response = await _mediator.Send(createApplyAdvertCommandRequest);


            return Ok(response.Message);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _mediator.Send(new GetAllApplyAdvertQueryRequest());
            return Ok(result.ApplyAdvert);
        }
    }
}
