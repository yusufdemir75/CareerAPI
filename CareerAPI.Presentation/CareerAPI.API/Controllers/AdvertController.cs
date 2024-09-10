using CareerAPI.Application.Features.Commands.Advert.CreateAdvert;
using CareerAPI.Application.Features.Commands.Advert.UpdateAdvert;
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
        private readonly IAdvertWriteRepository _advertWriteRepository;
        private readonly IAdvertReadRepository _advertReadRepository;
        private readonly IMediator _mediator;

        public AdvertController(IAdvertWriteRepository advertWriteRepository, IAdvertReadRepository advertReadRepository, IMediator mediator)
        {
            _advertWriteRepository = advertWriteRepository;
            _advertReadRepository = advertReadRepository;
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
            // UpdateAdvertCommandRequest nesnesini oluşturun (Gerekirse parametreleri ekleyin)
            var request = new UpdateAdvertCommandRequest();

            // Komutu MediatR aracılığıyla gönderin
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



    }


}
