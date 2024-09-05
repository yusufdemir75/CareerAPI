
using CareerAPI.Application.Features.Commands.AppUser.CreateUser;
using CareerAPI.Application.Repositories;
using CareerAPI.Application.ViewModels.Adverts;
using CareerAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CareerAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertWriteRepository _advertWriteRepository;

        public AdvertController(IAdvertWriteRepository advertWriteRepository)
        {
            _advertWriteRepository = advertWriteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Advert model)
        {

            
            await _advertWriteRepository.AddAsync(new()
            {
                companyName = model.companyName,
                title = model.title,
                address = model.Address,
                position= model.position,
                typeOfWork = model.typeOfWork,
                requirements=model.requirements,
            });
            await _advertWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
    }


}
