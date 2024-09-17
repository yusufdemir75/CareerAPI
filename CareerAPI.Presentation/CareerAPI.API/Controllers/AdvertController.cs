using CareerAPI.Application.Features.Commands.Advert.CreateAdvert;
using CareerAPI.Application.Features.Commands.Advert.DeleteAdvert;
using CareerAPI.Application.Features.Commands.Advert.UpdateAdvert;
using CareerAPI.Application.Features.Commands.ApplyAdvert.DeleteAdvert;
using CareerAPI.Application.Features.Queries.Advert.GetActiveAdvert;
using CareerAPI.Application.Features.Queries.Advert.GetAdvert;
using CareerAPI.Application.Repositories;
using CareerAPI.Application.ViewModels.Adverts;
using CareerAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CareerAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdvertController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateAdvertCommandRequest createAdvertCommandRequest)
        {
            CreateAdvertCommandResponse response = await _mediator.Send(createAdvertCommandRequest);


            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var result = await _mediator.Send(new GetAdvertQueryRequest());
            return Ok(result.Adverts);
        }

        [HttpGet("Active-advert")]
        public async Task<IActionResult> GetActiveAdvert()
        {

            var result = await _mediator.Send(new GetActiveAdvertQueryRequest());
            return Ok(result.Adverts);
        }

        [HttpPut("update-all")]
        public async Task<IActionResult> UpdateAllAdverts()
        {
            var request = new UpdateAdvertCommandRequest();

            var response = await _mediator.Send(request);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("{advertNo}")]
        public async Task<IActionResult> DeleteAdvert(int advertNo)
        {
            // Command nesnesini oluştururken advertNo'yu constructor'a geçiriyoruz
            var command = new DeleteAdvertCommandRequest(advertNo);

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(new { message = result.Message });
            }

            return NotFound(new { message = result.Message });
        }
    }


}
