using CareerAPI.Application.DTOs;
using CareerAPI.Application.Features.Queries.Advert.GetActiveAdvert;
using CareerAPI.Application.Features.Queries.AppUser.GetUserRoleQuery;
using CareerAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.AppUser.GetAllUserQuery
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {

        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public GetAllUserQueryHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var response = new GetAllUserQueryResponse
            {
                       PhoneNumber=user.PhoneNumber,
                       address=user.address,
                       birthDate=user.birthDate,
                       position=user.position,
                       skills=user.skills,
                       githubLink=user.githubLink,
                       instaLink=user.instaLink,
                       twitterLink=user.twitterLink,

                   
            };

            return response;
        }
    }
}
