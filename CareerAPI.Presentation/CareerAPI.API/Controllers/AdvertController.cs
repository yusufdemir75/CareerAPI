using CareerAPI.Application.Features.Commands.AppUser.CreateUser;
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

        public AdvertController(IAdvertWriteRepository advertWriteRepository, IAdvertReadRepository advertReadRepository)
        {
            _advertWriteRepository = advertWriteRepository;
            _advertReadRepository = advertReadRepository;
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
                IsActive=model.IsActive,
                EndDate=model.EndDate,
            });
            await _advertWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var istanbulTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");

            var adverts = _advertReadRepository.GetAll(false).AsNoTracking().ToList();


            foreach (var advert in adverts)
            {
                var currentDateUtc = DateTime.UtcNow;
                var advertEndDateUtc = advert.EndDate;

                var currentDate = TimeZoneInfo.ConvertTimeFromUtc(currentDateUtc, istanbulTimeZone);
                var advertEndDate = TimeZoneInfo.ConvertTimeFromUtc(advertEndDateUtc, istanbulTimeZone);

                if (advertEndDate < currentDate && advert.IsActive)
                {
                    advert.IsActive = false;
                    _advertWriteRepository.Update(advert);
                }

                
            }

            await _advertWriteRepository.SaveAsync();

            return Ok(adverts.Select(a => new
            {
                a.Id,
                a.companyName,
                a.title,
                a.address,
                a.position,
                a.typeOfWork,
                a.requirements,
                a.IsActive
            }));
        }




    }


}
