using CareerAPI.Application.DTOs;
using CareerAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.Advert.GetAdvert
{
    public class GetAdvertQueryHandler : IRequestHandler<GetAdvertQueryRequest, GetAdvertQueryResponse>
    {
        private readonly IAdvertReadRepository _advertReadRepository;
        public GetAdvertQueryHandler(IAdvertReadRepository advertReadRepository)
        {
            _advertReadRepository = advertReadRepository;
        }


        public async Task<GetAdvertQueryResponse> Handle(GetAdvertQueryRequest request, CancellationToken cancellationToken)
        {


            var adverts = _advertReadRepository.GetAll(false)
                .OrderBy(a => a.CreatedDate)
                .ToList();

            var response = new GetAdvertQueryResponse
            {
                Adverts = adverts.Select(a => new AdvertDto
                {
                    Id = a.Id,
                    CompanyName = a.companyName,
                    Title = a.title,
                    Address = a.address,
                    Position = a.position,
                    TypeOfWork = a.typeOfWork,
                    Requirements = a.requirements,
                    IsActive = a.IsActive
                }).ToList()
            };

            return response;
        }


    }
}
