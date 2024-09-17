using CareerAPI.Application.Features.Commands.Advert.CreateAdvert;
using CareerAPI.Application.Features.Commands.ApplyAdvert.CreateApplyAdvert;
using CareerAPI.Application.Features.Commands.ApplyAdvert.DeleteAdvert;
using CareerAPI.Application.Features.Commands.ApplyAdvert.UpdateApplyAdvert;
using CareerAPI.Application.Features.Queries.Advert.GetAdvert;
using CareerAPI.Application.Features.Queries.ApplyAdvert.GetAllApplyAdvertQuery;
using CareerAPI.Application.Features.Queries.ApplyAdvert.GetPersonelApplyAdvert;
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

        [HttpPut("{advertNo}")]
        public async Task<IActionResult> UpdateApplyAdvert(int advertNo, [FromBody] UpdateApplyAdvertCommandRequest request)
        {
            // advertNo'yu request modeline atıyoruz
            request.advertNo = advertNo;

            var response = await _mediator.Send(request);

            if (response.Success)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("getpersonelapplies/{userName}")]
        public async Task<IActionResult> GetPersonelApplies(string userName)
        {
            var query = new GetPersonelApplyAdvertQueryRequest
            {
                UserName = userName
            };

            try
            {
                var result = await _mediator.Send(query);
                return Ok(result.PersonelApplyAdvertDto);  // Yalnızca listeyi döndür
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{advertNo}")]
        public async Task<IActionResult> DeleteAdvert(int advertNo)
        {
            // Command nesnesini oluştururken advertNo'yu constructor'a geçiriyoruz
            var command = new DeleteApplyAdvertCommandRequest(advertNo);

            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(new { message = result.Message });
            }

            return NotFound(new { message = result.Message });
        }

    }
}

