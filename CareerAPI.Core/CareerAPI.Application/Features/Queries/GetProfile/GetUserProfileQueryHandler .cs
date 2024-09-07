using CareerAPI.Application.Exceptions;
using CareerAPI.Application.Repositories;
using CareerAPI.Domain.Entities;
using CareerAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.GetProfile
{
    // Handlers/GetUserProfileQueryHandler.cs
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQueryRequest, GetUserProfileQueryResponse>
    {
         readonly UserManager<AppUser> _userManager;
         readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserProfileQueryHandler(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetUserProfileQueryResponse> Handle(GetUserProfileQueryRequest request, CancellationToken cancellationToken)
        {

            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);


            if (user == null)
            {
                throw new NotFoundUserException("Kullanıcı bulunamadı.");
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new GetUserProfileQueryResponse
            {
                UserName = user.UserName,
                Role = roles.ToList()
            };
        }
    }


}
