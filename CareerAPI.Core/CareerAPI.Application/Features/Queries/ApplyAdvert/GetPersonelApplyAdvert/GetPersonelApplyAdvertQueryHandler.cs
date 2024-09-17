using CareerAPI.Application.DTOs;
using CareerAPI.Application.Repositories.ApplyAdvert;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.ApplyAdvert.GetPersonelApplyAdvert
{
    public class GetPersonelApplyAdvertQueryHandler : IRequestHandler<GetPersonelApplyAdvertQueryRequest, GetPersonelApplyAdvertQueryResponse>
    {
        readonly IApplyAdvertReadRepository _applyAdvertReadRepository;

        public GetPersonelApplyAdvertQueryHandler(IApplyAdvertReadRepository applyAdvertReadRepository)
        {
            _applyAdvertReadRepository = applyAdvertReadRepository;
        }
        public async Task<GetPersonelApplyAdvertQueryResponse> Handle(GetPersonelApplyAdvertQueryRequest request, CancellationToken cancellationToken)
        {
            var personelApplies = await _applyAdvertReadRepository.GetWhere(x => x.userName == request.UserName)
                .ToListAsync();

            // PersonelApplyAdvertDto nesnesine map'leyelim
            var response = new GetPersonelApplyAdvertQueryResponse
            {
                PersonelApplyAdvertDto = personelApplies.Select(pa => new PersonelApplyAdvertDto
                {
                    advertNo = pa.AdvertNo,
                    cvUrl = pa.cvUrl,
                    userName = pa.userName,
                    advertTitle = pa.advertTitle,
                    nameSurname = pa.nameSurname,
                    isApproved = pa.isApproved,
                    status = pa.status,
                    position = pa.position,
                    address = pa.address,
                    skills = pa.skills
                }).ToList()
            };

            return response;
        }
    }
}
