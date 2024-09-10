using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.AppUser.GetUserRoleQuery
{
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQueryRequest, GetUserRoleQueryResponse>
    {

        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public GetUserRoleQueryHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<GetUserRoleQueryResponse> Handle(GetUserRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var role = user.Role;

            return new GetUserRoleQueryResponse
            {
                Role = role
            };
        }
    }
}
