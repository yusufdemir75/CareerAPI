using CareerAPI.Application.DTOs;
using CareerAPI.Application.Features.Queries.Advert.GetAdvert;
using CareerAPI.Application.Features.Queries.AppUser.GetAllUserQuery;
using CareerAPI.Application.Repositories;
using CareerAPI.Application.Repositories.ApplyAdvert;
using CareerAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.ApplyAdvert.GetAllApplyAdvertQuery
{
    public class GetAllApplyAdvertQueryHandler : IRequestHandler<GetAllApplyAdvertQueryRequest, GetAllApplyAdvertQueryResponse>
    {
        readonly IApplyAdvertReadRepository _applyAdvertReadRepository ;

        public GetAllApplyAdvertQueryHandler(IApplyAdvertReadRepository applyAdvertReadRepository)
        {
            _applyAdvertReadRepository = applyAdvertReadRepository;
        }
        public async Task<GetAllApplyAdvertQueryResponse> Handle(GetAllApplyAdvertQueryRequest request, CancellationToken cancellationToken)
        {
            var applyAdverts =  _applyAdvertReadRepository.GetAll(false)
                .OrderBy(a => a.CreatedDate)
                .ToList(); 

            var response = new GetAllApplyAdvertQueryResponse
            {
                ApplyAdvert = applyAdverts.Select(a => new ApplyAdvertDto
                {
                    Id = a.Id,
                    cvUrl = a.cvUrl,
                    isApproved=a.isApproved,
                    status=a.status,
                    advertNo= a.AdvertNo,
                    userName = a.userName,
                    nameSurname= a.nameSurname,
                    position= a.position,
                    address= a.address,
                    skills= a.skills,
                    advertTitle= a.advertTitle,

                }).ToList()
            };

            return response;

        }
    }
}
